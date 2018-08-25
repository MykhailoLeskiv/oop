#include "functions.h"
void Push(Stack **top, FILE *f)
{
	*top = new Stack;
	(*top)->info = LoadFileToStack(f);
	(*top)->next = NULL;
	Stack *end = *top;
	while (!feof(f))
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
char *LoadFileToStack(FILE *f)
{
	int size_added = 1;
	char *buffer = new char[BUF_MIN_SIZE];
	fgets(buffer, BUF_MIN_SIZE, f);
	while (strlen(buffer) == (BUF_MIN_SIZE * size_added - 1) && (buffer[BUF_MIN_SIZE * size_added - 2] != '\r' && buffer[BUF_MIN_SIZE * size_added - 2] != '\n'))
	{
		realloc(buffer, ++size_added * BUF_MIN_SIZE);
		fgets(buffer + BUF_MIN_SIZE * (size_added - 1) - 1, BUF_MIN_SIZE, f);
	}
	buffer[strlen(buffer)] = '\0';
	return buffer;
}
void ReadFileSimply(FILE *f)
{
	char *str;
	printf("Part one:\n");
	while (!feof(f))
	{
		str = LoadFileToStack(f);
		printf("%s", str);
	}
}
void Pop(Stack** p)
{
	Stack *t;
	t = *p;
	*p = (*p)->next;
	delete t;
}
void ReadFileModify(FILE *f)
{
	Stack *p1 = NULL;
	printf("\n\nPart two:\n");
	fseek(f, 0, SEEK_SET);
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
			printf("%s", p->info);
			Pop(&p);
		}
		*top = NULL;
	}
}