#include "stdafx.h"
#include <iostream>
#include <cmath>
#include <time.h>
 
using namespace std;
 
bool isprime(int num) 
{
	for ( int i = 2; i <= pow(num, 0.5); i++) {
		if (num % i == 0) {
			return false;
		} else if ((num == 0) || (num == 1) || (num == 2) || (num == 3)) {
			return true;
		}
	}
	return true;
}
 
bool lineisprime(int nums[], int length)
{
	int res = 0;
	for (int i = 0; i < length; i++)
	{
		if (isprime(nums[i]))
		{
			res++;
		}
	}
	if (res == length) 
	{
		return true;
	} else if (res == 0) {
		return false;
	}
}
 
bool onlyone(int nums[], int length)
{
	int count = 0;
	for (int i = 0; i < length; i++)
	{
		if (count == 2) {
			break;
		} else if (isprime(nums[i])) {
			count++;
		}
	}
	if (count == 1) {
		return true;
	} else {
		return false;
	}
}
 
bool onlytwo(int nums[], int length)
{
	int count = 0;
	for (int i = 0; i < length; i++)
	{
		if (count == 3) {
			break;
		} else if (isprime(nums[i])) {
			count++;
		}
	}
	if (count == 2) {
		return true;
	} else {
		return false;
	}
}
 
int main(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "russian");
	int n;
	n = 5;
	cout << "Введите размер матрицы" << endl;
    cin >> n;
    int matrix[100][100];
	int result[100][100];
	srand(time(0));
	cout << "Содержимое второй таблицы:\nНомера рядов первой таблицы\n1 строка - нет простых чисел\n2 строка - одно простое число\n3 строка - два простых числа." << endl;
	cout << "Первая таблица" << endl;
    for (int i = 0; i < n; i++)
    {
        for (int k = 0; k < n; k++)
        {
            matrix[i][k] = rand() % 10;
            std::cout << matrix[i][k] << " | ";
        }
        std::cout << std::endl;
    }
    for (int i = 0; i < n; i++)
    {
 
		if (!lineisprime(matrix[i], n)) 
		{
				result[0][i] = i+1;
		} 
		else if (onlytwo(matrix[i], n)) 
		{
			result[2][i] = i+1;
		} 
		else if (onlyone(matrix[i], n)) 
		{
			result[1][i] = i+1;
		}
 
    }
	cout << "Вторая таблица" << endl;
    for (int i = 0; i < 3; i++)
    {
        for (int k = 0; k < n; k++)
		{
			if (result[i][k] == -858993460) 
			{
				cout << "  | ";
			} 
			else 
			{
			cout << result[i][k] << " | ";
			}
		}
		cout << endl;
	}
	system("pause");
	return 0;
}
