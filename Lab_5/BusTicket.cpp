#include "BusTicket.h"
#include <fstream>
#include <iomanip>

BusTicket::BusTicket()
{
	baggage = false;
	number = 0;
	control = false;
	sale = false;
	busPlace = 0;
}
BusTicket::BusTicket(Ticket& obj)
{
	passenger = obj.passenger;
	departPlace = obj.GetDepPlace();
	arrivePlace = obj.GetArrPlace();
	price = obj.GetDist() / 1.7;
	baggage = false;
	number = 0;
	control = false;
	sale = false;
	busPlace = 0;
}
BusTicket::BusTicket(int bagg)
{
	baggage = bagg;
	busPlace = rand() % 30 + 1;
	number = BusTicket::TicketNumbGener();
	control = false;
	sale = false;
}
BusTicket::BusTicket(const BusTicket &object)
{
	baggage = object.baggage;
	busPlace = object.busPlace;
	number = TicketNumbGener();
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
	cout << "\nName: " << passenger << "\nTicket number: " << number << endl;
	cout << "Route: " << departPlace << " - " << arrivePlace << endl << "Price: " << setprecision(4) << price << " grn" << endl;
	cout << "Place number in a bus: " << busPlace << "\nBaggage: " << baggage << endl;
}
BusTicket::~BusTicket()
{
}
int BusTicket::GetNumber()
{
	return number;
}
int BusTicket::GetBusPlace()
{
	return busPlace;
}
int BusTicket::GetBaggage()
{
	return baggage;
}
bool BusTicket::GetControl()
{
	return control;
}
bool BusTicket::GetSale()
{
	return sale;
}
float BusTicket::GetPrice()
{
	return price;
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