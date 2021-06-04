# Good ol' C++
## History
C++ (/ˌsiːˌplʌsˈplʌs/) is a general-purpose, object-oriented programming language developed by Bjarne Stroustrup in 1979.  Initially standardized in 1998, C++ was then amended by the C++03, C++11, C++14, and C++17 standards. The current C++20 standard supersedes these with new features and an enlarged standard library.

Bjarne Stroustrup wanted an efficient and flexible language similar to C that also provided high-level features for program organization, and came up with an "extension of the C with classes".

![The one](https://cacm.acm.org/system/assets/0003/7483/061520_Bjarne-Stroustrup.large.jpg)

## Features

### Compiled
C++ is a compiled programming language. There is no "intermediate" language, the code is compilied directly into machine code for the target platform.

### Cross-platform (for the most part)
There is a C++ compiler for every platform you can think of, but the compiled code is platform-dependent. The code can be written with cross-plafform compatibility in mind, and compiled for different targets.

### Fast
Since the code is compliled directly to the machine code, the execution time of C++ code is unrivaled by C#, Java and many other general-purpose programming languages. 

### Statically-typed
C++ is a statically-typed language. The types are explicitly declared and are determined and checked at compile time.

### Efficient memory access (pointers)
Memory pointers is a defining feature of C/C++. It makes working with memory as efficient as it can possibly be.

### Flexibility
C++ supports the features of both high-level and low-level programming languages, from object-oriented programming to comminicating with device drivers.

### Rich standard library
C++ Standard Template Library (STL) provides a lot of built-in functions and types, such as lists, vectors, hash maps, etc.

### Multi-paradigm
C++ is very feature-rich and supports different styles of programming. Developers can choose a programming style according to their use case and preferences.
 
## Use cases

C++ is widely used in today’s embedded systems, browsers, graphical user interfaces, music players, video games, operating systems, compilers, system drivers, databases, and cloud computing.

### Google
Google has written many of its core systems in C++: Search engine, BigTable, MapReduce, Chromium, Google file system, etc.

### Big tech
Big tech generally uses C++ at various degrees in the back-end services and mobile applications. When you need efficiency at scale, C++ is an obvous choice.

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
C/C++ differentiate between declaration and definition. Types (including classes and functions) are declared in `*.h` header files that are "included" in `*.cpp` files using the `#include` preprocessor directive. 

Each `.cpp` file is complied to its own `.obj` file independently. Refences to functions/methods declared but implemented outside of the current module are resolved during linking stage of the build.

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

#### CppFileReadSample.cpp 

    #include "HexFormatter.h"    
    ...    
    if (!FormatAsHex(buffer, bytesRead, hexBuffer, hexBufferLen))
		{
			printf("FormatAsHex function call failed");
			return -1;
		}
    ...


## Preprocessor directives
    // copied from vcruntime.h

    #ifndef NULL
        #ifdef __cplusplus
            #define NULL 0
        #else
            #define NULL ((void *)0)
        #endif
    #endif

## Pointers

A pointer is a variable that stores the memory address of an object. Pointers are used extensively in C/C++ for three main purposes:
- to allocate new objects on the heap,
- to pass functions to other functions
- to iterate over elements in arrays or other data structures.

Raw pointers are the source of many serious programming errors. Since introduction of smart pointers for allocating objects, iterators for traversing data structures, and lambda expressions for passing functions the use of raw pointers is strongly discouraged.

#### Basic syntax
    /* Initialize pointer to zero so that it doesn't store a random address.   
    NULL or 0 is also acceptable. */
    int* p = nullptr;

    int i = 5;
    p = &i;     // Assign pointer to address of object
    int j = *p; // Dereference p to retrieve the value at its address

#### Pointers to objects
    MyClass* mc = new MyClass(); // allocate object on the heap
    mc->print();     // access class member
    delete mc;       // delete object (please don't forget!)

#### Pointer arithmetic and arrays
Pointers and arrays are closely related. When an array is passed by-value to a function, it's passed as a pointer to the first element. The following example demonstrates the following important properties of pointers and arrays:
- the `sizeof` operator returns the total size in bytes of an array
- to determine the number of elements, divide total bytes by the size of one element
- when an array is passed to a function, it decays to a pointer type
- the `sizeof` operator when applied to a pointer returns the pointer size, 4 bytes on x86 or 8 bytes on x64

        void func(int arr[], int length) // the same as void func(int *arr, int length)
        {
            // returns pointer size. not useful here.
            size_t test = sizeof(arr);
        
            for(int i = 0; i < length; ++i)
            {
                printf("%i\n", arr[i]);
            }
        }
        
        int main()
        {        
            int i[5] { 1,2,3,4,5 };
            int j = sizeof(i) / sizeof(i[0]);
            func(i,j);
        }
#### Pointers to functions
    // Declare pointer to any function that...
    
    // ...accepts a string and returns a string
    string (*g)(string a);
    
    // has no return value and no parameters
    void (*x)();
    
    // ...returns an int and takes three parameters
    // of the specified types
    int (*i)(int i, string s, double d);
    
    

## Memory allocation
C++ does not have garbage collector! If you allocate memory you must free it.

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
    
Modern guidelines:
- `PascalCase` for types
- `camelCase` for functions
- `snake_case` for variables, namespaces and filenames
- `ALL_CAPS` for preprocessor defines and macros

## Notable features
#### Bitmasks are used extensively
    // Copied from winnt.h
    
    //
    //  These are the generic rights.
    //
    
    #define GENERIC_READ                     (0x80000000L)
    #define GENERIC_WRITE                    (0x40000000L)
    #define GENERIC_EXECUTE                  (0x20000000L)
    #define GENERIC_ALL                      (0x10000000L)

#### Unions
    union u_color
    { 
    	// first representation (member of union) 
    	struct s_color
        { 
    		unsigned char a, b, g, r;
    	} uc_color;
     
    	// second representation (member of union) 
    	unsigned int i_color; 
    };

#### Friends
    class Distance
    {
        private:
            int meter;
            
            // friend function
            friend int AddFive(Distance);
    
        public:
            Distance() : meter(0) {}
    };
    
    // friend function definition
    int AddFive(Distance d)
    {    
        //accessing private members from the friend function
        d.meter += 5;
        return d.meter;
    }
    
Example: A factory class can be a friend of the class that it's constructing.

## Standard library
Rich standard library contains useful data structures and algorithms.

#### Sequence containers
array  
vector  
deque  
queue  
forward_list   
list  

#### Container adaptors
stack  
queue  
priority_queue  

#### Associative containers
set  
multiset  
map  
multimap  

#### Unordered associative containers
unordered_set   
unordered_multiset   
unordered_map   
unordered_multimap   

## New in versions 11, 14, 17 and 20:
### Type deduction, auto keyword
    auto i = 0;
    auto filename = "/log.txt"
    auto sum = Sum(a, b);
    
    void addAndPrint(auto x, auto y) // only valid starting in C++20
    {
        std::cout << x + y;
    }

### Async programming


### Anonymous functions (lambdas)
Lambdas aren’t functions but an instance of an object called a functor for which the call operator, operator (), is overloaded. The functor object automatically created by the compiler. The main difference between a function and a function object is that a function object is an object and can, therefore, have a state, which is used to capture invocation context.

#### Using overloaded call operator
    int addFunc(int a, int b) { return a + b; }

    int main()
    {        
        struct AddObj
        {
            int operator()(int a, int b) const { return a + b; }
        };
        
        AddObj addObj;
        addObj(3, 4) == addFunc(3, 4);    
    }
   
#### Using lambda expression
    int addFunc(int a, int b) { return a + b; }
    
    int main()
    {
        auto addObj = [](int a, int b){ return a + b; };
        addObj(3, 4) == addFunc(3, 4);        
    }

#### Context binding
Lambda functions can bind their invocation context. Binding allows any variables passed in the surrounding scope to be passed to the lambda. Within the square brackets, we can specify which variables we want the lambda to capture. Bound variables will be stored in the functor object.

The empty brackets indicate that no variables should be bound.

    auto makeLambda(int a)
    {    
        return [a](int b) { return a + b; };
    }
    
### Smart pointers

#### unique_ptr
`std::unique_ptr` is a smart pointer that owns and manages another object through a pointer and disposes of that object when the `unique_ptr` goes out of scope.

The managed object is disposed of, using the associated deleter, when either of the following happens:
1. the managing `unique_ptr` object is destroyed or
1. the managing `unique_ptr` object is assigned another pointer via `operator=` or `reset()`.

        void UseRawPointer()
        {
            // Using a raw pointer -- not recommended.
            Song* pSong = new Song(L"Nothing on You", L"Bruno Mars");
        
            // Use pSong...
        
            // Don't forget to delete!
            delete pSong;
        }
            
        void UseSmartPointer()
        {
            // Declare a smart pointer on stack and pass it the raw pointer.
            unique_ptr<Song> song2(new Song(L"Nothing on You", L"Bruno Mars"));
        
            // Use song2...
            wstring s = song2->duration_;
            //...
        
        } // song2 is deleted automatically here.
        
#### shared_ptr

`std::shared_ptr` shares ownership of the resource. There are two handles: one for the managed resource, and one for the reference counter. By copying an `std::shared_ptr`, the reference count is increased by one. It is decreased by one if the `std::shared_ptr` goes out of scope. If the reference counter becomes the value 0, the C++ runtime automatically releases the resource, since there is no longer an `std::shared_ptr` referencing the resource. The release of the resource occurs exactly when the last `std::shared_ptr` goes out of scope.

    auto sp1 = make_shared<Song>(L"The Beatles", L"Im Happy Just to Dance With You");
    
    shared_ptr<Song> sp2(new Song(L"Lady Gaga", L"Just Dance"));

    // Initialize with copy constructor. Increments ref count.
    auto sp3(sp2);

    // Initialize via assignment. Increments ref count.
    auto sp4 = sp2;


# References

1. google.github.io/styleguide/cppguide.html
https://isocpp.github.io/CppCoreGuidelines/CppCoreGuidelines

