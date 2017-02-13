using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PT_LabWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fsRead = new FileStream(@"C:\visual.files\input.txt", FileMode.OpenOrCreate, FileAccess.Read);  // input data should be took from this file.
            StreamReader sr = new StreamReader(fsRead);
            FileStream fsWrite = new FileStream(@"C:\visual.files\output.txt", FileMode.OpenOrCreate, FileAccess.Write);  //outpu data should be written to this file 
            StreamWriter sw = new StreamWriter(fsWrite);

            string txt = sr.ReadToEnd();     // read input data
            sr.Close();
            fsRead.Close();   // close the file
            string[] ints = txt.Split(' ');    //save numbers as an array, split works when see " " .
            int res = 9999;   // we took 9999 as an initial result
            bool prime;  //create value prime, which is boolean
            for (int i = 0; i < ints.Length; i++)   // run through all numbers in the array
            {
                int x = int.Parse(ints[i]);    // save as an value x
                prime = true;
                for (int j = 2; j < Math.Sqrt(x); j++)     //check prime or not by running through all numbers 2 - sqrt (that number)
                {
                    if (x % j == 0)     // if number is divided to one of them minimum, this number isn'tprime
                    {
                        prime = false;
                        break;
                    }
                    if (prime == true && res > x)   // if it is prime and less than result, it will be considered as a result
                    {
                        res = x;
                    }
                }
                sw.Write(res);    // write result to the text file
                sw.Close();
                fsWrite.Close();

            }
        }
    }
}