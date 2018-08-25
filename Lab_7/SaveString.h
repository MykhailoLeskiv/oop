#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <stack>
#include <iterator>
#include <string>
#include <fstream>
using namespace std;
class SaveString : public stack <string>
{
public:
	SaveString();
	void Purge();
	void LoadFileToStack(fstream&);
	void Overturning();
	~SaveString();
};

