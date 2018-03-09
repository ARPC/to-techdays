using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFeaturesOverview
{
    [TestClass]
    public class ExceptionFilterDemo
    {
        public void ExceptionCanBeFilteredByMessage(string name)
        {
            try
            {
                if (name == "Mycroft Dumbhead")
                    throw new Exception($"{nameof(name)} contains a value that is not allowed");
            }
            catch (Exception e) when (e.Message.Contains("is not allowed"))
            {
                Console.WriteLine("Gotcha!");
            }
            catch (Exception e) when (e.Message.Contains("not allowed"))
            {
                Console.WriteLine("Gotcha!");
            }
        }
    }
}
