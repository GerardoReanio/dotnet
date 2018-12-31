using System;
using System.Collections.Generic;

namespace exerciseThree
{
    class MoneyParts
    {
        static void Main(string[] args)
        {
            Console.Write("Input << ");
            string monto=Console.ReadLine();
            Build(monto);
        }

        public static decimal getParteEntera(decimal number){
            return Math.Truncate(number);
        }

        public static decimal getParteDecimal(decimal number){
            return number - Convert.ToDecimal(getParteEntera(number));
        }

        public static string Imprimir(decimal denominacion, decimal veces){
            //Console.WriteLine("{0}x{1}", denominacion, veces);
            string impComb = string.Empty;
            for(int k = 0; k < veces; k++){
                impComb = string.Join(", ", Convert.ToString(denominacion), impComb);
            }
            impComb =  "[" + impComb + "]";
            //return Convert.ToString(denominacion)+"x"+Convert.ToString(veces);
            return impComb;
        }

                            
        public static void calculateCombinacionesImp(decimal montoDecimal, string combinatoriaParcial){

            // backup de valor inicial la comParcial
            string combPartial = combinatoriaParcial;
            
            decimal[] denominaciones = {0.05m, 0.1m, 0.2m, 0.5m, 1.0m, 2.0m, 5.0m, 10.0m, 20.0m, 50.0m, 100.0m, 200.0m};
            List<decimal> listDenominacionestmp = new List<decimal>();
            List<string> listCombinacionesParciales = new List<string>();

             foreach (var item in denominaciones){
                if(item <= montoDecimal){
                    listDenominacionestmp.Add(item);
                }
            }
   
            decimal veces;
            string rptaCombinatoria = string.Empty;
            string typeRpta;
            int contador = 0;
            for (int i = 0; i < listDenominacionestmp.Count; i++){
                //Console.WriteLine("IteracionInterna nro:{0} - Denominacion[{1}]", contador, listDenominacionestmp[i]);

                veces = montoDecimal/listDenominacionestmp[i]; // nro de veces que se debe repetir esa denominacion
                
                typeRpta = (veces - Math.Truncate(veces)) == 0 ? "Entero" : "Decimal";
                if(typeRpta == "Decimal"){

                     // obtenemos la combinacion repetitiva en un string
                    string combPartialRecur = Imprimir(listDenominacionestmp[i], getParteEntera(veces));
                    calculateCombinacionesImp(getParteDecimal(veces)*listDenominacionestmp[i], string.Join(",", combinatoriaParcial, combPartialRecur) );

                }else{ // entero diferente de 1
                    if(veces == 1){
                        string combfinal = Imprimir(listDenominacionestmp[i], veces); // mi ultima/unica combinatoria posible
                        // imprimo
                        Console.WriteLine(string.Join(",", combinatoriaParcial, combfinal));
                        break; // ya no hay mas combinatorias por calcular,
                    }else{
                        // imprimir la primera combinación
                        Console.WriteLine(string.Join(",",combinatoriaParcial, Imprimir(listDenominacionestmp[i], veces) ));   
                    }                
                }
                contador++;
            }   
            
        }

        public static void Build(string monto){
            decimal montoDecimal =  Convert.ToDecimal(monto);

            decimal[] denominaciones = {0.05m, 0.1m, 0.2m, 0.5m, 1.0m, 2.0m, 5.0m, 10.0m, 20.0m, 50.0m, 100.0m, 200.0m};
            List<decimal> listDenominaciones = new List<decimal>();
            string rptaCombinatoria = string.Empty;    

             foreach (var item in denominaciones){
                if(item <= montoDecimal){
                    listDenominaciones.Add(item);
                }
            }

            decimal rpta;
            string typeRpta;

            int contador = 0; // contador de iteraciones
            string parteEntera = string.Empty;
            for (int j = 0; j < listDenominaciones.Count; j++){
                
                //Console.WriteLine("Iteracion nro:{0} - Denominacion[{1}]", contador, listDenominaciones[j]);
                rpta = montoDecimal/listDenominaciones[j]; // nro de veces que se debe repetir esa denominacion
                
                typeRpta = (rpta - Math.Truncate(rpta)) == 0 ? "Entero" : "Decimal";
                if(typeRpta == "Decimal"){
                    
                    // obtenemos la combinacion repetitiva en un string
                    string combPartial = Imprimir(listDenominaciones[j], getParteEntera(rpta));
                    calculateCombinacionesImp(getParteDecimal(rpta)*listDenominaciones[j], combPartial );
                    
                }else{ // entero diferente de 1
                    if(rpta == 1){
                        Console.WriteLine(Imprimir(listDenominaciones[j], rpta)); 
                        //Console.WriteLine("Fin del Algoritmo");
                        break;
                    }else{
                        // imprimir la primera combinación
                        Console.WriteLine(Imprimir(listDenominaciones[j], rpta));    
                    }
                }
                            
                contador++;
            }  

           
            //Console.WriteLine("De String a Decimal : {0:C}", montoDecimal);           
            
        }
    }
}
