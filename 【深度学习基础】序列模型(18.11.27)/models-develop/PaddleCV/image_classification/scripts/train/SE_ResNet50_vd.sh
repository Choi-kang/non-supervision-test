#SE_ResNet50_vd
python train.py \
       --model=SE_ResNet50_vd \
       --batch_size=256 \
       --lr_strategy=cosine_decay \
       --lr=0.1 \
       --num_epochs=200 \
       --model_save_dir=output/ \
       --l2_decay=1e-4 \
       --use_mixup=True \
       --use_label_smoothing=True \
       --label_smoothing_epsilon=0.1 \
