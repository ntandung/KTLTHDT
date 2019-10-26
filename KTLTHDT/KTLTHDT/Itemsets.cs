using System.Collections.Generic;

namespace KTLTHDT
{
    public class Itemsets: List<int>
    {
        public float support = 0;
        public Itemsets()
        {
            support = 0;
        }

        public Itemsets(Itemsets itemsets)
        {
            foreach(int a in itemsets)
            {
                this.Add(a);
            }
            this.support = itemsets.support;
        }

        public string GetDisplay()
        {
            List<string> results = new List<string>();

            foreach (int index in this)
            {
                results.Add(Program.indexMapper[index - 1]);
            }
            return "{" + string.Join(",", results.ToArray()) + "}";
        }

        public bool IsEqual(List<int> a)
        {
            if (a.Count != this.Count)
                return false;
            for (int i = 0; i < this.Count; i++)
            {
                if (a[i] != this[i])
                    return false;
            }
            return true;
        }
    }


    public class ItemSetsCollection: List<Itemsets>
    {
        public string tid { get; set; } = "";
        public bool IsContains(Itemsets a)
        {
            foreach (Itemsets itemsets in this)
            {
                if (itemsets.IsEqual(a))
                {
                    return true;
                }
            }
            return false;
        }
        public void AddItemsets(Itemsets a)
        {
            foreach(Itemsets itemsets in this)
            {
                if (itemsets.IsEqual(a))
                {
                    itemsets.support += 1;
                    return;
                }
            }
            //a.support = 1;
            this.Add(a);
        } 

        public string GetDisplay()
        {
            List<string> tapDuLieu = new List<string>();
            foreach (Itemsets i in this)
            {
                tapDuLieu.Add(i.GetDisplay());
            }

            return string.Join(",", tapDuLieu.ToArray());
        }
    }


}
