//GPU version
//person tracking
#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <iomanip>
#include <stdexcept>
#include <opencv2\highgui\highgui.hpp>
#include <opencv2\gpu\gpu.hpp>
#include <opencv2\opencv.hpp>

using namespace std;
using namespace cv;



void hogWorkBegin();
void hogWorkEnd();
string hogWorkFps() ;

void workBegin();
void workEnd();
string workFps() ;

string message() ;
bool running = true;

int64 hog_work_begin;
int64 t=0;
int number;
double hog_work_fps;
int fps = 25;
int64 work_begin;
double work_fps;
void handleKey(char key);


	bool write_video = true;
    double dst_video_fps = 24.;

    bool make_gray = false;

    bool resize_src = false;
    int width = 640;
    int height = 480;

    double scale = 1.05;
    int nlevels = 13;
    int gr_threshold = 8;
    double hit_threshold = 0.25;
    bool hit_threshold_auto = true;

    int win_width = 48;
    int win_stride_width = 8;
    int win_stride_height = 8;

    bool gamma_corr = true;
	bool use_gpu = true;

	


int main()
{
	
 

	cv::gpu::printShortCudaDeviceInfo(cv::gpu::getDevice());
	cout << endl;
	


	cout << "\nControls:\n"
         << "\tESC - exit\n"
         << "\tg - convert image to gray or not\n"
         << "\t3/e - increase/decrease HOG group threshold\n"
         //<< "\t4/r - increase/decrease hit threshold\n"
         << endl;


	//bool running;
	//running = true;
	cv::VideoWriter video_writer;

    Size win_size(win_width, win_width * 2); //(64, 128) or (48, 96)
    Size win_stride(win_stride_width, win_stride_height);


	// Create HOG descriptors and detectors here
    vector<float> detector;
    if (win_size == Size(64, 128)) 
        detector = cv::gpu::HOGDescriptor::getPeopleDetector64x128();
    else
        detector = cv::gpu::HOGDescriptor::getPeopleDetector48x96();

    
	cv::gpu::HOGDescriptor gpu_hog(win_size, Size(16, 16), Size(8, 8), Size(8, 8), 9, 
                                   cv::gpu::HOGDescriptor::DEFAULT_WIN_SIGMA, 0.2, gamma_corr, 
                                   cv::gpu::HOGDescriptor::DEFAULT_NLEVELS);
	gpu_hog.setSVMDetector(detector);

    VideoCapture vc;
    Mat frame;
	vc.set(CV_CAP_PROP_FRAME_WIDTH, 320);
    vc.set(CV_CAP_PROP_FRAME_HEIGHT, 240);
	vc.open("dog1.avi");
        if (!vc.isOpened())
			cout << "can't open video file:" <<endl;
            

	Mat img_aux, img, img_to_show;
    gpu::GpuMat gpu_img;

	vc >> frame;
	while (running && !frame.empty())
	{
		vc >> frame;
        if (frame.empty())
        continue;
		/*if (!video_writer.isOpened())
                {
                    video_writer.open("abc11.avi", CV_FOURCC('x','v','i','d'),24, 
                                      frame.size(), true);
                    if (!video_writer.isOpened())
                        throw std::runtime_error("can't create video writer");
                }



                if (make_gray) cvtColor(frame, img, CV_GRAY2BGR);
                else cvtColor(frame, img, CV_BGRA2BGR);

                video_writer << img;*/
		workBegin();
		// Change format of the image
        if (make_gray) cvtColor(frame, img_aux, CV_BGR2GRAY);
        else if (use_gpu) cvtColor(frame, img_aux, CV_BGR2BGRA);
        else frame.copyTo(img_aux);

		// Resize image
        if (resize_src) resize(img_aux, img, Size(width, height));
        else img = img_aux;
        img_to_show = img;

		gpu_hog.nlevels = nlevels;

		vector<Rect> found;

        // Perform HOG classification
        hogWorkBegin();
        if (use_gpu)
        {
            gpu_img.upload(img);
            gpu_hog.detectMultiScale(gpu_img, found, hit_threshold, win_stride, 
                                        Size(0, 0), scale, gr_threshold);
        }
	
  
    //getch();
		hogWorkEnd();
		
		// Draw positive classified windows
        for (size_t i = 0; i < found.size(); i++)
        {
            Rect r = found[i];
            rectangle(img_to_show, r.tl(), r.br(), CV_RGB(0, 255, 255), 3);
			t=t+1;
			//string strn="a";
			//		ostringstream convert;
			//		convert<<number;
			//      putText(img_to_show, "final count"+convert.str(), Point(5, 25), FONT_HERSHEY_SIMPLEX, 1., Scalar(255, 100, 0), 2);
			/*if(t>90)
				{ 
					string strn="a";
					ostringstream convert;
					convert<<number;
			        putText(img_to_show, convert.str(), Point(5, 25), FONT_HERSHEY_SIMPLEX, 1., Scalar(255, 100, 0), 2);
					//cout<<"hahahaha";
					number++;
				  t=0;
			}
			*/
        }
	
        if (use_gpu)
    //  putText(img_to_show, "Mode: GPU", Point(5, 25), FONT_HERSHEY_SIMPLEX, 1., Scalar(255, 100, 0), 2);
        
      putText(img_to_show, "FPS (total): " + workFps(), Point(5, 105), FONT_HERSHEY_SIMPLEX, 1., Scalar(255, 100, 0), 2);
        imshow("opencv_gpu_hog", img_to_show);

		//if (c.isOpened()) vc >> frame;
	workEnd();
	
	/*if (!video_writer.isOpened())
                {
                    video_writer.open("final_final.avi", CV_FOURCC('x','v','i','d'),64., 
                                      frame.size(), true);
                    if (!video_writer.isOpened())
                        throw std::runtime_error("can't create video writer");
                }

	

                if (make_gray) cvtColor(img_to_show, img, CV_GRAY2BGR);
                else cvtColor(img_to_show, img, CV_BGRA2BGR);

                video_writer << img;
				*/
	handleKey((char)waitKey(3));
	//if (waitKey(10)>=0)
      //  break;
}
	
	//system("pause");
	return 0;
}

