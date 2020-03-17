import os
import shutil

def getAllFiles(dir):
   return [os.path.join(dir,f) for f in os.listdir(dir) if f.endswith('.jpg')]
    
query_dir = '/home/hbc/data/smartcity/test/query/dataset3/'
gallery_dir = '/home/hbc/data/smartcity/test/gallery/dataset3/'
frames_dir = '/home/hbc/data/smartcity/frames/'
for dir in getAllFiles(query_dir):
    init = dir[-18:-14]
    frame = int(dir[-14:-8])+1
    count =0
    while count <= 4:
        f = frame + count*10
        count += 1
        name = init+str(f).zfill(6)
        srcFile = frames_dir+name+'.jpg'
        trgtFile = gallery_dir+name+'.jpg'
        shutil.copy(srcFile, trgtFile)
        print('coping '+name+'.jpg')
