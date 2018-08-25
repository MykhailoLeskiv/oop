#define _CRT_SECURE_NO_WARNINGS
#include "functions.h"
int main()
{
	WIN32_FIND_DATA FindFileData;
	HANDLE find = FindFirstFile("*.txt", &FindFileData);
	if (find != INVALID_HANDLE_VALUE)
	{
		do
		{
			cout << FindFileData.cFileName << "\n";
		} 
		while (FindNextFile(find, &FindFileData) != 0);
		FindClose(find);
	}
	char* fname = new char[BUF_MIN_SIZE];
	cout << "Please, enter nesessary file: ";
	cin.getline(fname, BUF_MIN_SIZE);
	fstream file;
	file.open(fname, ios_base::in);
	if (file.is_open())
	{
		ReadFileSimply(file);
		ReadFileModify(file);
	}
	else
	{
		printf("Can't found file ");
		return 0;
	}
	file.close();
	return 0;
}