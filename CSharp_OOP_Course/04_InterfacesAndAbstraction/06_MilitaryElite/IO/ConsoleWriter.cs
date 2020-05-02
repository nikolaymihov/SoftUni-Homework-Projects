﻿using System;

namespace MilitaryElite
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string msg)
        {
            Console.Write(msg);
        }

        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
