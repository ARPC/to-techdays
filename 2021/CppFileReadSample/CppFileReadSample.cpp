// CppFileReadSample.cpp : This file contains the 'main' function. Program execution begins and ends there.

#include <iostream>

#include <windows.h>
#include <tchar.h>

#include "ErrorHandling.h"
#include "HexFormatter.h"

int main(int argc, char *argv[])
{
	if (argc != 2)
	{
		std::cout << "Expected exactly 1 argument";
		return -1;
	}

	HANDLE hFile = CreateFileA(argv[1],
		GENERIC_READ,
		FILE_SHARE_READ | FILE_SHARE_WRITE,
		NULL,
		OPEN_EXISTING,
		FILE_ATTRIBUTE_NORMAL,
		NULL);

	if (hFile == INVALID_HANDLE_VALUE)
	{
		std::cout << FormatLastError();
		return -1;
	}

	while (true)
	{
		const int bufSize = 16;
		char buffer[bufSize];
		DWORD bytesRead = 0;

		if (!ReadFile(hFile, buffer, bufSize, &bytesRead, NULL))
		{
			printf(FormatLastError());
			return -1;
		}

		if (bytesRead == 0)
		{
			printf("--- End of file ---\n");
			break;
		}

		DWORD hexBufferLen = bytesRead * sizeof(char) * 3 + 1;
		char *hexBuffer = (char *) calloc(hexBufferLen, sizeof(char));

		if (!FormatAsHex(buffer, bytesRead, hexBuffer, hexBufferLen))
		{
			printf("FormatAsHex function call failed");
			return -1;
		}

		printf("%s\n", hexBuffer);
		free(hexBuffer);
	}

	CloseHandle(hFile);

	printf("Bye bye now. Press any key to exit.");
	std::cin.ignore();
	return 0;
}
