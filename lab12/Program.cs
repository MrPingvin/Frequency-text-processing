using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] config = { '.', ',', '!', '?', '—', '-' };

            File_work file_Work = new File_work(@"name.txt", config);
           
            file_Work.Print_all_values();

            file_Work.Print_max_value();
            file_Work.Statistic_word();
            Console.ReadKey();
        }
    }
}

