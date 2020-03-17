# YOLO: Real-Time Object Detection
You only look once (YOLO) is a state-of-the-art, real-time object detection system. On a Pascal Titan X it processes images at 30 FPS and has a mAP of 57.9% on COCO test-dev.

The original YOLO run with [darknet](http://pjreddie.com/darknet) which is an open source neural network framework written in C and CUDA. It is fast, easy to install, and supports CPU and GPU computation.

This project is a modified version for some requirements such as saving labes, saving video and creating dataset for training.

### Save labels for multiple images 
If you want to detect a picture, you can use the two commands:
```
#without -out
./darknet detect cfg/yolov3.cfg yolov3.weights /home/username/data/xxx.jpg
#with -out
./darknet detect cfg/yolov3.cfg yolov3.weights /home/username/data/xxx.jpg -out result
```
You will see some output like this:
```
layer     filters    size              input                output
    0 conv     32  3 x 3 / 1   416 x 416 x   3   ->   416 x 416 x  32  0.299 BFLOPs
    1 conv     64  3 x 3 / 2   416 x 416 x  32   ->   208 x 208 x  64  1.595 BFLOPs
    .......
  105 conv    255  1 x 1 / 1    52 x  52 x 256   ->    52 x  52 x 255  0.353 BFLOPs
  106 detection
truth_thresh: Using default '1.000000'
Loading weights from yolov3.weights...Done!
data/dog.jpg: Predicted in 0.029329 seconds.
dog: 99%
truck: 93%
bicycle: 99%
```
If you run the detect command without -out, the detection result will save as predictions.jpg.

If you run the detect command with -out and 'name' which you want to save, the detection result will save as name.jpg.

In fact, the detect command is shorthand for a more general version of the command. It is equivalent to the command:
```
./darknet detctor test cfg/coco.data cfg/yolov3.cfg yolov3.weights /home/username/data/xxx.jpg
```
Multiple images:

If you run the detect command without directory of the test image, you can test multiple images after loading the model. However, we always want to detect all images in a directory and save the results which need to modify the source code and complie it again. Here are the files need to be modified: include/darknet.h src/image.c examples/detector.c examples/darknet.c

After modified, you can detect single image with this command:
```
./darknet detect cfg/yolov3.cfg yolov3.weights -input /home/username/data/xxx.jpg -out test
```
For multiple images, you can use this command:
```
./darknet detect cfg/yolov3.cfg yolov3.weights -idir /home/username/data/imagedir/ -odir /home/username/data/results/
```
And you should create images folder and labels folder in the results directory in advance.
