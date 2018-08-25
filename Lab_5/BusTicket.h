#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <time.h>
#include "Ticket.h"
#include <string>
using namespace std;

class BusTicket : public Ticket
{
public:
	const int BAGGAGE_MAX_WEIGHT = 15;
	BusTicket();
	BusTicket(Ticket&);
	BusTicket(int);
	BusTicket(const BusTicket&);
	void SetAllValuesFromConsole(int bagg);
	void Selling();
	bool Sale();
	void Display();
	int GetNumber();
	int GetBusPlace();
	int GetBaggage();
	bool GetControl();
	bool GetSale();
	float GetPrice();
	~BusTicket();
protected:
	bool control;
	float price;
	unsigned int number;
	unsigned int busPlace;
	unsigned int baggage;
	unsigned int TicketNumbGener();
	bool sale;
};
int SetWeight();
string SetTextValue(string);
float SetDist();