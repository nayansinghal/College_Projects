function varargout = system(varargin)
% SYSTEM MATLAB code for system.fig
%      SYSTEM, by itself, creates a new SYSTEM or raises the existing
%      singleton*.
%
%      H = SYSTEM returns the handle to a new SYSTEM or the handle to
%      the existing singleton*.
%
%      SYSTEM('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in SYSTEM.M with the given input arguments.
%
%      SYSTEM('Property','Value',...) creates a new SYSTEM or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before system_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to system_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help system

% Last Modified by GUIDE v2.5 01-May-2013 17:01:38

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @system_OpeningFcn, ...
                   'gui_OutputFcn',  @system_OutputFcn, ...
                   'gui_LayoutFcn',  [] , ...
                   'gui_Callback',   []);
if nargin && ischar(varargin{1})
    gui_State.gui_Callback = str2func(varargin{1});
end

if nargout
    [varargout{1:nargout}] = gui_mainfcn(gui_State, varargin{:});
else
    gui_mainfcn(gui_State, varargin{:});
end
% End initialization code - DO NOT EDIT


% --- Executes just before system is made visible.
function system_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to system (see VARARGIN)

% Choose default command line output for system
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);

% UIWAIT makes system wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = system_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;


% --- Executes on button press in pushbutton1.
function pushbutton1_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% hObject    handle to pushbutton1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% hObject    handle to pushbutton4 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
[fname path]=uigetfile('*.mat');
fname=strcat(path,fname);
global A;

%% LOAD FILE
		load(fname );
        A=val(1,:);
        plot(A);
        z=zeros(100,1);
       
        A=val(1,:);
        v1=val(1,:)-val(1,1);
        A=v1;
        A=A';
        zc=A(1);
        A=[z;A;z];
       
		s = A;
        ls = length(s);
       
	[c,l]=wavedec(s,4,'db4');
	ca1=appcoef(c,l,'db4',1);
	ca2=appcoef(c,l,'db4',2);
	ca3=appcoef(c,l,'db4',3);
	ca4=appcoef(c,l,'db4',4);
  
%% ZERO CROSSING REMOVAL%%%%%%
	base_corrected=ca2;
	y=base_corrected-zc;
  
%% DETECT R_PEAK
	y1=y;
	m1=max(y1)-max(y1)*.50;
	P=find(y1>=m1);
	P

% it will give two two points ... remove one point each
	P1=P;
	P2=[];

	k=length(P1);
	k=k-1;
	i=1;
		while(i<=k)
		high=0;
		j=i;
		
			while(i<=k)
			if(P1(i+1)-P1(i)>15)
			break;
			end;
			i=i+1;
			end;
			
		last=P1(j);
		high=y1(P1(j));
		j=j+1;

			while(j<=i)
			if(y1(P1(j))>high)
			high=y1(P1(j));
			last=P1(j);
			end;
			if(j==k)
			break;
			end;
			j=j+1;
			end;
			
		P2=[P2 last];
		i=i+1;
	end
	
	if(P1(k+1)-P1(k)>25)
	P2=[P2 P1(k+1)]
	end;
	
	Rt=y1(P2);
	P3=P2*4;
	Rloc=[];
	
	for( i=1:1:length(P3))
		range= [P3(i)-25:P3(i)+25];
		m=max(A(range));
		l=find(A(range)==m);
		pos=range(l);
		Rloc=[Rloc pos(1)];
	end
	
	Ramp=A(Rloc);

%title('Detected R peak in actual Signal')
	X=Rloc;
	y1=A;
	F=[];
	for(i=1:1:1)


	for(j=1:1:length(X))
	j
	
%%Q Peak Detection

	rn=(Rloc(1,2)-Rloc(1,1))/10;
	a=floor((Rloc(i,j)-5)-rn):Rloc(i,j)-1;
    m=min(y1(a));
    b=find(y1(a)==m);
    b=b(1);
    b=a(b);
    Qloc(i,j)=b;
    Qamp(i,j)=m;
	
%%%%% ONSET
    fnd=0;
	for k=floor(b-(5+rn)):+1:(b-1) 
		if((y1(k)<=0) && (y1(k-1)>0))
        qon1=k;
        fnd=1;
		break 
		end
	end
	
	if(fnd==0)
	Qrange=floor(b-(5+rn)):+1:b;
	qon1=find(y1(Qrange)==max(y1(Qrange)));
	qon1=Qrange(qon1);
	end
	
	QON(i,j)=qon1(1);
	fnd;
	
