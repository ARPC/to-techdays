using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFeaturesOverview
{
    public class AutoPropertyDemo
    {
        public readonly string ThisIsAReadonlyMemeber;

        AutoPropertyDemo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            ThisIsAReadonlyMemeber = "test";
        }

        //  Read-only auto-properties
        public string FirstName { get; }
        public string LastName { get; }

        //  Auto-Property Initializers
        public DateTime DateCreated { get; } = DateTime.Now;
    }
}
