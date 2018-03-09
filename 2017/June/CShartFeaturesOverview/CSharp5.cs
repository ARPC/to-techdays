using System;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFeaturesOverview
{
    [TestClass]
    public class CSharp5
    {
        //  C# 6 allows await in catch and finally blocks

        [TestMethod]
        public async Task<string> AwaitDemo(string url, int count)
        {
            // Execution is synchronous here
            var client = new HttpClient();

            // Execution of GetFirstCharactersCountAsync() is yielded to the caller here
            // GetStringAsync returns a Task<string>, which is *awaited*
            string page = await client.GetStringAsync("http://www.dotnetfoundation.org");
            //------------------------------
            // Execution resumes when the client.GetStringAsync task completes,
            // becoming synchronous again.

            if (count > page.Length)
            {
                return page;
            }
            else
            {
                return page.Substring(0, count);
            }
        }

        [TestMethod]
        public void CallerInfoDemo()
        {
            PrintMe("Hello, World!");
        }

        public void PrintMe(string message,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.Out.WriteLine("message: " + message);
            Console.Out.WriteLine("member name: " + memberName);
            Console.Out.WriteLine("source file path: " + sourceFilePath);
            Console.Out.WriteLine("source line number: " + sourceLineNumber);
        }
    }
}
