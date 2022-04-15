using System;
using System.Diagnostics;
using System.IO;

namespace solve

{
    public class Shaker
    {
        // elements exchange method
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        // sort by shuffle
        public int[] ShakerSort(int[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                // pass from left to right
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                // pass from right to left
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                // if there were no exchanges, exit
                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }

    }
    public class Bubby
    {
        // elements exchange method
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        // sort by bubble
        public int[] BubbleSort(int[] array)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }

    }
    public  class Randy
    {
        // method for checking array ordering
        static bool IsSorted(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > a[i + 1])
                    return false;
            }

            return true;
        }

        // shuffle array elements
        static int[] RandomPermutation(int[] a)
        {
            Random random = new Random();
            var n = a.Length;
            while (n > 1)
            {
                n--;
                var i = random.Next(n + 1);
                (a[i], a[n]) = (a[n], a[i]);
            }

            return a;
        }

        // random sort
        public  int[] BogoSort(int[] a)

        {
            while (!IsSorted(a))
            {
                a = RandomPermutation(a);
            }
            clock.Stop();

            return a;
        }

        
    }

    static class Program
    {
        static void Main(string[] args)
        {   
            // Read the data.txt textfile.
            var data = System.IO.File.ReadAllText(@"/Users/biqontie/RiderProjects/solve/text.txt");

            // Create a new List of int[]
            var arrays = new List<int[]> ();

            // Split data file content into lines
            var lines = data.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); 
            var lineArray = new List<int>();

            // Loop all lines
            foreach (var line in lines)
            {
                // Create a new List<int> representing all the commaseparated numbers in this line

                // Slipt line by , and loop through all the numeric valus
                foreach (var s in line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    // Add converted numeric value to our lineArray 
                    lineArray.Add((int) Convert.ToInt64(s));
                    //lineArray.Add(Convert.ToSingle(s));
                }
                // Add lineArray to main array
                arrays.Add(lineArray.ToArray());

            }

            var stringarr = string.Join(",", lineArray);
            var parts = stringarr.Split(new[] { "", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            var intarray = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                intarray[i] = Convert.ToInt32(parts[i]);
            }
            
            Randy ran = new Randy();
            Bubby bub = new Bubby();
            Shaker shak = new Shaker();
            

            var sortype = Convert.ToInt32(Console.ReadLine());
            
            while (sortype < 5)
            {
                sortype = Convert.ToInt32(Console.ReadLine());
                switch (sortype)
                {
                    case 1:
                        var rand = ran.BogoSort(intarray);
                        Console.WriteLine("Random sort used:{0}", string.Join(",", rand));

                        break;
                    case 2:

                        var bubd = bub.BubbleSort(intarray);
                        Console.WriteLine("Bubble sort used:{0}", string.Join(",", bubd));
                        break;
                    case 3:
                        var shaka = shak.ShakerSort(intarray);
                        Console.WriteLine("Shaker sort used:{0}", string.Join(",", shaka));
                        break;






                }

            }





            //var numberOfRows = lines.Count();
            //var numberOfValues = arrays.Sum(s => s.Length);

            //Console.WriteLine(numberOfRows);
            //Console.WriteLine(numberOfValues);
            Console.ReadLine();

        }

        

        
    }
    
}