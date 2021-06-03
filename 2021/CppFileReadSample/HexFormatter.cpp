#include <Windows.h>

#include "HexFormatter.h"

bool FormatAsHex(char *bytes, DWORD len, char *buffer, DWORD bufferLen)
{
	if (bufferLen < len * sizeof(char) * 3)
		return false;	// output buffer is too short

	for (DWORD i = 0; i < len; ++i)
	{
		char byte = bytes[i];

		buffer[i * sizeof(char) * 3] = byte >> 4 <= 9
			? (byte >> 4) + '0'
			: (byte >> 4) - 10 + 'A';

		buffer[i * sizeof(char) * 3 + 1] = (byte & 0x0F) <= 9
			? (byte & 0x0F) + '0'
			: (byte & 0x0F) - 10 + 'A';

		buffer[i * sizeof(char) * 3 + 2] = ' ';
	}

	return true;
}
