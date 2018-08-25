#include "Ticket.h"
#include <iostream>
Ticket::Ticket()
{
	passenger = "Anonymus";
	departPlace = "Non";
	arrivePlace = "Non";
}
void Ticket::SetValues(float dist, string arr, string dep, string pass)
{
	passenger = pass;
	departPlace = dep;
	arrivePlace = arr;
	distance = dist;
}
void Ticket::Display()
{
	std::cout << "\nPassenger: " << passenger << "\nRoute: " << departPlace << " - " << arrivePlace << "\nDistance: " << distance << std::endl;
}
string Ticket::GetDepPlace()
{
	return departPlace;
}
string Ticket::GetArrPlace()
{
	return arrivePlace;
}
float Ticket::GetDist()
{
	return distance;
}
Ticket::~Ticket() {}