using System.Collections.Generic;
using System.Linq;

namespace KTLTHDT
{
    public class Itemsets: List<int>
    {
        public float support = 0;
        public Itemsets()
        {
            support = 0;
        }

        public Itemsets(int a)
        {
            this.Add(a);
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

        public bool Contains(Itemsets itemsets)
        {
            return (this.Intersect(itemsets).Count() == itemsets.Count);
        }

        public string ToString()
        {
            return ("{" + string.Join(", ", this.ToArray()) + "}");
        }

        public ItemSetsCollection findSubSet()
        {
            ItemSetsCollection subSets = new ItemSetsCollection();
            
            for(int i = 1; i < this.Count; i++)
            {
                subSets.Add(new Itemsets(this[i-1]));
                ItemSetsCollection newSubsets = new ItemSetsCollection();
                for (int j = 0; j < subSets.Count; j++)
                {
                    Itemsets newSubset = new Itemsets();
                    newSubset.AddRange(subSets[j]);
                    newSubset.Add(this[i]);
                    newSubsets.Add(newSubset);
                }

                subSets.AddRange(newSubsets);
            }
            subSets.Add(new Itemsets(this[this.Count - 1]));
            return subSets;
        }
        public Itemsets Remove(Itemsets itemsets)
        {
            Itemsets removed = new Itemsets();
            removed.AddRange(from item in this
                             where !itemsets.Contains(item)
                             select item);
            return (removed);
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
        public string ToString()
        {
            string result="";
            foreach(Itemsets itemset in this)
            {
                result += itemset.ToString()+",";
            }
            return result;
        }
    }


}