void hogWorkBegin() { hog_work_begin = getTickCount(); }

void hogWorkEnd()
{
    int64 delta = getTickCount() - hog_work_begin;
    double freq = getTickFrequency();
    hog_work_fps = freq / delta + fps;
}

string hogWorkFps()
{
    stringstream ss;
    ss << hog_work_fps;
    return ss.str();
}
void workBegin() { work_begin = getTickCount(); }

void workEnd()
{
    int64 delta = getTickCount() - work_begin;
    double freq = getTickFrequency();
    work_fps = freq / delta + fps;
}

string workFps()
{
    stringstream ss;
    ss << work_fps;
    return ss.str();
}


void handleKey(char key)
{
    switch (key)
    {
    case 27:
        running = false;
        break;
    case 'g':
    case 'G':
        make_gray = !make_gray;
        cout << "Convert image to gray: " << (make_gray ? "YES" : "NO") << endl;
        break;
    case '1':
        scale *= 1.05;
        cout << "Scale: " << scale << endl;
        break;
    case 'q':
    case 'Q':
        scale /= 1.05;
        cout << "Scale: " << scale << endl;
        break;
    case '2':
        nlevels++;
        cout << "Levels number: " << nlevels << endl;
        break;
    case 'w':
    case 'W':
        nlevels = max(nlevels - 1, 1);
        cout << "Levels number: " << nlevels << endl;
        break;
    case '3':
        gr_threshold++;
        cout << "Group threshold: " << gr_threshold << endl;
        break;
    case 'e':
    case 'E':
        gr_threshold = max(0, gr_threshold - 1);
        cout << "Group threshold: " << gr_threshold << endl;
        break;
    case '4':
        hit_threshold+=0.25;
        cout << "Hit threshold: " << hit_threshold << endl;
        break;
    case 'r':
    case 'R':
        hit_threshold = max(0.0, hit_threshold - 0.25);
        cout << "Hit threshold: " << hit_threshold << endl;
        break;
    case 'c':
    case 'C':
        gamma_corr = !gamma_corr;
        cout << "Gamma correction: " << gamma_corr << endl;
        break;
    }
}
