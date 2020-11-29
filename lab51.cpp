// lab51.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <ctime>
#include <iomanip>
#include <iostream>
#include <algorithm>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "russian");
	srand(time(0));
	cout << "В целочисленном массиве X(N) удалить все трехзначиные числа. Удаляемые элементы записывать в новый массив. Вывести сообщение, сколько элементов было удалено." << endl;
	int n;
	cout << "Введите размер массива" << endl;
	cin >> n;
	int *X, *Y, count;
	count = 0;
	X = new int [n];
	Y = new int [n];
	cout << "Массив X(N): ";
	for (int i = 0; i < n; i++)
	{
		X[i] = rand() % 300;
		cout << X[i] << " ";
		if (X[i] >= 100)
		{
			Y[count] = X[i];
			X[i] = 0;
			count++;
		}
	}
	sort(X+0, X+n);
	cout << endl;
	cout << "Массив удаленных чисел:" << " ";
	for (int i = 0; i < count; i ++ )
	{
		cout << Y[i] << " ";
	}
	cout << endl;
	cout << "Массив оставшихся чисел:" << " ";
	for(int i = 0; i < n; i ++)
	{
		if (X[i] != 0) 
		{
			cout << X[i] << " ";
		}
	}
	cout << endl << "Количество удаленных чисел: " << count << endl;
	system("pause");
	return 0;
}

