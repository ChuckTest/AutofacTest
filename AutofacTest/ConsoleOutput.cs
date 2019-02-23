using System;

namespace AutofacTest
{
    /// <summary>
    /// This implementation of the IOutput interface
    /// is actually how we write to the Console. Technically
    /// we could also implement IOutput to write to Debug
    /// or Trace... or anywhere else.
    /// </summary>
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
