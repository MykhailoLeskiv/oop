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
	void SetAllValuesFromConsole(int bagg, string, string, string);
	void SetValuesFromFile();
	void Selling();
	bool Sale();
	void Display();
	void DisplayQuantity();
	void Cancel();
	void SaveDataIntoFile();
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
int SetWeight();
string SetTextValue(string);