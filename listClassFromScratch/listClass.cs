using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listClassFromScratch
{   
    /// <summary>
    /// List methods created by using ony arrays.
    /// String, int and double types are usable. Operation will be done on strings.
    /// </summary>
    internal class listClass
    {        
        //Array
        /// <summary>
        /// Creates a new array of given size
        /// </summary>
        /// <param name="size"></param>
        /// <returns>String array</returns>
        public string[] createArray(int size)
        {
            string[] newArray = new string[size];
            return newArray;
        }

        /// <summary>
        /// Removes duplets from arrays
        /// </summary>
        /// <param name="array"></param>
        /// <returns>string array</returns>
        private string[] removeDuplets(string[] array)
        {
            Guid uuid = Guid.NewGuid();
            string[] checkedArray = createArray(array.Length);
            int newSize = array.Length;
            for(int i = 0; i < array.Length; i++)
            {
                checkedArray[i] = array[i];
            }

            string removeString = uuid.ToString();
            for(int j = 0; j < checkedArray.Length; j++)
            {
                for(int k = j+1; k < checkedArray.Length; k++)
                {
                    if(checkedArray[j] == array[k])
                    {
                        checkedArray[k] = removeString;
                        newSize--;
                    }
                }
            }
            string[] newArray = createArray(newSize);
            bool same = false;
            int index = 0;
            int l = 0;
            do
            {
                same = false;
                if (checkedArray[index] == removeString)
                {
                    same = true;
                    index++;
                }
                if (!same)
                {
                    newArray[l] = checkedArray[index];
                    index++;
                    l++;
                }
            } while (index < checkedArray.Length);
            return newArray;
        }

        //Count
        /// <summary>
        /// Get the size of an array
        /// </summary>
        /// <param name="array"></param>
        /// <returns>int</returns>
        public int getSize(string[] array)
        {   
            string[] newArray = removeDuplets(array);
            int size = newArray.Length;
            return size;
        }
        
        //Add
        /// <summary>
        /// adds an entry to a string array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="s"></param>
        /// <returns>string array</returns>
        public string[] addToList(string[] array, string s)
        {
            string[] newArray = createArray(array.Length+1);
            for(int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[newArray.Length-1] = s;
            return removeDuplets(newArray);
        }
        /// <summary>
        /// Removes entry at index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <returns>string array</returns>
        //Remove
        public string[] removeAtIndex(string[] array, int i)
        {
            if(i > array.Length-1)
            {
                Console.WriteLine("Index MUST be less then/equal to length of array: " + array.Length.ToString());

                return new string[0];
            }
            string[] newArray = createArray(array.Length - 1);
            int index = 0;
            int newIndex = 0;
            do
            {
                if (i == index)
                {
                    index++;
                }
                else
                {
                    newArray[newIndex] = array[index];
                    index++;
                    newIndex++;
                }

            } while (newIndex < newArray.Length);
            return newArray;
        }

        //Contains
        /// <summary>
        /// Finds a string/value in an array 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="text"></param>
        /// <returns>bool</returns>
        public bool contains(string[] array, string text)
        {
            string[] newArray = removeDuplets(array);
            bool containsString = false;
            for(int i = 0; i < newArray.Length; i++)
            {
                if(newArray[i] == text)
                    return containsString = true;
            }
            return containsString;
        }

        /// <summary>
        /// Converts a double array into a string array. All entries MUST be doubles.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>string array</returns>
        public string[] doubleArray2String(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!(array[i].GetType() == typeof(double)))
                {
                    Console.WriteLine();
                    Console.WriteLine("Type MUST be char!!!");
                    return new string[0];
                }
            }
            string[] newArray = createArray(array.Length);
            for (int j = 0; j < newArray.Length; j++)
            {
                newArray[j] = array[j].ToString();
            }
            string[] arrayOut = removeDuplets(newArray);
            return arrayOut;
        }


        /// <summary>
        /// Converts a string array to a double array, if the can be parsed. Seperator '.' will be replaced with ','.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>double array</returns>
        public double[] stringArray2Double(string[] array)
        {
            double[] newArray = new double[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i].Contains("."))
                {
                    array[i] = array[i].Replace(".", ",");
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    newArray[i] = Convert.ToDouble(array[i]);
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("Array must ONLY contain doubles");
                    return new double[0];
                }
            }
            return newArray;
        }

        // to string array
        /// <summary>
        /// Converts an int array to a string array, if ALL entries are ints
        /// </summary>
        /// <param name="array"></param>
        /// <returns>String array</returns>
        public string[] intArray2String(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!(array[i].GetType() == typeof(int)))
                {
                    Console.WriteLine();
                    Console.WriteLine("Type MUST be INT!!!");
                    return new string[0];
                }
            }
            string[] newArray = new string[array.Length];
            for(int j = 0; j < newArray.Length; j++)
            {
                newArray[j] = array[j].ToString();
            }
            string[] arrayOut = removeDuplets(newArray);
            return arrayOut;
        }
        /// <summary>
        /// Converts a string array to an integer array, if ALL entries can be parsed to ints.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>int array</returns>
        public int[] stringArray2Int(string[] array)
        {
            int[] newArray = new int[array.Length];
            
            for(int i = 0; i < array.Length; i++)
            {
                try
                {
                    newArray[i] = Convert.ToInt32(array[i]);
                }
                catch(Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("Array must ONLY contain INT's");
                    return new int[0];
                }
            }
            return newArray;
        }
        /// <summary>
        /// returns the value at index
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns>string</returns>
        public string getAt(string[] array, int index)
        {
            if (index > array.Length - 1)
            {
                Console.WriteLine();
                Console.WriteLine("Index MUST be less then/equal to length of array: " + array.Length.ToString());

                return "";
            }
            string s = array[index].ToString();
            return s;
        }

        
        public string[] objectArray2String(Object[] obj, Type type)
        {
            try
            {
                Convert.ChangeType(obj, type);
                return new string[0];
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Type is not " + type.ToString());
                return new string[0];
            }
        }      
    }
}
