#include "RenumberDescendant.h"
RenumberDescendant::RenumberDescendant()
{
}
void RenumberDescendant::Renumber(string fname)
{
	fstream file;
	file.open(fname, ios_base::out);
	int count = 0;
	while (!(*this).empty())
	{
		file << ++count << ". " << (*this).top() << endl;
		(*this).pop();
	}
	file.close();
}
RenumberDescendant::~RenumberDescendant()
{
}
