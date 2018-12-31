using System;
using System.Collections.Generic;

namespace exerciseTwo
{
    class OrderRange
    {
        static void Main(string[] args)
        {
            //int[] input = { 58, 60, 55, 48, 57, 73 , 23, 64, 32, 6546, 4234, 54, 1 };
            Console.Write("tam arraglo < ");
            int val  = Convert.ToInt16(Console.ReadLine());

            int[] input = new int[val];

            for (int j = 0; j < input.Length; j++)
	    	{
		    	Console.Write("Input[{0}] <<  ", j);
		    	int value = Convert.ToInt16(Console.ReadLine());

			    input[j] = value;
		    }
            Build(input);
        }

        public static int[] bubbleSort(int[] input){

            for (int i = input.Length - 1; i > 0; i--){
                for (int j = 0; j <= i - 1; j++){
                    if (input[j] > input[j + 1]){
                        int highValue = input[j];
                        input[j] = input[j + 1];    
                        input[j + 1] = highValue;
                    }
                }
            }

            return input;
        }

        public static void Build(int[] input){

            //input = bubbleSort(input);
            Array.Sort(input);

            List<int> parList = new List<int>();
            List<int> imparList = new List<int>();

            foreach (int value in input){           
              if( (value % 2) == 0){// par
                parList.Add(value);
              }else{
                imparList.Add(value);                
              } 
            }
            
            var parArrayResult = new string[parList.Count];
            var imparArrayResult = new string[imparList.Count];
             
            for (int i = 0; i < parList.Count; i++) {  parArrayResult[i] = String.Join(",", parList[i]);}

            for (int i = 0; i < imparList.Count; i++) { imparArrayResult[i] = String.Join(",", imparList[i]);}

            Console.WriteLine("output >> [" + String.Join(",", parArrayResult) + "][" + String.Join(",", imparArrayResult) + "]");
        }
    }
}