%%%%% OFFSET
	for k=b+1:+1:floor(b+(rn-1))
		if((y1(k)>=0) && (y1(k-1)<=0))
			qon1=k;
			fnd=1;
		break 
		end
	end
	if(fnd==0)
	Qrange=b+1:+1:b+(rn-1);
	qon1=find(y1(Qrange)==max(y1(Qrange)));
	qon1=Qrange(qon1);
	end
	QOF(i,j)=qon1(1);
	
%%P Peak Detection
	
	rn=floor((Rloc(1,2)-Rloc(1,1))/2);
	a=Rloc(i,j)-rn:QON(i,j)-1;
	
    m=max(y1(a));
    b=find(y1(a)==m);
    b=b(1);
    b=a(b);
    Ploc(i,j)=b;
    Pamp(i,j)=m;
	
	F=[F (Ploc(i,j)-(QON(i,j)-Ploc(i,j)))];
	if(((QON(i,j)-Ploc(i,j)))>20)
	Cloc(i,j)=(Ploc(i,j)-(QON(i,j)-Ploc(i,j)));
	Camp(i,j)=A(Cloc(i,j));
	else
	Cloc(i,j)=(Ploc(i,j)-(2*(QON(i,j)-Ploc(i,j))));
	Camp(i,j)=A(Cloc(i,j));
	end;
	
%% S  Detection
	rn=floor((Rloc(1,2)-Rloc(1,1))/10);
    a=Rloc(i,j)+1:Rloc(i,j)+(rn+5);
    m=min(y1(a));
    b=find(y1(a)==m);
    b=b(1);
    b=a(b);
    Sloc(i,j)=b;
    Samp(i,j)=m;
	
%%%% onset off
    fnd=0;
	for k=Rloc(i,j)+1:+1:b
    if((y1(k)<=0) && (y1(k-1)>0))
        qon1=k;
        fnd=1;
      break 
	end
	end
	if(fnd==0)
	Qrange=Rloc(i,j)+1:+1:b;
	qon1=find(y1(Qrange)==max(y1(Qrange)));
	qon1=Qrange(qon1);
	end
	SON(i,j)=qon1(1);
	fnd=0;
	for k=b:+1:b+(rn+5)
    if((y1(k)>=0) && (y1(k-1)<0))
        qon1=k;
        fnd=1;
      break 
	end
	end
	if(fnd==0)
	Qrange=b:+1:b+(rn+5);
	qon1=find(y1(Qrange)==max(y1(Qrange)));
	qon1=Qrange(qon1);
	end
	SOFF(i,j)=qon1(1);
	
	end;
	end;
	
% T - peak
	sd=7;
	Tloc=[];
	sd=100;
	for(m=1:+1:length(Cloc(1,:))-1)
	m
	a=y1(SOFF(1,m):Cloc(1,m+1));
	[c,l]=wavedec(a,4,'db4');
	ca2=appcoef(c,l,'db4',2);
	y1t=ca2;

	sd=sd+1;
	max(y1t)
	if(max(y1t)<0)
	m1=max(y1t)+max(y1t)*.40;
	else
	m1=max(y1t)-max(y1t)*.60;
	end;
	
	m1
	P=find(y1t>=m1);
	P1=P;
	P2=[];
	k=length(P1);
	k=k-1;
	i=1;
	while(i<=k)
	high=0;
	j=i;
	while(i<=k)
		if(P1(i+1)-P1(i)>10)
		break;
		end;
		i=i+1;
	end;
	last=P1(j);
	high=y1t(P1(j));
	j=j+1;
	while(j<=i)
		if(y1t(P1(j))>high)
		high=y1t(P1(j));
		last=P1(j);
		end;
		if(j==k)
		break;
		end;
		j=j+1;
	end;
    P2=[P2 last];
	i=i+1;
	break;
	end
	if(k==0)
	P2=[P2 P1(1)];
	end;
	R=y1t(P2);
	P3=P2*4+SOFF(1,m);

	if(P3-15<=SOFF(1,m))
	ton=SOFF(1,m)+3;
	else
    ton= P3-15;
	end;
	if(P3+15>=Cloc(1,m+1))
	tof=Cloc(1,m+1)-3;
	else
	tof=P3+15;
	end;
	if(ton<tof)
	range= [ton:tof];
	else
	range=[tof:ton];
	end;
    n=max(y1(range));
    l=find(y1(range)==n);
	l=l(1);
    pos=range(l);
	if(pos>=Cloc(1,m+1))
	pos=Cloc(1,m+1)-1;
	end;
    Tloc=[Tloc pos];
	end;
	Tamp=y1(Tloc);

