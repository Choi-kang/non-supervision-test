import os
import shutil
Labels_dir = '/home/hbc/data/smartcity/SCdevkit/SC2018/Labels/'
frames_dir = '/home/hbc/data/smartcity/frames/'
JPEGImages_dir = '/home/hbc/data/smartcity/SCdevkit/SC2018/JPEGImages/'

#读取path路径下的 jpg文件
def getAllFiles(dir):
    #f.endswith（）  限制文件类型
    #f.endswith('.txt')  改成这句可以读取txt格式的文件
    #注意 返回的是绝对路径
   return [os.path.join(dir,f) for f in os.listdir(dir) if f.endswith('.txt')]

for dir in getAllFiles(Labels_dir):
    srcfile = os.path.splitext(dir.replace(Labels_dir,frames_dir))[0]+'.jpg'
    dstfile = os.path.splitext(dir.replace(Labels_dir,JPEGImages_dir))[0]+'.jpg'
    shutil.copyfile(srcfile, dstfile)
    print ('copy '+srcfile+' to '+dstfile)

