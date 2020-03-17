% ��Ⱥ�㷨��Schaffer��������Сֵ!
% ˵����ȫ�������㷨���Ķ��ǿ����ʵģ�Ŀ�궼��������ֲ���С��������һ��С�����¼�!
% ������Schaffer��ΧһȦ�Ĺ��ֻ��Ƕ���Ⱥ�㷨��һ�����Ի��Եģ��Ѿ������䷢�����һ��С�����¼��ˡ�
% �Ľ�����75��ȫ������ʱ��һ��ĳ�ȫ�ְ뾶��һ��~

clc;
clear;
% f�����ֵ����-ǰ�����ֵ;������2.4
f = inline('0.5 + ( (sin(sqrt(X.^2+Y.^2))).^2 - 0.5 ) ./ ( 1+0.01*(X.^2+Y.^2) ).^2');
x = -5:0.01:5;
y = -5:0.01:5;
[X,Y] = meshgrid(x,y);
F = f(X,Y);
figure(1);
mesh(X,Y,F);
xlabel('������x'); ylabel('������y'); zlabel('�ռ�����z');
hold on;

% ����/������Χ������:
lower_x = -5;
upper_x = 5;
lower_y = -5;
upper_y = 5; 

% ģ�ͳ�ʼ��������:
ant = 500;      % ��������300ֻ̫����,����100ֻ���ɽ������
times = 200;    % ÿֻ������Ѱ80��
rou = 0.9;     % ��Ϣ�ػӷ�����
p0 = 0.2;      % ����ת�Ƶĸ��ʳ���

% ��ʼ����λ��(�ռ������)����Ӧ�ȼ���:
ant_x = zeros(1,ant);  % ÿֻ����λ�õ�x����
ant_y = zeros(1,ant);  % ÿֻ����λ�õ�y����
tau = zeros(1,ant);    % ��Ӧ��/������ֵ
Macro = zeros(1,ant);  % Macro��tau��ͬʹ�õ��м����������
for i=1:ant
    ant_x(i) = (upper_x-lower_x)*rand() + lower_x;
    ant_y(i) = (upper_y-lower_y)*rand() + lower_y;
    tau(i) = f(ant_x(i),ant_y(i));         % ��ʼ��Ӧ��/����ֵ
    plot3(ant_x(i),ant_y(i),tau(i),'k*');  % ��ʼȺ���ú�ɫ*���
    hold on;
    Macro = zeros(1,ant);
end

fprintf('��Ⱥ������ʼ(����Сֵ,��*):\n');
T = 1;
tau_best = zeros(1,times);  % ��¼ÿ��Ѱ�Һ��Ⱥ���е����ֵ!
p = zeros(1,ant);   % ÿֻ����״̬ת�Ƶĸ���,����p0�Ƚ�
while T < times
    lamda = 1/T;
    % �����ǲ鿴��ֵ�ĵط�!��
    [tau_best(T),bestindex] = min(tau);
    
    % �����㹻�ߣ���ǰ����!
    if T >= 3 && abs((tau_best(T) - tau_best(T-2))) < 0.000001
        fprintf('�����㹻��,��ǰ����!\n');
        % С��˼:���һ�λ�ͼ����������԰����һ��������ɫ�����Ǻ�ɫ��
        plot3(ant_x(bestindex), ant_y(bestindex), f(ant_x(bestindex),ant_y(bestindex)), 'g*');
        break;
    end
    plot3(ant_x(bestindex), ant_y(bestindex), f(ant_x(bestindex),ant_y(bestindex)), 'r*');
    hold on;
    
    for i = 1:ant
        p(i) = (tau(bestindex) - tau(i))/tau(bestindex); % ÿһֻ���ϵ�ת�Ƹ���
    end
    % λ�ø���: �������ʱ����tempx��tempy��һ����!
    for i = 1:ant
        % С��p0���оֲ�����:
        if p(i) < p0
            tempx = ant_x(i) + 0.5*(2*rand-1)*lamda;  % �ֲ��������µ�һ��
            tempy = ant_y(i) + 0.5*(2*rand-1)*lamda;
        % ����p0����ȫ������:
        else
            tempx = ant_x(i) + (upper_x-lower_x)*(rand-2.5);  % 5/2=2.5
            tempy = ant_y(i) + (upper_y-lower_y)*(rand-2.5);
        end
        % ����Խ�磬��һ��Խ���ж�:
        if tempx < lower_x
            tempx = lower_x;
        end
        if tempx > upper_x
            tempx = upper_x;
        end
        if tempy < lower_y
            tempy = lower_y;
        end
        if tempy > upper_y
            tempy = upper_y;
        end
        % �ж������Ƿ��ƶ�,��tempx��tempy�Ƿ����
        % tau(i)����һ�ֵ�ֵ��Macro�Ǽ�ʱ���µ�ֵ!!
        if f(tempx,tempy) < tau(i)
            ant_x(i) = tempx;
            ant_y(i) = tempy;
            Macro(i) = f(tempx,tempy);
        end
    end
   
    % ��Ӧ�ȸ���:
    for i = 1:ant
        tau(i) = (1-rou)*tau(i) + Macro(i);
    end
    
    % ����������һ��:
    T = T + 1;
end
hold on;
    
fprintf('��Ⱥ����������Сֵ��:(%.5f,%.5f,%.5f)\n',...
        ant_x(bestindex), ant_y(bestindex), f(ant_x(bestindex),ant_y(bestindex)));
fprintf('��������:%d\n\n',T)

% ���Է���: ����0.08�϶���������Χ��һȦ���ֵ�����!
% ����С�����¼����ٴ�ִ������ִ�г��򼴿ɡ�
if f(ant_x(bestindex),ant_y(bestindex)) > 0.08
    fprintf('����С�����¼�: ����ֲ���Сֵ,���ٴ�ִ�г���!\n')
    return ;
end

% ���濪ʼ�ݶ��½���ȷ����:
% ��ʼ��:
syms x y;
f = 0.5 + ( (sin(sqrt(x^2+y^2)))^2 - 0.5 ) / ( 1+0.01*(x^2+y^2) )^2;
fx = diff(f,x);
fy = diff(f,y);
acc = 0.00001;     % ����
study_step = 0.001; % ѧϰ��
x = ant_x(bestindex); 
y = ant_y(bestindex);
k = 0; % �½�����
fprintf('�ݶ��½���ȷ������ʼ(����):\n');
while eval(fx)~=0 | eval(fy)~=0 
	ans_tmp = [x,y] - study_step*[eval(fx),eval(fy)];
	acc_tmp = sqrt((ans_tmp(1)-x)^2 + (ans_tmp(2)-y)^2);
	if acc_tmp <= acc
		fprintf('��ȷ��ֵ����Ϊ:(%.5f,%.5f,%.5f)\n',ans_tmp(1),ans_tmp(2),f_tmp);
        fprintf('��������:%d\n',k);
        plot3(ans_tmp(1),ans_tmp(2),f_tmp,'y.');
        hold off
		break;
	end
	x = ans_tmp(1);
	y = ans_tmp(2);
	f_tmp = eval(f);
    plot3(x,y,f_tmp,'y.')
    hold on;
    k = k + 1;  % ������
end
    
    