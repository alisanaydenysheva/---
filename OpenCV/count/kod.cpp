#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <string>
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <opencv2/imgproc/imgproc.hpp>
//#include "Source.h"

using namespace cv;
using namespace std;
Mat img;
string j() {
	setlocale(LC_ALL, "Russian");
	string filename;//pupp
	cout << "введите имя файла" << endl;
	cin >> filename;


	while (filename != "puppy.jpg")
	{
		cout << "Попробуй занаво" << endl;
		cin >> filename;
	}


	cout << "Открыт файл ";
	cout << filename << endl;
	return filename;
}
int main()

{
	string filename = j();
	Mat img = imread(filename, 1);
	const char* source_window = "Исходное изображение";
	namedWindow(source_window, WINDOW_AUTOSIZE);
	imshow(source_window, img);
	Mat src_gray;
	Mat _img;
	Mat canny_output;

	cvtColor(img, src_gray, COLOR_RGB2GRAY); // перводит изображение в черно-белое
	blur(src_gray, src_gray, Size(3, 3)); //размывает изображение
	double otsu_thresh_val = threshold(src_gray, _img, 0, 255, THRESH_BINARY | THRESH_OTSU); //определяет яркость серого изображения
	//double high_thresh_val = otsu_thresh_val, lower_thresh_val = otsu_thresh_val * 0.5; //определяет максимумы и минимумы контуров
	double high_thresh_val = 200, lower_thresh_val = 200 * 0.5;//меняет кол-во контуров
	cout << "Пароговая фильтрация" << otsu_thresh_val; //106
	Canny(src_gray, canny_output, lower_thresh_val, high_thresh_val, 3); // трехканальное изображение
	const char* source_grey_window = "Серое изображение";
	namedWindow(source_grey_window, WINDOW_AUTOSIZE);
	imshow(source_grey_window, canny_output);
	imwrite("canny_output.jpg", canny_output);  //сохраняет и открывает обработанное изображение

	RNG rng(12345);
	vector<vector<Point>>contours;
	vector<Vec4i>hierarchy;
	findContours(canny_output, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE, Point(0, 0));
	vector<Moments> mu(contours.size());
	for (int i = 0; i < contours.size(); i++)
	{
		mu[i] = moments(contours[i], false);//создали вектор моментов для контуров
	}
	vector<Point2f>mc(contours.size());
	for (int i = 0; i < contours.size(); i++)
	{
		mc[i] = Point2f(mu[i].m10 / mu[i].m00, mu[i].m01 / mu[i].m00);// нашли центр масс


	}
	for (int i = 0; i < contours.size(); i++)
	{
		printf("Контур № %d: центр мас - x= %2f y=%2f; длина-%2f /n", i, mu[i].m10 / mu[i].m00, mu[i].m01 / mu[i].m00, arcLength(contours[i], true)); //вывели координаты центра масс и длину контура
	}
	Mat drawing = Mat::zeros(canny_output.size(), CV_8UC3);
	for (int i = 0; i < contours.size(); i++)

	{
		cvtColor(img, src_gray, COLOR_RGB2GRAY);// в серый
		imwrite("cvtColor.jpg", src_gray);
		blur(src_gray, src_gray, Size(10, 10));// в размытый серый
		imwrite("blur.jpg", src_gray);
		Scalar color = Scalar(rng.uniform(0, 255), rng.uniform(200, 255), rng.uniform(200, 255)); //диапазон цветов контура
		drawContours(drawing, contours, i, color, 2, 8, hierarchy, 0, Point());
		circle(drawing, mc[i], 4, color, -1, 5, 0);

	}
	namedWindow("Контуры", WINDOW_AUTOSIZE);
	imwrite("беложёлтый.jpg", drawing);//сохранение картинки
	imshow("Контуры", drawing);
	waitKey(0);
	return(0);
}
