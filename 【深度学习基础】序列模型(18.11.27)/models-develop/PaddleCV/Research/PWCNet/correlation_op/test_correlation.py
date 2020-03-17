import unittest
from correlation import correlation
import numpy as np
import paddle.fluid as fluid
from paddle.fluid.dygraph.base import to_variable

def corr(x_1, x_2, pad_size=4, kernel_size=1, max_displacement=4, stride1=1, stride2=1, corr_multiply=1):
    K = kernel_size
    # rinput1 = np.pad(x_1, tuple([pad_size for _ in range(4)]), mode='constant').transpose(1, 2).transpose(2, 3)
    # rinput2 = np.pad(x_2, tuple([pad_size for _ in range(4)]), mode='constant').transpose(1, 2).transpose(2, 3)

    rinput1 = np.pad(x_1, ((0, 0), (0, 0), (pad_size, pad_size), (pad_size, pad_size)), mode='constant')
    rinput2 = np.pad(x_2, ((0, 0), (0, 0), (pad_size, pad_size), (pad_size, pad_size)), mode='constant')
    rinput1 = np.transpose(rinput1, (0, 2, 3, 1))
    rinput2 = np.transpose(rinput2, (0, 2, 3, 1))
    B = int(rinput1.shape[0])
    H = int(x_1.shape[2])
    W = int(x_2.shape[3])
    d = max_displacement
    D = 2 * d + 1
    output = np.zeros((B, D * D, H, W), dtype=np.float32)

    for b in range(B):
        for i in range(H):
            for j in range(W):
                for k in range(-d, d + 1):
                    for l in range(-d, d + 1):
                        x1_index = i + pad_size
                        y1_index = j + pad_size
                        x2_index = x1_index + k
                        y2_index = y1_index + l
                        output[b, l + d + D * (k + d), i, j] = np.mean(
                            rinput1[b, x1_index:x1_index + K, y1_index:y1_index + K] * rinput2[b,
                                                                                       x2_index:x2_index + K,
                                                                                       y2_index:y2_index + K])

    return output

class TestCorrelationOp(unittest.TestCase):
    def test_check_output(self):
        #x_shape = (1, 196, 3, 3)
        np.random.seed(13)
        np.set_printoptions(threshold=np.inf)
        x_shape = (2, 10, 3, 3)
        x_type = 'float32'
        x1 = fluid.layers.data(name='x1', shape=x_shape, dtype=x_type, append_batch_size=False)
        x2 = fluid.layers.data(name='x2', shape=x_shape, dtype=x_type, append_batch_size=False)

        x1_np = np.random.randn(2,3,4,5).astype(x_type)
        x2_np = np.random.randn(2,3,4,5).astype(x_type)
        out_np = corr(x1_np, x2_np, pad_size=4, kernel_size=1, max_displacement=4, stride1=1, stride2=1)

        out = correlation(x1, x2, pad_size=4, kernel_size=1, max_displacement=4, stride1=1, stride2=1)

        place = fluid.CUDAPlace(0)
        exe = fluid.Executor(place)
        res = exe.run(feed={'x1':x1_np, 'x2':x2_np}, fetch_list=[out.name])
        
        self.assertTrue(np.allclose(res[0], out_np))

class Net(fluid.dygraph.Layer):
    def __init__(self, name_scope):
        super(Net, self).__init__(name_scope)
    def forward(self, x1, x2):
        y = correlation(x1, x2, pad_size=4, kernel_size=1, max_displacement=4, stride1=1, stride2=1)
        return y

class TestCorrelationOpDyGraph(unittest.TestCase):
    def test_check_output(self):
        np.random.seed(13)
        np.set_printoptions(threshold=np.inf)
        x_shape = (2, 10, 3, 3)
        x_type = 'float32'
        place = fluid.CUDAPlace(0)
        with fluid.dygraph.guard(place):
            x1_np = np.random.randn(2,3,4,5).astype(x_type)
            x2_np = np.random.randn(2,3,4,5).astype(x_type)
            out_np = corr(x1_np, x2_np, pad_size=4, kernel_size=1, max_displacement=4, stride1=1, stride2=1)

            x1 = to_variable(x1_np)
            x2 = to_variable(x2_np)
            corr_pd = Net('corr_pd')
            y = corr_pd(x1, x2)
            out = y.numpy()
            self.assertTrue(np.allclose(out, out_np))

if __name__ == '__main__':
    unittest.main()
