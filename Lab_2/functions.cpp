#include "functions.h"
void Push(Stack **top, fstream& f)
{
	*top = new Stack;
	(*top)->info = LoadFileToStack(f);
	(*top)->next = NULL;
	Stack *end = *top;
	while (f.good())
	{
		end->next = new Stack;
		end = end->next;
		end->info = LoadFileToStack(f);
		end->next = NULL;
	}
}
void Renumber(Stack *top)
{
	int current_number = 0;
	char* old_str;
	while (top)
	{
		current_number++;
		old_str = top->info;
		top->info = new char[strlen(old_str) + log10(current_number) + 4];
		_itoa(current_number, top->info, 10);
		strcat(top->info, ": ");
		strcat(top->info, old_str);
		delete[]old_str;
		top = top->next;
	}
}
char *LoadFileToStack(fstream& f)
{
	int size_added = 1;
	char *buffer = new char[BUF_MIN_SIZE];
	f.getline(buffer, BUF_MIN_SIZE);
	while (strlen(buffer) == (BUF_MIN_SIZE * size_added - 1) && (buffer[BUF_MIN_SIZE * size_added - 2] != '\r' && buffer[BUF_MIN_SIZE * size_added - 2] != '\n'))
	{
		realloc(buffer, ++size_added * BUF_MIN_SIZE);
		f.getline(buffer + BUF_MIN_SIZE * (size_added - 1) - 1, BUF_MIN_SIZE);
	}
	buffer[strlen(buffer)] = '\0';
	return buffer;
}
void ReadFileSimply(fstream& f)
{
	char *str;
	cout << "Part one:\n";
	while (f.good())
	{
		str = LoadFileToStack(f);
		cout << str << endl;
	}
}
void Pop(Stack** p)
{
	Stack *t;
	t = *p;
	*p = (*p)->next;
	delete t;
}
void ReadFileModify(fstream& f)
{
	Stack *p1 = NULL;
	cout << "Part two:\n";
	f.seekg(ios::beg);
	Push(&p1, f);
	Renumber(p1);
	Purge(&p1);
}
void Purge(Stack** top)
{
	if (NULL != *top)
	{
		Stack *p = *top;
		while (p)
		{
			cout << p->info << endl;
			Pop(&p);
		}
		*top = NULL;
	}
}