#coding=utf-8
import cv2
import os
import pylab as plb
import PIL.Image as Image

file = open ('/home/hbc/data/smartcity/annotation/Dataset3/test_a_query.dat')
query_dir = '/home/hbc/data/smartcity/test/query/dataset3/'
frames_dir = '/home/hbc/data/smartcity/frames/'
count = 0
for line in file.readlines():
    count += 1
    data = line.split() #space
    camera = data[0]
    frame = data[1]
    id = data[2]    
    xmin = data[3]
    ymin = data[4]
    xmax = int(data[3])+int(data[5])
    ymax = int(data[4])+int(data[6])
    image = Image.open(frames_dir+'3_'+camera+'_'+frame.zfill(6)+'.jpg')
    print ('query '+str(count)+': '+'camera '+camera+' ''frame '+frame.zfill(6)+' '+'id '+id)
    #box中的数必须是 int 否则会报错
    bbox = [int(xmin),int(ymin),int(xmax),int(ymax)]
    result = image.crop(bbox)
    query = query_dir+'3_'+camera+'_'+frame.zfill(6)+'_'+id+'.jpg'
    result.save(query)
