import cv2
f=0
cap = cv2.VideoCapture('/home/hbc/data/smartcity/dataset3/Cam5/Cam5.avi')
if cap.isOpened():
    rval,frame = cap.read()
else:
    rval = False
while rval:
    rows,cols,channel = frame.shape
    _path = '/home/hbc/data/smartcity/frames/'+'3_5_'+str(f).zfill(6)+'.jpg'
    # '.jpg'表示把当前图片frame按照jpg格式编码，按照不同格式编码的结果不一样
    cv2.imencode('.jpg',frame)[1].tofile(_path)  
    print ('saving %s' % _path)
    cv2.waitKey(1)
    f = f + 1
    rval,frame = cap.read()
cap.release()
print ('total saved %d imagess' % f)

