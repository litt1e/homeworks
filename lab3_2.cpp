// lab32.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <algorithm>
#include <ctime>

int main()
{
	setlocale(LC_ALL, "russian");
    int n, m, max;
	std::cout << "Введите n" << std::endl;
	std::cin >> n;
	std::cout << "Введите m" << std::endl;
	std::cin >> m;
	int **matrix;
	matrix = new int* [n];
	for (int i = 0; i < n; i++)
	{
		matrix[i] = new int [m];
	}
	int *maxs;
	maxs = new int [n];
	srand(time(0));
	for (int i = 0; i < n; i++)
	{
		for (int k = 0; k < m; k++)
		{
			matrix[i][k] = rand() % 10;
			std::cout << matrix[i][k] << " ";
		}
		std::cout << std::endl;
	}
	for (int i = 0; i < n; i++)
	{
		max = matrix[i][0];
		for (int k = 0; k < m; k++)
		{
			max = matrix[i][k] > max ? matrix[i][k] : max;
			maxs[i] = max;
		}
	}
	for (int i = 0; i < n; i++)
	{
		for (int k = 0; k < m; k++)
		{
			if (maxs[i] == matrix[i][k])
			{
				//std::cout << maxs[i] << " | " << i << std::endl;
				std::sort(matrix[i]+k+1, matrix[i]+m); //sort(matrix[i]);
				break;
			}
		}
	}
	std::cout << "Отсортированная матрица:" << std::endl;
	for (int i = 0; i < n; i++)
	{
		for (int k = 0; k < m; k++)
		{
			std::cout << matrix[i][k] << " ";
		}
		std::cout << std::endl;
	}
	system("pause");
	return 0;
}

