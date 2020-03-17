import os
file = open('/home/hbc/data/smartcity/annotation/Dataset1/train.dat', 'r')
labels_dir = '/home/hbc/data/smartcity/SCdevkit/SC2018/Labels/'
for line in file.readlines():
    data = line.split( )  #space
    frame = data[1]
    label = open(labels_dir+'1_'+data[0]+'_'+str(frame).zfill(6)+'.txt', 'a')
    label.write('Pedestrian '+data[2]+' '+data[3]+' '+data[4]+' '+data[5]+' '+data[6]+'\n')
    print('save '+'1_'+data[0]+'_'+str(frame).zfill(6)+'.txt successful!')
    label.close
file.close


    
