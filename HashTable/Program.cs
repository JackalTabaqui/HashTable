using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable obj = new HashTable(345);
            //DictionaryBT obj = new DictionaryBT();
            obj.Add(234, "354");
            obj.Add(456, "dododod");
            obj.Delete(234);
            obj.Search(456);
            Console.ReadKey();
        }
    }
}
