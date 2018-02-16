using System;

namespace dotnetcore2_docker_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}. Bye now.");
        }
    }
}
