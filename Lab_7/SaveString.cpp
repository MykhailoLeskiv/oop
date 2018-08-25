#include "SaveString.h"

SaveString::SaveString()
{
}
void SaveString::Purge()
{
	while (!(*this).empty())
	{
		cout << ((*this).top()) << endl;
		(*this).pop();
	}
}
void SaveString::Overturning()
{
	SaveString newArr;
	while (!(*this).empty())
	{
		newArr.push((*this).top());
		(*this).pop();
	}
	(*this) = newArr;
}
void SaveString::LoadFileToStack(fstream& f)
{
	f.clear();
	f.seekg(0, ios::beg);
	f.unsetf(ios::skipws);
	string str((istream_iterator<char>(f)), istream_iterator<char>());
	char *cstr = new char[str.length() + 1];
	strcpy(cstr, str.c_str());
	char *strarr = strtok(cstr, "\n");
	while (strarr != NULL)
	{
		(*this).push(strarr);
		strarr = strtok(NULL, "\n");
	}
	delete[] cstr;
}
SaveString::~SaveString()
{
}
