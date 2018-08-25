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
}
BusTicket::BusTicket(string pass, string dep, string arr, int bagg)
{
	passenger = pass;
	departPlace = dep;
	arrivePlace = arr;
	baggage = bagg;
	busPlace = rand() % 30 + 1;
	number = BusTicket::TicketNumbGener() + countInstance++;
	control = false;
	sale = false;
}
BusTicket::BusTicket(const BusTicket &object)
{
	if (object.passenger != "") passenger = object.passenger;
	if (object.departPlace != "") departPlace = object.departPlace;
	if (object.arrivePlace != "") arrivePlace = object.arrivePlace;
	baggage = object.baggage;
	busPlace = object.busPlace;
	number = TicketNumbGener() + countInstance++;
	control = object.control;
	sale = object.sale;
	//countInstance++;
}
void BusTicket::SetAllValuesFromConsole()
{
	cout << "Enter values throughout 'enter':\nName\nDeparting place\nArriving place\nBaggage weight (<15 kg)\n\n";
	cin >> (cin, *this);
	busPlace = rand() % 30 + 1;
	number = BusTicket::TicketNumbGener() + countInstance++;
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
		if (choice == 'c') this->SetAllValuesFromConsole();
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
	ifstream file;
	file.open("file.txt", ios_base::in);
	if (file.is_open())
	{
		file >> (file, *this);
		/*getline(file, passenger);
		getline(file, departPlace);
		getline(file, arrivePlace);*/
		busPlace = rand() % 30 + 1;
		number = BusTicket::TicketNumbGener() + countInstance++;
		//file >> baggage;
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
	cout << (cout, *this);
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
		ofstream file;
		file.open("data.txt", ios_base::out);
		if (file.is_open())
		{
			file << (file, *this);
			//file << passenger << endl << departPlace << endl << arrivePlace << endl << busPlace << endl << number << endl << baggage << endl;
		}
		else cout << "Can't create file " << endl;
	}
}
istream& operator >> (istream& is, BusTicket& obj)
{
	getline(is, obj.passenger);
	getline(is, obj.departPlace);
	getline(is, obj.arrivePlace);
	is >> obj.baggage;
	return is;
}
ostream& operator <<(ostream& os, BusTicket& obj)
{
	return os << "\nName: " << obj.passenger << "\nTicket number: " << obj.number << endl << "Route: " << obj.departPlace << " - " << obj.arrivePlace << endl << "Place number in a bus: " << obj.busPlace << "\nBaggage: " << obj.baggage << endl;
}
ifstream& operator >> (ifstream& is, BusTicket& obj)
{
	getline(is, obj.passenger);
	getline(is, obj.departPlace);
	getline(is, obj.arrivePlace);
	is >> obj.baggage;
	return is;
}
ofstream& operator <<(ofstream& os, BusTicket& obj)
{
	os << "Name: " << obj.passenger << "\nTicket number: " << obj.number << endl << "Route: " << obj.departPlace << " - " << obj.arrivePlace << endl << "Place number in a bus: " << obj.busPlace << "\nBaggage: " << obj.baggage << endl;
	return os;
}
bool BusTicket::operator >(BusTicket& obj)
{
	if (this->passenger > obj.passenger)
		return true;
	else return false;
}
bool BusTicket::operator <(BusTicket& obj)
{
	if (this->passenger < obj.passenger)
		return true;
	else return false;
}
BusTicket& BusTicket::operator =(BusTicket& object)
{
	if (object.passenger != "") passenger = object.passenger;
	if (object.departPlace != "") departPlace = object.departPlace;
	if (object.arrivePlace != "") arrivePlace = object.arrivePlace;
	baggage = object.baggage;
	busPlace = object.busPlace;
	number = TicketNumbGener() + countInstance;
	control = object.control;
	sale = object.sale;
	return *this;
}
void SortByNames(BusTicket* arr, int n)
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