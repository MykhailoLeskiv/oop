#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <string>
#include <time.h>
#include "TravelDocument.h"
using namespace std;
class Ticket : protected TravelDocument
{
public:
	Ticket();
	string passenger;
	string GetDepPlace();
	string GetArrPlace();
	void Display();
	float GetDist();
	void SetValues(float, string, string, string);
	~Ticket();
protected:
	float distance;
	string arrivePlace;
	string departPlace;
};