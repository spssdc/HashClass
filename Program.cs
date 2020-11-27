using System;

namespace HashClass
{
    class HashTable
    {
        private const int size = 20;
        private int items = 0;
        private string[] table = new string[50];

        public HashTable()
        {
            Console.WriteLine("Instantiating table now...\n");
            for (int i = 0; i < size; i++)
            {
                table[i] = "";
            }
        }

        public bool addItem(string key)
        {
            int address;

            if (items == 50)
            {
                return (false);
            }
            else
            {
                address = hashFunction(key);
                while (table[address] != "") // deal with collision; linear probing
                {
                    Console.WriteLine("@ {0} Collision processing {1}", address, key);
                    address += 1 % size;
                }
                table[address] = key;
                return (true);
            }

        }

        public void dumpTable()
        {
            Console.WriteLine("Table Dump");
            for (int i = 0; i < size; i++)
            {
                if (table[i] != "")
                {
                    Console.WriteLine("{0} {1}", i, table[i]);
                }
            }
        }

        // Function to generate hash value from a string
        private static int hashFunction(String s)
        {
            const int poly = 37; // prime values in polynomial calculation give a better distribution
            int total = 0;

            // loop through each character c in the string s
            for (int i = 0; i < s.Length; i++)
            {
                // s[i] is the next character; a is the polynomial; r the result 
                total += poly * total + (int)s[i]; // Cascaded evaluation of the polynoimal (Horner's Rule trick)
            }

            // c# has no int overflow, so deal with error case
            total = total % size;
            if (total < 0)
            {
                total += size;
            }

            return (total);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hash Table class test!\n");

            HashTable myTable = new HashTable();

            // Values of the keys stored 
            string[] myKeys = new string[] { "Florida", "Alabama", "Delaware", "California", "Georgia", "Texas", "London", "York", "Hull", "Brighton" };

            Console.WriteLine("Inserting keys into table...\n");
            // insert keys into myTable
            for (int i = 0; i < myKeys.Length; i++)
            {
                myTable.addItem(myKeys[i]);
            }

            // output table contents
            myTable.dumpTable();

        }
    }
}
