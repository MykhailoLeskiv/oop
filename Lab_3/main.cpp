#include "BusTicket.h"

int main()
{
	BusTicket obj;
	obj.DisplayQuantity();
	BusTicket *objWithParameters = new BusTicket("Petro Petrenko", "Berdychiv", "Zhmerynka", false);
	obj.DisplayQuantity();
	BusTicket *objCopy = new BusTicket((*objWithParameters));
	obj.DisplayQuantity();
	obj.Selling();
	obj.Cancel();
	obj.Selling();
	if (obj.Sale() == true) obj.Display();
	obj.DisplayQuantity();
	obj.SaveDataIntoFile();
	(*objWithParameters).Display();
	(*objCopy).Display();
	delete objCopy;
	obj.DisplayQuantity();
	delete objWithParameters;
	obj.DisplayQuantity();
	//system("pause");
	return 0;
}