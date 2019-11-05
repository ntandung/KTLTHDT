using System;

namespace KTLTHDT
{
    public class Rule
    {
        public Itemsets X;
        public Itemsets Y;
        public double support = 0.0;
        public double confidence = 0.0;
        public override string ToString()
        {
            return (X + " => " + Y + " (support: " + Math.Round(support, 2) + "%, confidence: " + Math.Round(confidence, 2) + "%)");
        }

        public string GetDisplay()
        {
            return this.X.GetDisplay() + " -> " + this.Y.GetDisplay();
        }
    }
}
