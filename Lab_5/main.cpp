#include "BusTicket.h"
#include "Ticket.h"
#include "StudentBusTicket.h"

int main()
{
	cout << "\t<<<   Inheritance   >>>\n" << endl;
	Ticket objTicket;
	objTicket.SetValues(SetDist(), SetTextValue("Enter place of arrival: "), SetTextValue("Enter place of departure: "), SetTextValue("Enter name: "));
	BusTicket obj(objTicket);
	objTicket.Display();
	obj.Selling();
	if (obj.Sale() == true) obj.Display();
	StudentBusTicket objStud(obj);
	objStud.Display();
	system("pause");
	return 0;
}