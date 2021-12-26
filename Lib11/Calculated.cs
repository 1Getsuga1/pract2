using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMas;

namespace Lib11
{

    public static class Diffirence
    {
        public static string DiffirenceOfMas(this MyArray myarray)
        {
            int diff = myarray[0];

            for (int i = 1; i < myarray.Length; i++)
            {
                if (myarray[i] > 0 || myarray[i] < 0)
                {
                    diff -= myarray[i];
                }
            }
            return diff.ToString();
        }
    }
}
