
//WRITE THIS ON COMMAND LINE--------------------------->g++ -lglut answer.cpp
#include <iostream>
#include <GL/gl.h>
#include <GL/glut.h>
#include<vector>
#include <math.h>
using namespace std;
int m=0;
vector < float > C(3);
float x,y,n,c;
int i,j,k,I;
vector < pair < float, float > > v;
/////FUNCTION FOR MATRIX MULTILICATION////////
vector < float > mul(float A[3][3],float B[3][1])
{
	vector < float > D(3);
	for(I=0;I<3;I++){
		for(j=0;j<1;j++){
			c=0;
			for(k=0;k<3;k++){
				c+=A[I][k]*B[k][j];
			}
			D[I]=c;
		}
	}
	return D;
}

//FUNCTION FOR TRANSOFRMATION OF MATRIX
void  Transform_Rotate(vector < pair < float, float > > &v,float theta,int a,int b,float r,float g,float bl )
{
	
	vector < pair < float, float > > v1(n);
	glBegin(GL_POLYGON);
	for(i=0;i<v.size();i++){
		glColor3f(r,g,bl);
		float A[3][3]={{1,0,-a},{0,1,-b},{0,0,1}};
		float B[3][1]={{v[i].first},{v[i].second},{1}};
		C=mul(A,B);
		float D[3][3]={{cos(theta),-sin(theta),0},{sin(theta),cos(theta),0},{0,0,1}};
		B[0][0]=C[0];B[1][0]=C[1];B[2][0]=C[2];
		C=mul(D,B);
		float E[3][3]={{1,0,a},{0,1,b},{0,0,1}};
		B[0][0]=C[0];B[1][0]=C[1];B[2][0]=C[2];
		C=mul(E,B);
		glVertex2f(C[0],C[1]);
	}
	glEnd();
	glBegin(GL_LINE_LOOP);
	for(i=0;i<v.size();i++){
		glColor3f(0,0,0);
		float A[3][3]={{1,0,-a},{0,1,-b},{0,0,1}};
		float B[3][1]={{v[i].first},{v[i].second},{1}};
		C=mul(A,B);
		float D[3][3]={{cos(theta),-sin(theta),0},{sin(theta),cos(theta),0},{0,0,1}};
		B[0][0]=C[0];B[1][0]=C[1];B[2][0]=C[2];
		C=mul(D,B);
		float E[3][3]={{1,0,a},{0,1,b},{0,0,1}};
		B[0][0]=C[0];B[1][0]=C[1];B[2][0]=C[2];
		C=mul(E,B);
		glVertex2f(C[0],C[1]);
	}
	glEnd();
}
////FUNCTION FOR CREATING CIRCLE//////////
void circle(int x,int y,int R,float r,float g,float b)
{
	int i;
	float angle;
	glBegin(GL_POLYGON);
		glColor3f(r,g,b);
		for(i=0;i<1000;i++){
			angle=(2*3.14*i)/1000;
			glVertex3f(x+R*cos(angle),y+R*sin(angle),0);
		}
	glEnd();
}
//FUNCTION FOR CREATING RECTANGLE
void rect(int cx,int cy,int w,int h,float r,float g,float b,int y)
{
	v.push_back(make_pair(cx+w,cy-h));
	v.push_back(make_pair(cx+w,cy+h));
	v.push_back(make_pair(cx-w,cy+h));
	v.push_back(make_pair(cx-w,cy-h));
	if(y==0){
	glBegin(GL_POLYGON);
		glColor3f(r,g,b);
		glVertex2f(cx+w,cy-h);
		glVertex2f(cx+w,cy+h);
		glVertex2f(cx-w,cy+h);
		glVertex2f(cx-w,cy-h);
	glEnd();
	glBegin(GL_LINE_LOOP);
		glColor3f(0,0,0);
		glVertex2f(cx+w,cy-h);
		glVertex2f(cx+w,cy+h);
		glVertex2f(cx-w,cy+h);
		glVertex2f(cx-w,cy-h);
	glEnd();
	glFlush();
	}
}		
//FUNCTION THAT DISPLAY THE ANIMATION
void display(void)
{
	if(m==1)return;
	int i,j,cy=0;
	double theta=0;
	while(theta<3.14/2.75){
		glClearColor (1.0, 1.0, 1.0, 1.0);
		glClear (GL_COLOR_BUFFER_BIT);
		glColor3f (0.0, 0.0, 0.0);
		rect(0,0,1000,10,0,0,0,0);
		v.clear();
		rect(10,100,10,90,0,0,.7,cy);
		Transform_Rotate(v,theta,0,0,0,0,.7);
		v.clear();
		rect(50,190,50,10,0,0,.7,cy);
		Transform_Rotate(v,theta,0,0,0,0,.7);
		v.clear();
		rect(110,190,10,180,0,0,.7,cy);
		Transform_Rotate(v,theta,0,0,0,0,.7);
		v.clear();
		circle(-420,260,30,1,1,0);
		circle(-380,260,30,1,0,0);
		rect(-210,100,10,90,.4,0,0,0);
		rect(-590,100,10,90,.4,0,0,0);
		rect(-400,190,200,10,.4,0,0,0);
		rect(-400,225,50,25,0,1,0,0);
		for(i=0;i<1000;i++)
			for(j=0;j<10000;j++){ }
		theta=theta+.01;
		cy++;
	}
	double X=1,k=0.004,l=3.55;
	while(X<350&&theta<3.14/2.5){
		glClearColor (1.0, 1.0, 1.0, 1.0);
		glClear (GL_COLOR_BUFFER_BIT);
		glColor3f (0.0, 0.0, 0.0);
		rect(0,0,1000,10,0,0,0,0);
		v.clear();
		rect(10,100,10,90,0,0,.7,cy);
		Transform_Rotate(v,theta,0,0,0,0,.7 );
		v.clear();
		rect(50,190,50,10,0,0,.7,cy);
		Transform_Rotate(v,theta,0,0,0,0,.7 );
		v.clear();
		rect(110,190,10,180,0,0,.7,cy);
		Transform_Rotate(v,theta,0,0,0,0,.7 );
		v.clear();
		circle(-420-X,260,30,1,1,0);
		circle(-380-X,260,30,1,0,0);
		rect(-210-X,100,10,90,.4,0,0,0);
		rect(-590-X,100,10,90,.4,0,0,0);
		rect(-400-X,190,200,10,.4,0,0,0);
		rect(-400-X,225,50,25,0,1,0,0);
		v.clear();
		for(i=0;i<5000;i++)
			for(j=0;j<10000;j++){	}
		theta=theta+k;
		k-=0.000075;
		cout<<k<<endl;
		X+=l;
		l-=.075;
		cout<<l<<endl;
		cy++;
	}
	m++;
}
int  main(int argc, char** argv)
{
	glutInit(&argc, argv);
     	glutInitDisplayMode (GLUT_SINGLE | GLUT_RGB);
     	glutInitWindowSize (700,700);
     	glutInitWindowPosition (50, 50);
     	glutCreateWindow ("Polygon Display");
     	glutDisplayFunc(display);
	glOrtho(-1000.0, 1000.0, -1000.0, 1000.0, -700.0, 700.0);
     	glutMainLoop();
     	return 0;       
}
