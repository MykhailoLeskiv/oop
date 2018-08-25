#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include<iostream>
#include<fstream>
#include<Windows.h>

using namespace std;

const int BUF_MIN_SIZE = 30;
struct Stack
{
	char*info;
	Stack*next;
};
void Push(Stack **, fstream&);
void Renumber(Stack *);
char* LoadFileToStack(fstream&);
void ReadFileSimply(fstream&);
void Pop(Stack**);
void ReadFileModify(fstream&);
void Purge(Stack**);
