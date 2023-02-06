using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Stegonagraph
{
    class RSA
    {
        public long n { set; get; }
        public long e { set; get; }
        public long d { set; get; }
        public void GenerateValues(long p, long q) 
        {
            Random rnd = new Random();

            long n = p * q;
            long fn = (p - 1) * (q - 1);

            long e;
            long d = 0;

            while (true)
            {
                d = 0;

                do
                {
                    e =  (long)rnd.Next(2, (int)fn);
                } while (gcd(e, fn));

                for (long i = 1; i < n; i++)
                {
                    if ((e * i - 1) % fn == 0)
                    {
                        d = i;
                    }
                }

                if (d != 0 && d!=e)
                    break;
            }

            this.n = n;
            this.e = e;
            this.d = d;
        }

        public long Encrypt(long msg) 
        {
            return GetRemainder(msg, e, n);
        }
        public long Decrypt(long c)
        {
            return GetRemainder(c, d, n);
        }
        private Boolean IsPrime(long num1) {
            for (int i = 2; i < Math.Sqrt((Double)num1); i++)
            {
                if (num1 % i == 0)
                    return false;
            }
            return true;
        }
        private long GetRemainder(long num1, long degree, long divisor) 
        {
            long nom = num1%divisor;
            for (long i = 0; i < degree-1; i++)
                 nom = (nom * num1)%divisor;

            return (long)nom;
        }
        private Boolean gcd(long num1, long num2) {
            if (num1 > num2)
            {
                for (long i = 2; i <= num2; i++)
                {
                    if (num1 % i == 0)
                        return false;
                }
            }
            else {
                for (long i = 2; i <= num1; i++)
                {
                    if (num2 % i == 0)
                        return false;
                }
            }

            return true;
        }

    }
}
