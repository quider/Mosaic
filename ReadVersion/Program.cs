﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReadVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            var dllForVersionExamination = args[0];
            Assembly assembly = Assembly.LoadFile(dllForVersionExamination);
            var version = assembly.GetName().Version;
            if(args[1] == "vo"){
                Console.WriteLine(version.ToString());
            }else {

            Console.WriteLine("Version: "+version.ToString());
            }
        }
    }
}
