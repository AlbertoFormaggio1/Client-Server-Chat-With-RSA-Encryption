using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ExtensionMethods
{
    public static class PrimeNumberHelper
    {
        static Random random = new Random();
        static int numTries = 20;

        /// <summary>
        /// Stabilisce se un numero è primo
        /// </summary>
        /// <param name="inputNum">Numero da verificare</param>
        /// <returns>Vero se primo, falso se composto</returns>
        public static bool isPrime(long inputNum)
        {
            if (inputNum < 3)
            {
                if (inputNum == 2) //Se il numero è minore di 3 controllo se è uguale a 2. Tale operazione è necessaria perchè il calcolo fatto (adatto a numeri grandi) con 2 darebbe problemi (si passa a Mcd 0 facendo inputNum-2). Si ricorda che 1 NON è un numero primo.
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            for (int prove = 0; prove < numTries; prove++)
            {
                double numeroDiProva = Math.Floor((random.NextDouble() * (inputNum - 2))) + 2;  //Prendo un numero più piccolo di inputNum (moltiplicando inputNum per un valore 0<x<1 ottengo un valore inferiore)

                //Controlla se esiste un fattore comune
                if (Mcd(numeroDiProva, inputNum) != 1)  //Se l'MCD è diverso da 1 significa che inputNum ha un fattore comune con numeroDiProva, quindi non è primo, ma composto
                {
                    return false;
                }

                //Test di Fermat
                if (EspModVeloce(numeroDiProva, inputNum - 1, inputNum) != 1)
                {
                    //Se ritorna un valore diverso da 1, è composto
                    return false;
                }
            } //fine ciclo

            return true;
        }

        /// <summary>
        /// Esponenziazione modulare. Permette di calcolare x^k mod n
        /// </summary>
        /// <param name="fattore"></param>
        /// <param name="potenza"></param>
        /// <param name="modulo"></param>       
        /// <returns>fattore^potenza % modulo</returns>
        public static double EspModVeloce(double fattore, double potenza, double modulo)
        {
            double result = 1;
            while (potenza > 0)
            {
                if (potenza % 2 == 1)
                {
                    result = (fattore * result) % modulo;
                    potenza--;
                }
                potenza = potenza / 2;
                fattore = (fattore * fattore) % modulo;
            }
            return result;
        }


        /// <summary>
        /// Calcola il massimo comun divisore (MCD). Usa l'algoritmo di Euclide (Euclidean algorithm su Wikipedia)
        /// </summary>
        /// <param name="x">Primo valore</param>
        /// <param name="y">Secondo valore</param>
        /// <returns>L'MCD di x e y</returns>
        public static double Mcd(double x, double y)
        {
            double tmp;
            if (x < y)  //Scambio i valori se x è minore di y per effettuare il modulo correttamente
            {
                tmp = x;
                x = y;
                y = tmp;
            }
            while (y != 0)
            {
                tmp = x % y;  //Faccio il modulo tra x e y e inserisco y in x e il resto dell'operazione in y
                x = y;
                y = tmp;
            }
            return x;  //MCD
        }
    }    
        //public static class JSONHelper
        //{
        //    public static string ToJSON(this object obj)
        //    {
        //        JavaScriptSerializer serializer = new JavaScriptSerializer();
        //        return serializer.Serialize(obj);
        //    }

        //    public static string ToJSON(this object obj, int recursionDepth)
        //    {
        //        JavaScriptSerializer serializer = new JavaScriptSerializer();
        //        serializer.RecursionLimit = recursionDepth;
        //        return serializer.Serialize(obj);
        //    }
        //}    
}
