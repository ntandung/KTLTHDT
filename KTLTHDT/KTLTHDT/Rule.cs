using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTLTHDT
{
    class Rule
    {
        public Itemsets X;
        public Itemsets Y;
        public double support = 0.0;
        public double confidence = 0.0;
        public override string ToString()
        {
            return (X + " => " + Y + " (support: " + Math.Round(support, 2) + "%, confidence: " + Math.Round(confidence, 2) + "%)");
        }
    }
}
