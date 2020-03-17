#! /bin/bash
sum=0
image_save_path="/home/hbc/data/yolo/results/images/"
txt_save_path="/home/hbc/data/yolo/results/labels/"
for file in /home/hbc/data/smartcity/images/dataset1/Cam1/*.jpg
do
    if test -f $file
    then
        let "sum += 1"
        #echo $file if file
        name=${file%.*}  #去掉.jpg的后缀 
        #echo $name
        txt_name=$name".txt" #加上.txt的后缀 
        #echo $txt_name
        image_name=${name##*/} #图片的名字xxx
        #echo $image_name
        save_name=$image_save_path$image_name #图片保存的路径和名字/home/hbc/data/yolo/results/image/xxx(.jpg)
        #echo $savename
        ./darknet detect -i 0 cfg/yolov3.cfg yolov3.weights $file -out $save_name  #运行检测代码,保存图片
        mv $txt_name $txt_save_path #xxx.txt移动到/home/hbc/data/yolo/results/txt/xxx.txt
    fi
echo "sum=$sum"
done
