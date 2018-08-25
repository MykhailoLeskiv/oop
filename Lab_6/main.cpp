#include "BusTicket.h"
#include "Ticket.h"

int main()
{
	int n;
	cout << "Enter quantity of objects: ";
	cin >> n;
	Renumber::counter = n + 1;
	Ticket* array = new Ticket[n];
	BusTicket* arrayInh = new BusTicket[n];
	for (int i = 0; i < n; i++)
	{
		system("cls");
		cout << "Enter object " << i + 1 << endl;
		getchar();
		array[i].SetValues(SetDist(), SetTextValue("Enter place of arrival: "), SetTextValue("Enter place of departure: "), SetTextValue("Enter name: "));
		arrayInh[i] = array[i];
	}
	system("cls");
	cout << "Quantity of objects: " << arrayInh[0].objectsQuantity() << endl;
	for (int i = 0; i < n; i++)
	{
		cout << arrayInh[i].currentNumber() << endl;
		cout << arrayInh[i] << endl;
	}
	Sort(arrayInh, n);
	for (int i = 0; i < n; i++)
	{
		cout << arrayInh[i].currentNumber() << endl;
		cout << arrayInh[i] << endl;
	}
	delete[] array, arrayInh;
	cout << "String to object demonstration\n\n";
	Ticket obj2;
	BusTicket obj(obj2);
	string str;
	getchar();
	getline(cin, str);
	obj.stringToObject(str);
	obj.Display();
	system("pause");
	return 0;
}