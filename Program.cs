using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Intrinsics.X86;

namespace solve

{
    public class Stooge
    {
        // element exchange method
        static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }

        // sort by parts
        static int[] StoogeSort(int[] array, int startIndex, int endIndex)
        {
            if (array[startIndex] > array[endIndex])
            {
                Swap(ref array[startIndex], ref array[endIndex]);
            }

            if (endIndex - startIndex > 1)
            {
                var len = (endIndex - startIndex + 1) / 3;
                StoogeSort(array, startIndex, endIndex - len);
                StoogeSort(array, startIndex + len, endIndex);
                StoogeSort(array, startIndex, endIndex - len);
            }

            return array;
        }

        public int[] StoogeSort(int[] array)
        {
            var arr = StoogeSort(array, 0, array.Length - 1);
            return arr;

        }
    }

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

    struct ArrayandPath
    {
        public int[] arr;
        public string pathy;

    }
    

    static class Program
    {
        static void Main(string[] args)

        {
            string[] files = Directory.GetFiles(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), "sorted*");
            foreach (string file in files)
            {
                File.Delete(file);
            }
                MakeCalcReturn();
        } 
        static void RandBench(int[] arr, int times)
        {
                 Random random = new Random();
                 Stooge sto = new Stooge();
                 Bubby bub = new Bubby();
                 Shaker sha = new Shaker();
                
                 Stopwatch s1 = new Stopwatch();
                 Stopwatch s2 = new Stopwatch();
                 Stopwatch s3 = new Stopwatch();
                 for (int i = 0; i <times; i++)
                 {
                     
                    arr = arr.OrderBy(x => random.Next()).ToArray();
                    s1.Start();
                    var stos = sto.StoogeSort(arr);
                    s1.Stop();
                    arr = arr.OrderBy(x => random.Next()).ToArray();
                    s2.Start();
                    var bubi = bub.BubbleSort(arr );
                    s2.Stop();
                    arr = arr.OrderBy(x => random.Next()).ToArray();
                    
                    s3.Start();
                    var shaki = sha.ShakerSort(arr );
                    s3.Stop();




                 }

                  
                 Console.WriteLine("average speed of stoogesort is {0} mil after {1}",s1.ElapsedMilliseconds/times,times);
                 
                 Console.WriteLine("average speed of bubblesort is {0} mil after {1}",s2.ElapsedMilliseconds/times,times);
                 Console.WriteLine("average speed of shakersort is {0} mil after {1}",s3.ElapsedMilliseconds/times,times);
                 
                 
                 
        }


        static ArrayandPath ReadAndRun()
            {
                // Read the data.txt textfile.
                string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                var filesin = System.IO.Directory.GetFiles(_filePath, "*.txt");
                var poop = filesin;
                List<string> listi = poop.ToList();
                var pot = _filePath;
                for (int i = 0; i < poop.Length; i++)
                {

                    listi[i] = poop[i].Remove(0, pot.Length + 1);


                }


                Console.WriteLine("Choose the file in da directory containing numbers in it to sort");
                Console.WriteLine("zero is the first file and so on ");


                for (int i = 0; i < listi.Count; i++)
                {
                    Console.WriteLine("index: {1} --->{0}", listi[i], i);

                }

                //Console.WriteLine("{0}", string.Join('\n', listi));
                var indexoffile = Convert.ToInt32(Console.ReadLine());
                string pathtofile;
                if (indexoffile > filesin.Length - 1)
                {
                    pathtofile = filesin[^1];

                }
                else
                {
                    pathtofile = filesin[indexoffile];

                }


                //string txtfilename = Console.ReadLine()+".txt";
                var data = System.IO.File.ReadAllText(@pathtofile);
                //var data = System.IO.File.ReadAllText(@"/Users/biqontie/RiderProjects/solve/output.txt");

                // Create a new List of int[]
                var arrays = new List<int[]>();

                // Split data file content into lines
                var lines = data.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                var lineArray = new List<int>();

                // Loop all lines
                foreach (var line in lines)
                {
                    // Create a new List<int> representing all the commaseparated numbers in this line

                    // Slipt line by , and loop through all the numeric valus
                    foreach (var s in line.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        // Add converted numeric value to our lineArray 
                        lineArray.Add((int) Convert.ToInt64(s));
                        //lineArray.Add(Convert.ToSingle(s));
                    }

                    // Add lineArray to main array
                    arrays.Add(lineArray.ToArray());

                }

                var stringarr = string.Join(",", lineArray);
                var parts = stringarr.Split(new[] {"", ",", ";"}, StringSplitOptions.RemoveEmptyEntries);
                var intarray = new int[parts.Length];
                for (int i = 0; i < parts.Length; i++)
                {
                    intarray[i] = Convert.ToInt32(parts[i]);
                }

                ArrayandPath arry = new ArrayandPath();
                arry.arr = intarray;
                arry.pathy = listi[indexoffile][0..^4];
                return arry;

            }

            static async Task WriteThetext(int[] intarray, string pathy)
            {
                string text = String.Join(",", intarray);
                await File.WriteAllTextAsync("sorted_" + pathy + ".txt", text);
            }

            static void MakeCalcReturn()
            {

                ArrayandPath rs = ReadAndRun();
                var intarray = rs.arr;
                var pathy = rs.pathy;



                Bubby bub = new Bubby();
                Shaker shak = new Shaker();
                Stooge sto = new Stooge();
                Stopwatch s1 = new Stopwatch();
                Stopwatch s2 = new Stopwatch();
                Stopwatch s3 = new Stopwatch();
                var sortype = 0;
                long[] average = {9999999999};
                Console.WriteLine("choose the algorithms");
                Console.WriteLine(
                    "1-Stooge sort; 2-Buuble sort; 3-Shaker-sort,4 show the the fastest(only after using all three)");
                Console.WriteLine("5 - to save sorted file");
                Console.WriteLine("6-to choose another file,input 7 to benchmark");




                while (sortype < 8)
                {
                    sortype = Convert.ToInt32(Console.ReadLine());
                    if (sortype >= 8)
                    {

                        break;

                    }

                    switch (sortype)
                    {
                        case 1:
                            //var rand = ran.BogoSort(intarray);
                            s1.Reset();
                            s1.Start();

                            Console.WriteLine("Stooge sorted: {0}", string.Join(",", sto.StoogeSort(intarray)));

                            //Console.WriteLine("Random sort used:{0}", string.Join(",", rand));
                            s1.Stop();
                            Console.WriteLine("elapsed time in millieseconds:{0}", s1.ElapsedMilliseconds);

                            break;
                        case 2:
                            s2.Reset();
                            s2.Start();
                            Console.WriteLine("Bubble sorted: {0}", string.Join(",", bub.BubbleSort(intarray)));
                            //var bubd = bub.BubbleSort(intarray);
                            //Console.WriteLine("Bubble sort used:{0}", string.Join(",", bubd));
                            s2.Stop();
                            Console.WriteLine("elapsed time in millieseconds:{0}", s2.ElapsedMilliseconds);
                            break;
                        case 3:
                            //var shaka = shak.ShakerSort(intarray);
                            s3.Reset();
                            s3.Start();
                            Console.WriteLine("Shaker sorted: {0}", string.Join(",", shak.ShakerSort(intarray)));
                            //Console.WriteLine("Shaker sort used:{0}", string.Join(",", shaka));
                            s3.Stop();
                            Console.WriteLine("elapsed time in millieseconds:{0}", s3.ElapsedMilliseconds);
                            break;

                        case 4:
                            List<long> list = average.ToList();
                            list.Add(s1.ElapsedMilliseconds);
                            list.Add(s2.ElapsedMilliseconds);
                            list.Add(s3.ElapsedMilliseconds);
                            long[] lipsihigh = list.ToArray()[1..];
                            var min = list.Min();
                            var indexoflong = list.IndexOf(min);
                            Console.WriteLine("Stoogesort,Buublesort,Shakersort");
                            Console.WriteLine("{0}", string.Join(",", lipsihigh));
                            switch (indexoflong)
                            {
                                case 1:
                                    Console.WriteLine("the fastest algorithms is the Stoogesort {0} millieseconds",
                                        min);
                                    break;
                                case 2:
                                    Console.WriteLine("the fastest algorithms is the Bubblesort {0} millieseconds",
                                        min);
                                    break;
                                case 3:
                                    Console.WriteLine("the fastest algorithms is the Shakersort {0} milliesecond", min);
                                    break;
                            }
                            
                            Console.WriteLine("5 - to save sorted file");

                            break;
                        case 5:
                            WriteThetext(shak.ShakerSort(intarray), pathy);
                            Console.WriteLine("current file was sorted and saved as sorted_{0}.txt", pathy);
                            break;

                        case 6:
                            rs = ReadAndRun();
                            intarray = rs.arr;
                            pathy = rs.pathy;
                            Console.WriteLine("choose the algorithms");
                            Console.WriteLine(
                                "1-Stooge sort; 2-Buuble sort; 3-Shaker-sort,4 show the the fastest(only after using all three)");

                            Console.WriteLine("5 - to save sorted file");
                            Console.WriteLine("6-to choose another file,input 7 to benchmark");
                            break;
                        case 7:
                            Console.Write("how many time should it be shuffled and ran: ");
                            var timestorun = Convert.ToInt32(Console.ReadLine());
                            
                            RandBench(intarray,timestorun);
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
 
 
 