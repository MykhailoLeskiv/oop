#pragma once
#include "BusTicket.h"
class StudentBusTicket : public /*protected*/ BusTicket
{
public:
	int privilege;
	StudentBusTicket();
	StudentBusTicket(BusTicket&);
	~StudentBusTicket();
};

