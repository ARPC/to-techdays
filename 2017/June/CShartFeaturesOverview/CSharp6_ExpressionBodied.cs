using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFeaturesOverview
{
    public interface ITest
    {
         string FirstName { get; set; }
    }

    public class ExpressionBodiedDemo: ITest
    {
        //  Expression-bodied function members

        public string FirstName
        {
            get => "Melvin" + string.Concat("a", "b");
            set { throw new NotImplementedException(); }
        }

        //public string FIrstName1
        //{
        //    get { return "Melvin"; }
        //}



        public string LastName => "Crabhouse";

        //  string interpolation
        public string FullName => $"{LastName?.Substring(0, 10)}, {FirstName}";

        //  methods
        public string GetFirstName() => FirstName;

        public string GetFirstName1()
        {
            return FirstName;
        }

        public override int GetHashCode() => 123;
    }
}
