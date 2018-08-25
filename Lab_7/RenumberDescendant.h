#pragma once
#include "SaveString.h"
class RenumberDescendant : public SaveString
{
public:
	RenumberDescendant();
	RenumberDescendant(SaveString);
	void Renumber(string);
	~RenumberDescendant();
};

