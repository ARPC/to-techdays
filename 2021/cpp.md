# Good ol' C++
## History
C++ (/ˌsiːˌplʌsˈplʌs/) is a general-purpose, object-oriented programming language developed by Bjarne Stroustrup in 1979.  Initially standardized in 1998, C++ was then amended by the C++03, C++11, C++14, and C++17 standards. The current C++20 standard supersedes these with new features and an enlarged standard library.

Bjarne Stroustrup wanted an efficient and flexible language similar to C that also provided high-level features for program organization, and came up with an "extension of the C with classes".

![The one](https://cacm.acm.org/system/assets/0003/7483/061520_Bjarne-Stroustrup.large.jpg)

## Features

### Compiled
C++ is a compiled programming language. There is no "intermidiate" language, the code is compilied directly into machine code for the target platform.

### Cross-platform (for the most part)
There is a C++ compiler for every platform you can think of, but the compiled code is platform-dependent. The code can be written with cross-plafform compatibility in mind, and compiled for different targets.

### Fast
Since the code is compliled directly to the machine code, the execution time of C++ code is unrivaled by C#, Java and many other general-purpose programming languages. 

### Statically-typed
C++ is a statically-typed language. The types are explicitly declared and are determined and checked at compile time.

### Efficient memory access (pointers)
Memory pointers is a defining feature of C/C++. It makes working with memory as efficient as it can possibly be.

### Intermediate-level language
C++ supports the features of both high-level and low-level programming languages. That is why it is known as an intermediate-level programming language.

### Rich standard library
C++ Standard Template Library (STL) provides a lot of built-in functions and types, such as lists, vectors, hash maps, etc.

### Multi-paradigm
C++ is very feature-ricg and supports different styles of programming. Developers can choose a programming style according to their use case.
 
## Use cases

C++ is widely used in today’s embedded systems, browsers, graphical user interfaces, music players, video games, operating systems, compilers, system drivers, databases, and cloud computing.

### Google
Google has written many of its core systems in C++: Search engine, BigTable, MapReduce, Chromium, Google file system, etc.

### Big tech
Big tech uses C++ at various degrees on the back end services and mobile applications. When you need an efficiency at scale, C++ is an obvous choice.

### Microsoft
Most parts of Microsoft Windows are written in C++. Windows API is written in and intended to be consumed from C++.

### MySQL
MySQL is coded in C++.

### Bloomberg
Bloomberg's systems are written in C++.

### Adobe
Most Adobe applications are written in C++: Adobe Illustrator, Adobe Photoshop, and Adobe Premier.

### Star Wars
C and C++ were used in the programming of the special effects for Star Wars.

## Hello World

    #include <iostream>
    
    int main()
    {
      printf("Hello, World!");
    }

## Primive types and basic syntax
Prerry much the same as C#.

## Header files
C/C++ diffirentiate between type declaration and type definition. Types (including classes and functions) are usually declared in header files (.h) which are included by *.cpp files as needed. 

Each .cpp file is complied independently to its own .obj file. Refences to functions/methods declared in *.h files (but implemented in other modules) are resolved during linking stage of the build.

#### HexFormatter.cpp
    bool FormatAsHex(char *bytes,
        DWORD len,
        char *buffer,
        DWORD bufferLen)
    {
        ...
    	return true;
    }
    
#### HexFormatter.h
    bool FormatAsHex(char *bytes,
        DWORD len,
        char *buffer,
        DWORD bufferLen);

### CppFileReadSample.cpp 

    #include "HexFormatter.h"    
    ...    
    if (!FormatAsHex(buffer, bytesRead, hexBuffer, hexBufferLen))
		{
			printf("FormatAsHex function call failed");
			return -1;
		}
    ...


## Precompiler directives
    // copied from vcruntime.h

    #ifndef NULL
        #ifdef __cplusplus
            #define NULL 0
        #else
            #define NULL ((void *)0)
        #endif
    #endif

## Pointers
    char *lastName = NULL;    // or 0 or nullptr
    char *firstName = "John";
    
    /*
    * array are pointers - a and b have the same type
    * but b point to a memory allocated on the call stack
    */
    int *a = NULL;
    int b[10];

## Memory allocation
C++ does not have garbage collector! If you must allocate memory you must free it.

#### C style (malloc, calloc and free)
    char *buffer = (char *) malloc(2000); // allocate 2000 bytes
    ...    // now do something fun with all that memory
    free (buffer);    //    and deallocate it

#### C++ style (new and delete)
    char buffer[] = new char[2000];    // allocate 2000 bytes
    ...    // now do something fun with all that memory
    delete[] buffer;    //    and deallocate it

### Unique pointers (C++ 11)

## Naming conventions

adjHungarian nNotation vMakes nReading nCode adjDifficult ccBut nMicrosoft advReally adjReally vLoves pIt.

    HANDLE CreateFileA(
      LPCSTR                lpFileName,
      DWORD                 dwDesiredAccess,
      DWORD                 dwShareMode,
      LPSECURITY_ATTRIBUTES lpSecurityAttributes,
      DWORD                 dwCreationDisposition,
      DWORD                 dwFlagsAndAttributes,
      HANDLE                hTemplateFile
    );
    
Modern guidelines recommend:
- **pascalCase** for function and type names
- **snake_case** for variables, namespaces and filenames
- **ALL_CAPS** for preprocessor defines and macros


1. Standard library (vectors, stacks, hash maps, etc)
1. Interesting features
   1. Bitmasks
   1. Unions
   1. Friends of a class, function
     - Unit tests can friend the class under test
     - Factory can friend the class under construction
1. New in version 11, 14 and 19:
   1. Type deduction, auto keyword
   1. Async programming
   1. Anonymous functions (lambdas)
   1. Unique and shared pointers


google.github.io/styleguide/cppguide.html
https://isocpp.github.io/CppCoreGuidelines/CppCoreGuidelines

