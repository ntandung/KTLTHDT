using System.Collections.Generic;


namespace KTLTHDT
{
    class Program
    {

        public static int k = 0;
        public static int tongSoGiaoTac = 0;
        public static int sup = 0;
        // Luu danh sach listItemsets theo chi so
        public static List<string> indexMapper = new List<string>();
        // '1,2': 40 {1,2}
        public static ItemSetsCollection tapL = new ItemSetsCollection();
        public static List<List<ItemSetsCollection>> tapF = new List<List<ItemSetsCollection>>();

        /// <summary>
        /// Tinh tap L tu tap F hien tai
        /// </summary>
        /// <param name="fCurrent"></param>
        /// <returns></returns>
        public static ItemSetsCollection TinhL(List<ItemSetsCollection> fCurrent)
        {
            ItemSetsCollection results = new ItemSetsCollection();
            // Lap lay danh sach cac chi muc thuoc F
            foreach(ItemSetsCollection listItemsets in fCurrent) {
                foreach (Itemsets itemsets in listItemsets)
                {
                    results.AddItemsets(itemsets);
                }
            }

            // Cac chi muc cua tap L thoa minSup
            // Loai bo cac tap muc khong thoa minSup
            ItemSetsCollection tmp1 = new ItemSetsCollection();
            foreach (Itemsets i in results)
            {
                if (i.support >= Program.sup)
                {
                    i.support = (float)(i.support) / Program.tongSoGiaoTac * 100;
                    if(!Program.tapL.IsContains(i))
                        Program.tapL.Add(i);
                    tmp1.Add(i);
                }
            }
            return tmp1;
        }

        /// <summary>
        /// Thuat toan apriori_gen, sinh ra tap ung vien C tu tap L(k-1)
        /// </summary>
        /// <param name="lPrevious">L(k-1)</param>
        /// <returns></returns>
        public static ItemSetsCollection AprioriGen(ItemSetsCollection lPrevious)
        {
            ItemSetsCollection result = new ItemSetsCollection();
            if (lPrevious.Count <= 1)
                return result;
            
            int k = lPrevious[0].Count;
            
            for(int i = 0; i < lPrevious.Count - 1; i++)
            {
                Itemsets p = new Itemsets(lPrevious[i]);
                p.RemoveAt(k - 1);
                
                for (int j = i+1; j < lPrevious.Count; j++)
                {
                    Itemsets q = new Itemsets(lPrevious[j]);
                    q.RemoveAt(k - 1);
                    
                    if (p.IsEqual(q))
                    {
                        q.Add(lPrevious[i][k-1]);
                        q.Add(lPrevious[j][k-1]);
                        result.Add(q);
                    }

                }

            }
            return result;
        }

        /// <summary>
        /// Kiem tra tap muc thuoc tid
        /// </summary>
        /// <param name="tid">Transaction id cua F</param>
        /// <param name="muc">Mot muc cua L, Example: {1,2}</param>
        /// <returns></returns>
        public static bool ThuocTid(ItemSetsCollection tid, Itemsets muc)
        {
            Itemsets p = new Itemsets(muc);
            p.RemoveAt(muc.Count - 1);

            // p: c-c[k] 
            List<int> q = new List<int>(muc);
            q.RemoveAt(muc.Count - 2);

            //q: c-c[k-1] 
            int count = 0;
            foreach(Itemsets item in tid)
            {
                if (item.IsEqual(p))
                    count += 1;
                if (item.IsEqual(q))
                    count += 1;
            }
            return count>=2;
        }

        /// <summary>
        /// Sinh ra tap F moi tu F(k-1) va L(k-1)
        /// </summary>
        /// <param name="fPrevious"></param>
        /// <param name="lPrevious"></param>
        /// <returns></returns>
        public static List<ItemSetsCollection> SinhF(List<ItemSetsCollection> fPrevious, ItemSetsCollection lPrevious)
        {
            Program.k += 1;
            ItemSetsCollection tapC = AprioriGen(lPrevious);

            List<ItemSetsCollection> tmp = new List<ItemSetsCollection>();
            foreach(ItemSetsCollection fItem in fPrevious)
            {
                ItemSetsCollection tmp1 = new ItemSetsCollection();
                foreach (Itemsets item in tapC)
                {
                    if(ThuocTid(fItem, item))
                    {
                        tmp1.Add(item);
                        tmp1.tid = fItem.tid;
                    }
                }
                if(tmp1.Count > 0)
                {
                    tmp.Add(tmp1);
                }
            }
            Program.tapF.Add(tmp);
            return tmp;
        }
        
        static void Main(string[] args)
        {
            //FormGieoLuat gieoLuat = new FormGieoLuat();
            //gieoLuat.ShowDialog();

            Form1 form1 = new Form1();
            form1.Show();


        }
    }
}
