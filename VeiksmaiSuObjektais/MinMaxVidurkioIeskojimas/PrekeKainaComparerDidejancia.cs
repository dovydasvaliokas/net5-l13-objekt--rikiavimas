using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxVidurkioIeskojimas
{
    internal class PrekeKainaComparerDidejancia : IComparer<Preke>
    {
        public int Compare(Preke? x, Preke? y)
        {
            if (x.Kaina > y.Kaina)
            {
                return 1;
            }
            else if (x.Kaina < y.Kaina)
            {
                return -1;  
            }
            else
            {
                return 0;
            }
        }
    }
}
