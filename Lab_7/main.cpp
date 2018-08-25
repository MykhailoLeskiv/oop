#include "SaveString.h"
#include "RenumberDescendant.h"
#include <Windows.h>
#include <sstream>

int main()
{
	WIN32_FIND_DATA FindFileData;
	HANDLE find = FindFirstFile("*.txt", &FindFileData);
	if (find != INVALID_HANDLE_VALUE)
	{
		do
		{
			cout << FindFileData.cFileName << "\n";
		} while (FindNextFile(find, &FindFileData) != 0);
		FindClose(find);
	}
	string fname;
	string ofname = "Copy.txt";
	cout << "\nPlease, enter nesessary file: ";
	getline(cin, fname);
	fstream file;
	file.open(fname, ios_base::in);
	if (file.is_open())
	{
		cout << "\nReading a file using stringstream:\n\n";
		if (file)
		{
			stringstream buffer;
			buffer << file.rdbuf();
			cout << buffer.str() << endl;
		}
		cout << "\nReading a file using iterators with overturning:\n\n";
		SaveString arr;
		arr.LoadFileToStack(file);
		arr.Overturning();
		arr.Purge();
		cout << "\nRenumbering and writing into file:\n\n";
		RenumberDescendant heir;
		heir.LoadFileToStack(file);
		heir.Overturning();
		heir.Renumber(ofname);
	}
	else
	{
		printf("Can't found file ");
		return 0;
	}
	file.close();
	//system("pause");
	return 0;
}