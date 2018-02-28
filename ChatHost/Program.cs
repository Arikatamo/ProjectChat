﻿using ChatService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Service)))
            {
                host.Open();
                Console.WriteLine("Host starter");
                Console.ReadKey();
            }   
        }
    }
}
