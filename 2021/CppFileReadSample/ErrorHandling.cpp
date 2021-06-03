#include <windows.h>

#include "ErrorHandling.h"

char *FormatLastError()
{
	DWORD code = GetLastError();
	const DWORD bufSize = 1024;
	char *buffer = new char[bufSize];
	
	FormatMessageA(
        FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL,
        code,
        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
        buffer,
        bufSize, 
        NULL);

	return buffer;
}