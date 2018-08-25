#include "StudentBusTicket.h"
#include <iomanip>

StudentBusTicket::StudentBusTicket()
{
	privilege = 2;
}
StudentBusTicket::StudentBusTicket(BusTicket& obj)
{
	privilege = 2;
	passenger = obj.passenger;
	//departPlace = obj2.departPlace;
	departPlace = obj.GetDepPlace();
	//departPlace = obj.departPlace;
	arrivePlace = obj.GetArrPlace();
	price = obj.GetPrice() / privilege;
	baggage = obj.GetBaggage();
	number = obj.GetNumber();
	//number = obj.number;
	control = obj.GetControl();
	sale = obj.GetSale();
	busPlace = obj.GetBusPlace();
}
StudentBusTicket::~StudentBusTicket()
{
}
