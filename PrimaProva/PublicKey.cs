using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace PrimaProva
{
    public class PublicKey
    {
        private long n;
        private PrimeNumber e;
        
        public long N { get => n; set => n = value; }
        public PrimeNumber E { get => e; set => e = value; }

        /// <summary>
        /// Crea la chiave pubblica
        /// </summary>
        /// <param name="num1">Numero n</param>
        /// <param name="num2"></param>
        public PublicKey(long num1,long num2,bool generate)
        {
            if (generate)
            {
                Generate(num1, num2);
            }
            else
            {
                SetKey(num1, num2);
            }
        }

        void SetKey(long n,long e)
        {
            this.n = n;
            this.e = new PrimeNumber(e,false);
        }
        
        public void Generate(long n,long m)
        {
            this.n = n;
            do
            {
                e = new PrimeNumber(m,true);                
            } while (!e.IsCoprime(m));
        }       
        
    }
}