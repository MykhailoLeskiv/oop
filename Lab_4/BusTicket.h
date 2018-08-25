#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <time.h>
#include <string>
using namespace std;

class BusTicket
{
public:
	const int BAGGAGE_MAX_WEIGHT = 15;
	string passenger;
	BusTicket();
	BusTicket(string, string, string, int);
	BusTicket(const BusTicket&);
	void SetAllValuesFromConsole();
	void SetValuesFromFile();
	void Selling();
	bool Sale();
	void Display();
	void DisplayQuantity();
	void Cancel();
	void SaveDataIntoFile();
	friend istream& operator >> (istream&, BusTicket&);
	friend ostream& operator <<(ostream&, BusTicket&);
	friend ifstream& operator >> (ifstream& is, BusTicket& obj);
	friend ofstream& operator <<(ofstream& os, BusTicket& obj);
	bool BusTicket::operator >(BusTicket&);
	bool BusTicket::operator <(BusTicket&);
	BusTicket& BusTicket::operator =(BusTicket&);
	~BusTicket();
private:
	string arrivePlace;
	string departPlace;
	unsigned int number;
	unsigned int busPlace;
	unsigned int baggage;
	unsigned int TicketNumbGener();
	bool sale;
	static unsigned int countInstance;
protected:
	bool control;
};
void SortByNames(BusTicket*, int);