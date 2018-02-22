using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingApp
{
    public class MyDictionary<T>
    {
        //Generic array to hold dictionary values
        T[] values = new T[150];

        //Hash Function to assign index value
        private int HashFunction(string key)
        {
            int keyValue = 0;

            //Look at each character in key and sum them all into keyValue
            foreach(char ch in key)
            {
                keyValue += (int)ch;
            }

            //take the sum and get the modulus for index value
            keyValue = keyValue % 119;

            return keyValue;
        }
        
        //Set dictionary item
        public void Set(string key,T value)
        {
            //Get hash key value for array
            int hashKey = HashFunction(key);
            //If object is null assign it
            if (values[hashKey] == null)
            {
                values[hashKey] = value;
            }
            //Otherwise collision and increment by one until null position is found.
            else
            {
                //Handle Collision
                Console.WriteLine($"Collision: {key}");
                int inc = 1;

                try
                {
                    while (values[hashKey + inc] != null)
                    {
                        inc++;
                    }
                    values[hashKey + inc] = value;
                }
                //If the array is full from the index until the end of array then start from the beginning.
                catch (IndexOutOfRangeException)
                {
                    inc = 0;
                    while (values[0 + inc] != null)
                    {
                        inc++;
                    }
                    values[0 + inc] = value;
                }
                
            }
            
        }

        /// <summary>
        /// Return dictionary object by a given key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get(string key)
        {
            //Get hash key value for array
            int hashKey = HashFunction(key);
            //Get object for the given key value
            T temp = values[hashKey];

            //Check if object exists in dictionary
            if (temp != null)
            {
                //If object in hash key value contains parameter key value return object information
                if (temp.ToString().Contains(key))
                {
                    Console.WriteLine("Search Result Was Found!");
                    return values[hashKey];
                }

                //IMPLEMENT LINEAR PROBING TO HANDLE COLLISIONS
                //
                //If the object does not match the parameter increment the hash key value by one until
                //the correct object is returned.
                else
                {
                    int inc = 1;

                    try
                    {
                        do
                        {
                            temp = values[hashKey + inc];
                            if (temp.ToString().Contains(key)) break;
                            inc++;

                        } while (!temp.ToString().Contains(key));

                        //return correct object the matches the method parameter string
                        Console.WriteLine("Search Result Was Found!");
                        return values[hashKey + inc];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        inc = 0;
                        do
                        {
                            if (inc < 149) break;
                            temp = values[0 + inc];
                            if (temp.ToString().Contains(key)) break;
                            
                            inc++;

                        } while (!temp.ToString().Contains(key));

                        if (inc < 149)
                        {
                            Console.WriteLine("Record Not Found!");
                            return default(T);
                        }
                        else
                        {
                            //return correct object the matches the method parameter string
                            Console.WriteLine("Search Result Was Found!");
                            return values[0 + inc];
                        }
                        
                    }   
                }
            }
            else return default(T);
            
        }

        /// <summary>
        /// Get the total number of objects that are not null in dictionary array
        /// </summary>
        /// <returns></returns>
        public int getArrayLength()
        {
            int count = 0;
            foreach (T d in values)
            {
                if (d != null)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Return a list of all objects in dictionary array
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string valuesString = "";

            foreach(T value in values)
            {
                if(value != null) valuesString += value.ToString() + "\n\n";

            }
            return valuesString;
        }

    }
}
