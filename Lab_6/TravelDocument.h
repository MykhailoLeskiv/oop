#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <string>
#include <time.h>
using namespace std;
class TravelDocument
{
protected:
	int number = TicketNumbGener();
public:
	virtual unsigned int TicketNumbGener()
	{
		time_t t;
		tm *tk;
		time(&t);
		tk = localtime(&t);
		return number = 10000000 * tk->tm_mday + 100000 * (tk->tm_mon + 1) + 1000 * tk->tm_hour + 10 * tk->tm_min;
	}
	int GetNumber();
	string carrierCompany;
	virtual ~TravelDocument() = 0;
};
