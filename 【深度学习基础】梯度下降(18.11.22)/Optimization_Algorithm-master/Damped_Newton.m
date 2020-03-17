clc;
clear;
syms x y;
f =(x+y)^2 + (x+1)^2 + (y+3)^2;
syms x1 y1 a;  % a�����Ჽ��
f1 = (x1+y1)^2 + (x1+1)^2 + (y1+3)^2;

% �ݶ�:һ�׵���
fx = diff(f,x);
fy = diff(f,y);
% ��ɭ����:���׵���
fxx = diff(fx,x);
fyy = diff(fy,y);
fxy = diff(fx,y);
fyx = diff(fy,x);

grad_f1 = [fx;fy];    % �ݶ�
grad_H2 = [fxx fxy;fyx fyy]; % 2x2�ĺ�ɭ����

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
plot3(x0,y0,z0,'r*');
hold on       

acc = 0.00001;  % ����
x = 10; 
y = -1.5;      % ��ʼ��
k = 0;         % �½�����

fprintf('����ţ���½���ʼ:\n')
while 1
	ans_tmp = [x;y];
	% S�м���㲿��:(x1,y1)��f1�����м���ɲ���?
	S = -eval(inv(grad_H2))*eval(grad_f1);
	x1 = x + a*S(1)
	y1 = y + a*S(2)
	% ���Ჽ����f1����a��ƫ���������:
    if diff(eval(f1),a) == 0
        a_result = 0;
    else
	    a_result = solve(diff(eval(f1)));
        fprintf('��%d�ε���,��ǰ���Ჽ��Ϊ:%.5f\n', k, a_result);
    end
    % ���Ҹ���(x,y)��ֵ:
    x = x + a_result*S(1);
	y = y + a_result*S(2);
    result_tmp = [x;y];
    acc_tmp = sqrt( (result_tmp(1)-ans_tmp(1))^2 + (result_tmp(2) - ans_tmp(2))^2 );
	if acc_tmp < acc
		fprintf('��ֵ����Ϊ:(%.5f,%.5f,%.5f)\n', x, y, eval(f));
        fprintf('��������:%d\n',k);
        plot3(x,y,eval(f),'r*');
        hold off;
        break;
    end
    plot3(x,y,eval(f),'r*');
    hold on;
    k = k + 1;
    if k >= 100
        fprintf('�Զ�����!\n');
        break;
    end
end
        

    