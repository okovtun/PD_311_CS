#include<iostream>
using namespace std;

//https://legacy.cplusplus.com/reference/cstdarg/
int Sum(int a...)
{
	int sum = 0;
	for (int* pa = &a; *pa != int(); pa++)sum += *pa;
	return sum;
}

void main()
{
	cout << Sum(3, 5, 8, 13, 21, 34, 0) << endl;
}