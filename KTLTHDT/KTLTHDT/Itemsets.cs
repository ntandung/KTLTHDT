﻿using System.Collections.Generic;
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
            ItemSetsCollection result = new ItemSetsCollection();
            
            for(int i = 1; i < this.Count; i++)
            {
                result.Add(new Itemsets(this[i-1]));
                ItemSetsCollection newSubsets = new ItemSetsCollection();
                for (int j = 0; j < result.Count; j++)
                {
                    Itemsets newSubset = new Itemsets();
                    newSubset.AddRange(result[j]);
                    newSubset.Add(this[i]);
                    newSubsets.Add(newSubset);
                }

                result.AddRange(newSubsets);
            }
            result.Add(new Itemsets(this[this.Count - 1]));
            return result;
        }
        public Itemsets Remove(Itemsets itemsets)
        {
            Itemsets removed = new Itemsets();
            foreach(int item in this)
            {
                if (!itemsets.Contains(item))
                {
                    removed.Add(item);
                }
            }
            //removed.AddRange(from item in thiswhere !itemsets.Contains(item)select item);
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

        public float GetSupp(Itemsets a)
        {
            foreach (Itemsets itemsets in this)
            {
                if (itemsets.IsEqual(a))
                {
                    return itemsets.support;
                }
            }
            return 0;
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
            a.support = 1;
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
