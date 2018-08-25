#define _CRT_SECURE_NO_WARNINGS
#include "functions.h"
int main()
{
	char*fname = "Text.txt";
	FILE *file;
	file = fopen(fname, "r");
	if (NULL == file)
	{
		printf("Can't found file ");
		return 0;
	}
	ReadFileSimply(file);
	ReadFileModify(file);
	fclose(file);
	return 0;
}