using System;

namespace PrimaProva
{
    public class PrivateKey
    {
        private long n;
        private long d;

        public long N { get => n; }
        public long D { get => d; }

        public PrivateKey(long n, long m, PrimeNumber e)
        {
            Generate(n, m, e);
        }

        public PrivateKey(long n,PrimeNumber e,long d)
        {
            this.n = n;            
            this.d = d;           
        }

        public void Generate(long n, long m, PrimeNumber e)
        {
            this.n = n;
            //double k = 1; //Faccio un test per tutti i k esistenti
            long restoVecchio = m;
            long restoNuovo = e.Number;
            long tmpResto;
            long quoziente;
            long a = 0; //valore superiore della colonna centrale
            long b = 1; //valore inferiore della colonna centrale
            long tmp;
            do
            {
                quoziente = restoVecchio / restoNuovo;
                tmpResto = restoVecchio % restoNuovo;
                restoVecchio = restoNuovo;
                restoNuovo = tmpResto;
                tmp = b;
                b = a - (quoziente * b);
                a = tmp;
            } while (restoNuovo != 1); //Controllo se il numero risultante è INTERO

            if (b > 0)
            {
                d = b;
            }
            else
            {
                d = m + b;
            }
        }
    }
}