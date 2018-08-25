#pragma once
#include <string>
class Convert
{
public:
	virtual string objectToString() = 0;
	virtual void stringToObject(string) = 0;
	~Convert() {}
};