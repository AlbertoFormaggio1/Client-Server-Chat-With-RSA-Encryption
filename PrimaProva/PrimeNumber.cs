using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using ExtensionMethods;

namespace PrimaProva
{
    public class PrimeNumber
    {
        private long number;
        private Random random;        

        public long Number { get => number; }

        public PrimeNumber()
        {
            random = new Random();
            number=GenerateNumber();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="numIsMax"></param>
        public PrimeNumber(long num,bool numIsMax)
        {
            random = new Random();
            if (numIsMax)
            {
                random = new Random();
                number=GenerateNumber(num);
            }
            else
            {
                if (!SetNumber(num))
                {
                    number=GenerateNumber();
                }
            }
        }

        /// <summary>
        /// Setta il numero passato
        /// </summary>
        /// <param name="num">Numero da settare</param>
        /// <returns>Vero se il set è riuscito, falso altrimenti</returns>
        bool SetNumber(long num)
        {
            bool result;
            if (PrimeNumberHelper.isPrime(num))
            {
                number = num;
                result = true;
            }
            else
            {                
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Genera un numero casuale
        /// </summary>
        public long GenerateNumber()
        {
            long tmp;
            do
            {
                tmp = random.Next();  
            } while (!PrimeNumberHelper.isPrime(tmp));
            return tmp;
        }        

        /// <summary>
        /// Genera un numero casuale
        /// </summary>
        /// <param name="max">Numero massimo generabile</param>
        public long GenerateNumber(long max)
        {
            long tmp;
            if (max > Int32.MaxValue) //Se il numero massimo è superiore al valore massimo dell'int32, quindi ha più di 4 byte significativi, genero un numero casuale di 4 byte, il quale sarà sempre minore di max
            {
                tmp=GenerateNumber();
            }
            else //Altrimenti genero un numero casuale nel range specificato
            {
                do
                {
                    int maxN = (int)max;
                    tmp= random.Next(maxN);
                }
                while (!PrimeNumberHelper.isPrime(tmp));                
            }
            return tmp;
        }

        /// <summary>
        /// Controlla se 2 numeri sono coprimi tra loro
        /// </summary>
        /// <param name="number2">Numero con cui effettuare il confronto</param>
        /// <returns>Vero se sono coprimi, in caso contrario falso</returns>
        public bool IsCoprime(long number2)
        {
            if (Number < number2)
            {
                if (PrimeNumberHelper.Mcd(number, number2) == 1)
                {
                    return true;
                }
            }
            return false;            
        }        
    }
}