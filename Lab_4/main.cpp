#include "BusTicket.h"

int main()
{
	int n;
	cout << "Enter quantity of objects: ";
	cin >> n;
	BusTicket* array = new BusTicket[n];
	for (int i = 0; i < n; i++)
	{
		system("cls");
		cout << "Enter object " << i + 1 << endl;
		array[i].Selling();
	}
	system("cls");
	for (int i = 0; i < n; i++)
	{
		array[i].Display();
	}
	system("pause");
	SortByNames(array, n);
	system("cls");
	for (int i = 0; i < n; i++)
	{
		array[i].Display();
	}
	system("pause");
	return 0;
}