%title('Detected T peak in actual Signal')

global rl;
global ra;
global ql;
global qa;
global slr;
global sa;
global cl;
global ca;
global tl;
global ta;
global pl;
global pa;
	for(i=1:1:length(Rloc)-1)
    %subplot(6,1,k);
    rl(i)=Rloc(i);
    ra(i)=Ramp(i);
    ql(i)=Qloc(i);
    qa(i)=Qamp(i);
    slr(i)=Sloc(i);
    sa(i)=Samp(i);
    cl(i)=Cloc(i);
    ca(i)=Camp(i);
    tl(i)=Tloc(i);
    ta(i)=Tamp(i);
    pl(i)=Ploc(i);
    pa(i)=Pamp(i);
	end;

	% P raised

	Ksh=A;
	j=min(Camp);
	if(j<0)
	for(i=1:1:length(A))
	Ksh(i)=Ksh(i)-j;
	end;
	end;
			
%curve fitting
	error=10000;

	double xmin=0.0;
	double val=0.0;
	D=[];
	sd=13;
	for ij=1:+1:(length(Rloc)-1)
	ij
	E=[];
	X=[Cloc(1,ij):Cloc(1,ij+1)+1];
	Y=Ksh(X);

	for i=1:1:length(X)
	if(Y(i)<0)
	Y(i)=-Y(i);
	end;
	end;
	
%% sigma detection

	sigma=[];
	mean=[];
	amplitude=[];
	
%P-peak

	Ploc(ij)-Cloc(ij)
	Pmidamp=Y(Ploc(ij)-Cloc(ij))/2;
	Pmidval=find(Y>=Pmidamp);
	temp = [];
	for pk=1:+1:length(Pmidval)
	if(0<=Pmidval(pk))
	if(QON(ij)-Cloc(ij)>=Pmidval(pk))
	temp= [temp Pmidval(pk)];
	end
	end
	end	
	z=length(temp);
	op= temp(z)-temp(1);
	if(op==0)
	op=1;
	end;
	sigma = [sigma op];
	mean=[mean (Ploc(ij)-Cloc(ij))];
	amplitude=[amplitude Y(Ploc(ij)-Cloc(ij))];

%Q-peak

	Qloc(ij)-Cloc(ij)
	Qmidamp=Y(Qloc(ij)-Cloc(ij))/2;
	Qmidval=find(Y>=Qmidamp);
	temp = [];
	for pk=1:+1:length(Qmidval)
	if(QON(ij)-Cloc(ij)<=Qmidval(pk))
	if(QOF(ij)-Cloc(ij)>=Qmidval(pk))
	temp= [temp Qmidval(pk)];
	end
	end
	end
	z=length(temp);
	op= temp(z)-temp(1);
	if(op==0)
	op=1;
	end;
	sigma = [sigma op];
	mean=[mean (Qloc(ij)-Cloc(ij))];
	amplitude=[amplitude Y(Qloc(ij)-Cloc(ij))];

%R-peak
	Rloc(ij)-Cloc(ij)
	Rmidamp=Y(Rloc(ij)-Cloc(ij))/2;
	Rmidval=find(Y>=Rmidamp);
	temp = [];
	for pk=1:+1:length(Rmidval)
	if(Qloc(ij)-Cloc(ij)<=Rmidval(pk))
	if(Sloc(ij)-Cloc(ij)>=Rmidval(pk))
	temp= [temp Rmidval(pk)];
	end
	end
	end
	z=length(temp);
	op= temp(z)-temp(1);
	if(op==0)
	op=1;
	end;
	sigma = [sigma op];
	mean=[mean (Rloc(ij)-Cloc(ij))];
	amplitude=[amplitude Y(Rloc(ij)-Cloc(ij))];

