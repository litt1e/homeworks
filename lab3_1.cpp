#include <iostream>
#include "iomanip"
#include <algorithm>
#include <ctime>

using namespace std;

int main() {
	double x[100];
	double y[100];
	srand(time(0));
	int w = 10;
	for (int i = 0; i < 45; i++) { cout << "_";}
	cout << endl;
	cout << "|" << setw(w) << "x1" << "|"<< setw(w+1) << "y1" "|"<< setw(w) << "x2" << "|"<< setw(w) << "y2" << "|" << endl;
	for (int i = 0; i < 45; i++) { cout << "_";}
	cout << endl;
	for(int i = 0; i < 100; i++)
	{
		x[i] = (-99 + (((float) rand()) / (float) RAND_MAX) * 199);
		y[i] = (-99 + (((float) rand()) / (float) RAND_MAX) * 199);
		cout << "|" << setw(w) << setprecision(3) << fixed << x[i] << "|" << setw(w) << y[i] << "|";
		if ((x[i] > 0) && (y[i] < 0))
		{
			y[i] *= y[i];
		}
		else if ((x[i] < 0) && (y[i] > 0 ))
		{
			x[i] *= x[i];
		}
		else if ((x[i] < 0) && (y[i] < 0 ))
		{
			x[i] += 0.5;
			y[i] += 0.5;
		}
		else
		{
			double avg = (x[i] + y[i]) / 2;
			x[i] = avg;
			y[i] = avg;
		}
		cout << setw(w) << setprecision(3) << fixed << x[i] << "|" << setw(w) << y[i] << "|";
		cout << endl;
	}
}
