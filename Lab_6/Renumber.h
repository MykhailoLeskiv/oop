#pragma once
class Renumber
{
public:
	static int counter;
	virtual int currentNumber() = 0;
	virtual int objectsQuantity() = 0;
	~Renumber() {}
};