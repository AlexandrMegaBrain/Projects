﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TBotBPM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Activated");
            while (true)
            {
                TBot.GetUpdates();
                Thread.Sleep(1);
            }
        }
    }
}
