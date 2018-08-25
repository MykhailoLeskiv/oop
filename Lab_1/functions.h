#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include<iostream>
#include<stdio.h>
#include<string.h>

const int BUF_MIN_SIZE = 30;
struct Stack
{
	char*info;
	Stack*next;
};
void Push(Stack **, FILE *);
void Renumber(Stack *);
char* LoadFileToStack(FILE *);
void ReadFileSimply(FILE *);
void Pop(Stack**);
void ReadFileModify(FILE *);
void Purge(Stack**);
