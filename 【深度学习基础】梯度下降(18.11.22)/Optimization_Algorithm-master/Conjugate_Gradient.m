clc;
clear;
syms x y r;
f = (x+y)^2 + (x+1)^2 + (y+3)^2;
syms x_tmp y_tmp;
f_tmp = (x_tmp+y_tmp)^2 + (x_tmp+1)^2 + (y_tmp+3)^2;

% һ�׵���:
fx = diff(f,x);
fy = diff(f,y);
grad_f1 = [fx,fy]';  % �ݶ�(������)

% ��ͼ:ԭʼ3d����ͼ
x = -20:0.1:20;
y = -15:0.1:15;
[X,Y] = meshgrid(x,y); 
Z = (X+Y).^2 + (X+1).^2 + (Y+3).^2;
figure(1);
mesh(X,Y,Z);
xlabel('������x'); ylabel('������y'); zlabel('�ռ�����z');
hold on;
% ��ͼ:ԭʼ��
x0 = 10; y0 = -1.5;
z0 = (x0+y0)^2 + (x0+1)^2 + (y0+3)^2;
plot3(x0,y0,z0,'r*')
hold on

% ��ʼ��:
acc = 0.0001;     % ����
x = 10; 
y = -1.5;  % ���
k = 1;     % �½�����:�������⣡��������"�µ�"�����жϵģ�

fprintf('�����ݶ��½���ʼ:\n');
d = -eval(grad_f1);   % ��ʼdֵ
while 1
    % grad_f1_down��grad_f1_up����̵ķ�ĸ�����
    % ���ҷ������ݶ���һ�ֵ�ֵ����ĸ���ݶ���һ�ֵ�ֵ��
    % r��r_result����ÿһ�ֵı䲽����
    grad_f1_down = norm(eval(grad_f1))^2;   % ����(x,y)��ֵ
    x_tmp = x + r*d(1);
    y_tmp = y + r*d(2);
    r_result = solve(diff(eval(f_tmp)));

    % ������һ��:
    x = x + r_result*d(1);
    y = y + r_result*d(2);
    grad_f1_up = norm(eval(grad_f1))^2;     % ����(x,y)��ֵ
    plot3(x,y,eval(f),'r*');  % ���ұ��Ҳ�����µ�!
    hold on 

    if norm(eval(grad_f1)) <= acc
        fprintf('��ֵ����Ϊ:(%.5f,%.5f,%.5f)\n',x,y,eval(f))
        fprintf('��������:%d\n',k)
        break;
    end
    
    miu = grad_f1_up/grad_f1_down;
    d = -eval(grad_f1) + miu*d;
    k = k+1;
end
hold off;
    
    