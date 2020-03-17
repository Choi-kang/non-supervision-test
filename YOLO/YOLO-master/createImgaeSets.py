# createImageSets.py
# encoding:utf-8
import pdb
import glob
import os
import random
import math

def get_sample_value(txt_name, category_name):
    Labels_path = '/home/hbc/data/smartcity/SCdevkit/SC2018/Labels/'
    txt_path = Labels_path + txt_name+'.txt'
    try:
        with open(txt_path) as r_tdf:
            if category_name in r_tdf.read():
                return ' 1'
            else:
                return '-1'
    except IOError as ioerr:
        print('File error:'+str(ioerr))

txt_list_path = glob.glob('/home/hbc/data/smartcity/SCdevkit/SC2018/Labels/*.txt')
txt_list = []

for item in txt_list_path:
    temp1,temp2 = os.path.splitext(os.path.basename(item))
    txt_list.append(temp1)
txt_list.sort()
print(txt_list, end = '\n\n')

# train:val:test=8:1:1
num_trainval = random.sample(txt_list, math.floor(len(txt_list)*9/10.0)) # 可修改百分比
num_trainval.sort()
print(num_trainval, end = '\n\n')

num_train = random.sample(num_trainval,math.floor(len(num_trainval)*8/9.0)) # 可修改百分比
num_train.sort()
print(num_train, end = '\n\n')

num_val = list(set(num_trainval).difference(set(num_train)))
num_val.sort()
print(num_val, end = '\n\n')

num_test = list(set(txt_list).difference(set(num_trainval)))
num_test.sort()
print(num_test, end = '\n\n')

pdb.set_trace()

Main_path = '/home/hbc/data/smartcity/SCdevkit/SC2018/ImageSets/Main/'
sets = ['trainval','train','val','test']
category_name = ['Pedestrian']

# 循环写trainvl train val test
for item_sets in sets:
    list_name = 'num_'
    list_name += item_sets
    sets_name = Main_path + item_sets + '.txt' 
    try:
        # 写单个文件
        with open(sets_name, 'w') as w_tdf:
            # 一行一行写
            for item in eval(list_name):
                w_tdf.write(item+'\n')
        # 循环写category
        for item_category_name in category_name:
            category_txt_name = Main_path + item_category_name + '_' + item_sets + '.txt'
            with open(category_txt_name, 'w') as w_tdf:
                # 一行一行写
                for item in eval(list_name):
                    w_tdf.write(item+' '+ get_sample_value(item, item_category_name)+'\n')
    except IOError as ioerr:
        print('File error:'+str(ioerr))