%S-peak
	Sloc(ij)-Cloc(ij)
	Smidamp=Y(Sloc(ij)-Cloc(ij))/2;
	Smidval=find(Y>=Smidamp);
	temp = [];
	for pk=1:+1:length(Smidval)
	if(SON(ij)-Cloc(ij)<=Smidval(pk))
	if(SOFF(ij)-Cloc(ij)>=Smidval(pk))
	temp= [temp Smidval(pk)];
	end
	end
	end
	z=length(temp);
	op= temp(z)-temp(1);
	if(op==0)
	op=1;
	end;
	sigma = [sigma op];
	mean=[mean (Sloc(ij)-Cloc(ij))];
	amplitude=[amplitude Y(Sloc(ij)-Cloc(ij))];

%T-peak

	Tloc(ij)-Cloc(ij)
	Tmidamp=Y(Tloc(ij)-Cloc(ij))/2;
	Tmidval=find(Y>=Tmidamp);
	temp = [];
	for pk=1:+1:length(Tmidval)
	if(SOFF(ij)-Cloc(ij)<=Tmidval(pk))
	if(Cloc(ij+1)-Cloc(ij)>=Tmidval(pk))
	temp= [temp Tmidval(pk)];
	end
	end
	end
	z=length(temp);
	op= temp(z)-temp(1);
	if(op==0)
	op=1;
	end;
	sigma = [sigma op];
	mean=[mean (Tloc(ij)-Cloc(ij))];
	amplitude=[amplitude Y(Tloc(ij)-Cloc(ij))];
	
	data=zeros(length(X),2);
	for i=1:1:length(X)
	data(i,1)=i;
	data(i,2)=Y(i);
	end;
	
	t = data(:,1);
	y = data(:,2);
	
%%Curve Fitting	
	amplitude
	mean
	sigma
	clear x0
	clear x
	
	x0 = [amplitude(1) mean(1) sigma(1) amplitude(2) mean(2) sigma(2) amplitude(3) mean(3) sigma(3) amplitude(4) mean(4) sigma(4) amplitude(5) mean(5) sigma(5)];
	x(1) = amplitude(1);
	x(2) = mean(1);
	x(3) = sigma(1);
	x(4)=amplitude(2);
	x(5)=mean(2);
	x(6)=sigma(2);
	x(7)=amplitude(3);
	x(8)=mean(3);
	x(9)=sigma(3);
	x(10)=amplitude(4);
	x(11) = mean(4);
	x(12) = sigma(4);
	x(13) = amplitude(5);
	x(14)=mean(5);
	x(15)=sigma(5);

	F = @(x,xdata)x(1)*exp(-((x(2)-xdata).^2)/(2*(x(3).^2))) + x(4)*(exp(-((x(5)-xdata).^2)/(2*(x(6).^2))))+ x(7)*(exp(-((x(8)-xdata).^2)/(2*(x(9).^2))))+ x(10)*(exp(-((x(11)-xdata).^2)/(2*(x(12).^2))))+ x(13)*(exp(-((x(14)-xdata).^2)/(2*(x(15).^2))));
	options=optimset('Display','on','Algorithm','levenberg-marquardt','ScaleProblem','Jacobian','TolFun',1e-12,'TolX',1e-10);
	[x,resnorm,~,exitflag,output] = lsqcurvefit(F,x0,t,y,[],[],options)
                
    F = @(xdata)x(1)*exp(-((x(2)-xdata).^2)/(2*(x(3).^2))) + x(4)*(exp(-((x(5)-xdata).^2)/(2*(x(6).^2))))+ x(7)*(exp(-((x(8)-xdata).^2)/(2*(x(9).^2))))+ x(10)*(exp(-((x(11)-xdata).^2)/(2*(x(12).^2))))+ x(13)*(exp(-((x(14)-xdata).^2)/(2*(x(15).^2))));  
	error1=0;
	for(i=1:+1:length(data))
	error1=error1+abs(y(i)-F(i));
	end;
	error
	if(error1<error)
	xmin=data;
	val=x;
	error=error1;
	error
	end;
    amplitude(1) =x(1);
	mean(1)= x(2);
	sigma(1)= x(3);
	amplitude(2)=x(4);
	mean(2)=x(5);
	sigma(2)=x(6);
	amplitude(3)=x(7);
	mean(3)=x(8);
	sigma(3)=x(9);
	amplitude(4)=x(10);
	mean(4)=x(11);
	sigma(4)=x(12);
	amplitude(5)=x(13);
	mean(5)=x(14);
	sigma(5)=x(15);

	E=[E amplitude];
	E=[E mean];
	E=[E sigma];
	D=vertcat(D,E);

	sd=sd+1;
	end;	

	CR=zeros(15,15);
	for u=1:+1:15
	for v=1:+1:15
	Col1=D(:,u);
	Col2=D(:,v);
	Cor=corrcoef(Col1,Col2);
	CR(u,v)=Cor(1,2);
	end;
	end;
	rd=[];
	for i=2:+1:15
	for j=1:+1:i-1
	rd=[rd CR(i,j)];
	end;
	end;
	
