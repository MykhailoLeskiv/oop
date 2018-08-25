#include "BusTicket.h"
#include <fstream>
#include <iomanip>
#include <sstream>
#include <CString>

int Renumber::counter = 0;
BusTicket::BusTicket()
{
	passenger = "Anonymus";
	departPlace = "Non";
	arrivePlace = "Non";
	price = 0;
	sequenceNumber = --counter;
	carrierCompany = "ATP Lviv";
	baggage = false;
	number = 0;
	control = false;
	sale = false;
	busPlace = 0;
}
BusTicket::BusTicket(Ticket& obj)
{
	sequenceNumber = --counter;
	carrierCompany = "ATP Lviv";
	passenger = obj.passenger;
	departPlace = obj.GetDepPlace();
	arrivePlace = obj.GetArrPlace();
	price = obj.GetDist() / 1.7;
	number = GetNumber() + counter;
	baggage = false;
	control = false;
	sale = false;
	busPlace = 0;
}
BusTicket::BusTicket(int bagg)
{
	passenger = "Anonymus";
	departPlace = "Non";
	arrivePlace = "Non";
	price = 0;
	sequenceNumber = --counter;
	carrierCompany = "ATP Lviv";
	baggage = bagg;
	busPlace = rand() % 30 + 1;
	number = BusTicket::TicketNumbGener() + sequenceNumber;
	control = false;
	sale = false;
}
BusTicket::BusTicket(const BusTicket &object)
{
	passenger = object.passenger;
	departPlace = object.departPlace;
	arrivePlace = object.arrivePlace;
	price = object.price;
	sequenceNumber = --counter;
	carrierCompany = "ATP Lviv";
	baggage = object.baggage;
	busPlace = object.busPlace;
	number = TicketNumbGener() + sequenceNumber;
	control = object.control;
	sale = object.sale;
}
void BusTicket::SetAllValuesFromConsole(int bagg)
{
	busPlace = rand() % 30 + 1;
	number = BusTicket::TicketNumbGener();
	baggage = bagg;
	if (baggage > BAGGAGE_MAX_WEIGHT) sale = false;
}
void BusTicket::Selling()
{
	if (sale == false)
	{
		sale = true;
		this->SetAllValuesFromConsole(SetWeight());
	}
	if (price < 6) price = 6;
}
bool BusTicket::Sale()
{
	if (sale == true) return true;
	else return false;
}
void BusTicket::Display()
{
	cout << "\nCompany: " << carrierCompany << "\nName: " << passenger << "\nTicket number: " << number << endl;
	cout << "Route: " << departPlace << " - " << arrivePlace << endl << "Price: " << setprecision(4) << price << " grn" << endl;
	cout << "Place number in a bus: " << busPlace << "\nBaggage: " << baggage << "\nSequence: " << sequenceNumber << endl;
}
BusTicket::~BusTicket()
{
}
BusTicket& BusTicket::operator =(Ticket& obj)
{
	carrierCompany = "ATP Lviv";
	passenger = obj.passenger;
	departPlace = obj.GetDepPlace();
	arrivePlace = obj.GetArrPlace();
	price = obj.GetDist() / 1.7;
	number = GetNumber();
	baggage = SetWeight();
	control = false;
	sale = false;
	busPlace = rand() % 30 + 1;
	return *this;
}
int BusTicket::currentNumber()
{
	return sequenceNumber;
}
int BusTicket::objectsQuantity()
{
	return counter;
}
string BusTicket::objectToString()
{
	string obj = "\nCompany: " + carrierCompany + "\nName: " + passenger + "\nTicket number: " + to_string(number) + "\nRoute: " + departPlace + " - " + arrivePlace + "\nPrice: " + to_string(price) + " grn" + "\nPlace number in a bus: " + to_string(busPlace) + "\nBaggage: " + to_string(baggage) + "\n";
	return obj;
}
void BusTicket::stringToObject(string str)
{
	int n = str.length();
	int count = n;
	char **array = new char *[count];
	char * charStr = strtok(_strdup(str.c_str()), " ,.-");
	for (int i = 0; charStr != NULL; i++)
	{
		array[i] = charStr;
		cout << charStr << endl;
		charStr = strtok(NULL, " ,.-");
	}
	passenger = array[0];
	departPlace = array[1];
	arrivePlace = array[2];
	price = atoi(array[3]) / 1.7;
	baggage = atoi(array[4]);
	delete[] array;
}
string SetTextValue(string str)
{
	string pass;
	cout << str;
	getline(cin, pass);
	return pass;
}
int SetWeight()
{
	int baggage;
	cout << "Enter weight of your baggage: ";
	cin >> baggage;
	return baggage;
}
float SetDist()
{
	float baggage;
	cout << "Enter distance: ";
	cin >> baggage;
	return baggage;
}
void Sort(BusTicket* arr, int n)
{
	for (int i = n; i > 0; i--)
	{
		for (int j = 0; j < i - 1; j++)
		{
			if (arr[j] > arr[j + 1])
			{
				BusTicket temp;
				temp = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = temp;
				cout << "True" << endl;
			}
		}
	}
}
bool BusTicket::operator >(BusTicket& obj)
{
	if (this->sequenceNumber > obj.sequenceNumber)
		return true;
	else return false;
}
BusTicket& BusTicket::operator =(BusTicket& object)
{
	sequenceNumber = object.sequenceNumber;
	if (object.carrierCompany != "") carrierCompany = object.carrierCompany;
	if (object.passenger != "") passenger = object.passenger;
	if (object.departPlace != "") departPlace = object.departPlace;
	if (object.arrivePlace != "") arrivePlace = object.arrivePlace;
	price = object.price;
	baggage = object.baggage;
	busPlace = object.busPlace;
	number = object.number;
	control = object.control;
	sale = object.sale;
	return *this;
}
istream& operator >> (istream& is, BusTicket& obj)
{
	string str;
	getline(cin, str);
	obj.stringToObject(str);
	return is;
}
ostream& operator <<(ostream& os, BusTicket& obj)
{
	return os << obj.objectToString() << endl;
}