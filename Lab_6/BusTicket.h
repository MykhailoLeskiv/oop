#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "Ticket.h"
#include "Convert.h"
#include "Renumber.h"
#include <string>
using namespace std;

class BusTicket : protected Ticket, Convert, Renumber
{
public:
	const int BAGGAGE_MAX_WEIGHT = 15;
	BusTicket();
	BusTicket(Ticket&);
	BusTicket(int);
	BusTicket(const BusTicket&);
	int sequenceNumber;
	void SetAllValuesFromConsole(int bagg);
	void Selling();
	bool Sale();
	void Display();
	BusTicket& BusTicket::operator =(Ticket&);
	bool BusTicket::operator >(BusTicket&);
	BusTicket& BusTicket::operator =(BusTicket&);
	friend istream& operator >> (istream&, BusTicket&);
	friend ostream& operator <<(ostream&, BusTicket&);
	int currentNumber();
	int objectsQuantity();
	string objectToString();
	void stringToObject(string);
	~BusTicket();
protected:
	bool control;
	float price;
	unsigned int number;
	unsigned int busPlace;
	unsigned int baggage;
	bool sale;
};
int SetWeight();
string SetTextValue(string);
float SetDist();
void Sort(BusTicket*, int);