%SVM Training 
	FT1=dlmread('train.txt');
	count=1;
	sam=rd;

	a=sam(1,:);
	grp=[];
	grp(1:8)=1;
	grp(9:99)=2;

	svmStruct = svmtrain(FT1,grp,'rbf_sigma',0.8);
	Group = svmclassify(svmStruct,a);
	if Group==1
	group=1;
	else
	grp(9:37)=1;
	grp(38:99)=2;
	svmStruct = svmtrain(FT1(9:99,:),grp(9:99));
    Group = svmclassify(svmStruct,a);
    if Group==1
        group=2;
	else 
	grp(38:46)=1;
	grp(47:99)=2;
	svmStruct = svmtrain(FT1(38:99,:),grp(38:99));
	Group = svmclassify(svmStruct,a);
		if Group==1
		group=3;
		else
			grp(47:83)=1;
			grp(84:99)=2;
			svmStruct = svmtrain(FT1(47:99,:),grp(47:99));
			Group = svmclassify(svmStruct,a);
				if Group==1
				group=4;
				else
				group=5;
				end;
		
		end;
		end;
	end;
	group
	global gh;
	for i=1:+1:size(Rloc)
    gh(i)=Rloc(i);
	end;

	global  y2;
	y2=y1;
	global data;
	global vg;
	vg=val;
	data =xmin;

	if(group==1)
	set (handles.text2,'string','Normal');
	end;
	if(group==2)
	set (handles.text2,'string','Arythmia');
	end;
	if(group==3)
	set (handles.text2,'string','Atrial Fibrillation');
	end;
	if(group==4)
	set (handles.text2,'string','Supraventricular Arythmia');
	end;
	if(group==5)
	set (handles.text2,'string','ST Change');
	end;
	
	
% --- Executes on button press in pushbutton2.
function pushbutton2_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton2 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
figure(1)
title('Peaks Detected');
global y2;


global rl;
global ra;
global ql;
global qa;
global slr;
global sa;
global cl;
global ca;
global tl;
global ta;
global pl;
global pa;
for(i=1:1:1)
   
    plot(y2), hold on;
    plot(rl(i,:),ra(i,:),'r*'),hold on;
    plot(ql(i,:),qa(i,:),'+'),hold on;
	plot(slr(i,:),sa(i,:),'r^'),hold on;
	plot(cl(i,:),ca(i,:),'ro'),hold on;
	plot(tl(i,:),ta(i,:),'g*'),hold on;
	plot(pl(i,:),pa(i,:),'.'),grid on;
end;
title('Peaks Detected');


% --- Executes on button press in pushbutton3.
function pushbutton3_Callback(hObject, eventdata, handles)
% hObject    handle to pushbutton3 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
figure(2)
title ('Curve Fitting')
global data;
global vg;
F = @(xdata)vg(1)*exp(-((vg(2)-xdata).^2)/(2*(vg(3).^2))) + vg(4)*(exp(-((vg(5)-xdata).^2)/(2*(vg(6).^2))))+ vg(7)*(exp(-((vg(8)-xdata).^2)/(2*(vg(9).^2))))+ vg(10)*(exp(-((vg(11)-xdata).^2)/(2*(vg(12).^2))))+ vg(13)*(exp(-((vg(14)-xdata).^2)/(2*(vg(15).^2))));
title ('Curve Fitting')
hold on
plot(data(:,1),data(:,2),'r');
ezplot(F,[0,300,0,300]);
title ('Curve Fitting')
