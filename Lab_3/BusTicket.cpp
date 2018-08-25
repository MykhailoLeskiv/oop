#include "BusTicket.h"
#include <fstream>

unsigned int BusTicket::countInstance = 0;
BusTicket::BusTicket()
{
	passenger = "Anonymus";
	departPlace = "Non";
	arrivePlace = "Non";
	baggage = false;
	number = 0;
	control = false;
	sale = false;
	busPlace = 0;
	countInstance++;
}
BusTicket::BusTicket(string pass, string dep, string arr, int bagg)
{
	passenger = pass;
	departPlace = dep;
	arrivePlace = arr;
	baggage = bagg;
	busPlace = rand() % 30 + 1;
	number = BusTicket::TicketNumbGener() + countInstance;
	control = false;
	sale = false;
	countInstance++;
}
BusTicket::BusTicket(const BusTicket &object)
{
	if (object.passenger != "") passenger = object.passenger;
	if (object.departPlace != "") departPlace = object.departPlace;
	if (object.arrivePlace != "") arrivePlace = object.arrivePlace;
	baggage = object.baggage;
	busPlace = object.busPlace;
	number = TicketNumbGener() + countInstance;
	control = object.control;
	sale = object.sale;
	countInstance++;
}
void BusTicket::SetAllValuesFromConsole(int bagg, string pass, string dep, string arr)
{
	passenger = pass;
	departPlace = dep;
	arrivePlace = arr;
	busPlace = rand() % 30 + 1;
	number = BusTicket::TicketNumbGener() + countInstance;
	baggage = bagg;
	if (baggage > BAGGAGE_MAX_WEIGHT) sale = false;
}
unsigned int BusTicket::TicketNumbGener()
{
	time_t t;
	tm *tk;
	time(&t);
	tk = localtime(&t);
	return number = 10000000 * tk->tm_mday + 100000 * (tk->tm_mon + 1) + 1000 * tk->tm_hour + 10 * tk->tm_min;
}
void BusTicket::Selling()
{
	if (sale == false)
	{
		sale = true;
		cout << "Read data from console or file? (press 'c' if console, 'f' - if file) ";
		char choice;
		cin >> choice;
		getchar();
		if (choice == 'c') this->SetAllValuesFromConsole(SetWeight(), SetTextValue("Enter place of arrival: "), SetTextValue("Enter place of departure: "), SetTextValue("Enter name: "));
		else if (choice == 'f') this->SetValuesFromFile();
		else
		{
			sale = false;
			return;
		}
	}
}
void BusTicket::SetValuesFromFile()
{
	fstream file;
	file.open("file.txt", ios_base::in);
	if (file.is_open())
	{
		getline(file, passenger);
		getline(file, departPlace);
		getline(file, arrivePlace);
		busPlace = rand() % 30 + 1;
		number = BusTicket::TicketNumbGener() + countInstance;
		file >> baggage;
		if (baggage > BAGGAGE_MAX_WEIGHT) sale = false;
	}
	else
	{
		cout << "Can't found file " << endl;
		return;
	}
	file.close();
}
bool BusTicket::Sale()
{
	if (sale == true) return true;
	else return false;
}
void BusTicket::Display()
{
	cout << "\nName: " << passenger << "\nTicket number: " << number << endl;
	cout << "Route: " << departPlace << " - " << arrivePlace << endl;
	cout << "Place number in a bus: " << busPlace << "\nBaggage: " << baggage << endl;
}
BusTicket::~BusTicket()
{
	countInstance--;
}
void BusTicket::DisplayQuantity()
{
	cout << "There are " << countInstance << " instances of class" << endl;
}
void BusTicket::Cancel()
{
	cout << "Do you want to cancel a ticket?";
	char choice;
	cin >> choice;
	if (choice == 'y')
	{
		passenger = "";
		departPlace = "";
		arrivePlace = "";
		baggage = false;
		number = 0;
		control = false;
		sale = false;
		busPlace = 0;
	}
}
void BusTicket::SaveDataIntoFile()
{
	cout << "Do you want to save data into file? ";
	char choice;
	cin >> choice;
	if (choice == 'y')
	{
		fstream file;
		file.open("data.txt", ios_base::out);
		if (file.is_open())
		{
			file << passenger << endl << departPlace << endl << arrivePlace << endl << busPlace << endl << number << endl << baggage << endl;
		}
		else cout << "Can't create file " << endl;
	}
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