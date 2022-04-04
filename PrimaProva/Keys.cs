using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimaProva
{
    public class Keys
    {
        private PrivateKey privateKey;
        private PublicKey publicKey;
        private PrimeNumber p;
        private PrimeNumber q;
        private long n;
        private long m;

        public PrivateKey PrivateKey
        {
            get => privateKey;            
        }

        public PublicKey PublicKey
        {
            get => publicKey;            
        }
        
        public Keys()
        {
            do
            {
                p = new PrimeNumber();                
                q = new PrimeNumber();                
            } while (p.Number == q.Number || p.Number*q.Number<256);            
            n = p.Number * q.Number;
            m = (p.Number - 1) * (q.Number - 1);           
            GeneratePublicKey();                
            GeneratePrivateKey();
        }

        public Keys(PrimeNumber p,PrimeNumber q)
        {
            this.p = p;
            this.q = q;
            n = p.Number * q.Number;
            m = (p.Number - 1) * (q.Number - 1);
            GeneratePublicKey();
            GeneratePrivateKey();
        }

        public Keys(long n,long e)
        {
            this.n = n;
            SetPublicKey(n, e);
        }

        public Keys(long n, long e,long d)
        {
            this.n = n;
            SetPublicKey(n, e);
            SetPrivateKey(n, d);
        }    
        
        void SetPublicKey(long n,long e)
        {
            publicKey = new PublicKey(n, e, false);
        }

        void SetPrivateKey(long n,long d)
        {
            privateKey = new PrivateKey(n,publicKey.E,d);
        }

        public void GeneratePublicKey()
        {
            publicKey = new PublicKey(n, m,true);            
        }

        public void GeneratePrivateKey()
        {
            privateKey = new PrivateKey(n, m, publicKey.E);
        }
    }
}