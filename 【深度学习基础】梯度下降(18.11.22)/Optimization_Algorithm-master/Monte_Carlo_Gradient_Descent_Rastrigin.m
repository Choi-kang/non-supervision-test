% ������ʹ��Rastrigin����
% ˼·���������ؿ���ȫ��������������Сֵ(��������)�������ݶ��½������о�ȷ������

clc;
clear;
syms x y;
% ���ݺ������ʽ: f��Сֵ��0
f = 20 + x^2 + y^2 -10*(cos(2*pi*x) + cos(2*pi*y));
% һ�׵���: Ϊ���ѵ��ݶ��½�׼��
fx = diff(f,x);
fy = diff(f,y);

% ԭʼͼ��:
x = -5:0.01:5;
y = -5:0.01:5;
[X,Y] = meshgrid(x,y);
Z = 20 + X.^2 + Y.^2 -10*(cos(2*pi*X) + cos(2*pi*Y));
figure(1);
mesh(X,Y,Z);
xlabel('������x'); ylabel('������y'); zlabel('�ռ�����z');
hold on;
x0 = 2.42;
y0 = -4.58;
f_min = 20 + x0^2 + y0^2 -10*(cos(2*pi*x0) + cos(2*pi*y0));
plot3(x0,y0,f_min,'b*');
hold on;

% 1001*1001 ȫ��10w�ֿ���(x,y):
x_all = -5:0.01:5;
y_all = -5:0.01:5;
num = 1;
count = 0;  % ��¼���в����������м��γɹ�ǰ���ˣ�
fprintf('���ؿ������������ʼ:\n')
while num < 80000  % ���Լ�8w  ���Լ�̫С�ҵ���ֵ�ĸ��ʾͺ�С!
    x = x_all(randperm(length(x_all),1));
    y = y_all(randperm(length(y_all),1));
    if eval(f) < f_min
        count = count + 1;
        f_min = eval(f);
        x_tmp = x;
        y_tmp = y;
        fprintf('��ǰ��Сֵ����Ϊ:(%.5f,%.5f,%.5f)\n', x_tmp, y_tmp, f_min);
        fprintf('��ǰ�ɹ��滻����:%d\n\n',count)
        plot3(x_tmp, y_tmp, f_min, 'r*');
        hold on;
    end
    num = num + 1;
end


% ���濪ʼ�ݶ��½���ȷ����:
% ��ʼ��:
acc = 0.001;     % ����
study_step = 0.001; % ѧϰ��
x = x_tmp; 
y = y_tmp;
k = 0; % �½�����
% �ݶ��½���ʼ:[x1,y1] = [x0,y0] - step*( fx(x0,y0),fy(x0,y0) )
% ͼ����һ���µ����࣬��Ծʽ�½���
fprintf('�ݶ��½���ȷ������ʼ:\n');
while eval(fx)~=0 | eval(fy)~=0 
	ans_tmp = [x,y] - study_step*[eval(fx),eval(fy)];
	acc_tmp = sqrt((ans_tmp(1)-x)^2 + (ans_tmp(2)-y)^2);
	if acc_tmp <= acc
		fprintf('��ȷ��ֵ����Ϊ:(%.5f,%.5f,%.5f)\n',ans_tmp(1),ans_tmp(2),f_tmp);
        fprintf('��������:%d\n',k);
        plot3(ans_tmp(1),ans_tmp(2),f_tmp,'k.');
        hold off
		break;
	end
	x = ans_tmp(1);
	y = ans_tmp(2);
	f_tmp = eval(f);
    plot3(x,y,f_tmp,'k.')
    hold on;
    k = k + 1;  % ������
end

