using System;

namespace exerciseOne
{
    class ChangeString
    {
        static void Main(string[] args)
        {
            Console.Write("Input << ");
            string cadena=Console.ReadLine();
            Build(cadena);
            //Console.ReadKey();
        }

        public static void Build(string input){
            string [] abc = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

            char[] inputChar = input.ToCharArray();
            string output = string.Empty;
            string result = string.Empty;
            foreach (char letter in inputChar){
                char letterEval = letter;
                int pos = Array.IndexOf(abc, letterEval.ToString().ToLower());
                if(pos > -1){
                    if(pos == abc.Length-1){
                        pos = -1; 
                    }
                    result = abc[pos+1]; 
                    if(Char.IsUpper(letter.ToString(), 0)){ 
                        result = result.ToUpper();
                    }
                }
                else{
                    result = letter.ToString();
                }
                output += string.Concat(result);
            }
            Console.WriteLine("output >> {0}", output);

        }
    }

    

}
