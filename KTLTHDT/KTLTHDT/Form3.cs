using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace KTLTHDT
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int minConf = 50;
            List<Rule> allRules = new List<Rule>();
            foreach (Itemsets itemsets in Program.tapL)
            {
                if (itemsets.Count == 1)
                    continue;
                ItemSetsCollection subsets = itemsets.findSubSet();
                int a = 0;
                foreach (Itemsets subset in subsets)
                {
                    if (subset.Count == itemsets.Count)
                        continue;
                    double confidence = (itemsets.support/ Program.tapL.GetSupp(subset)) * 100.0;
                    if (confidence >= minConf)
                    {
                        Rule rule = new Rule();
                        rule.X = subset;
                        rule.Y = itemsets.Remove(subset);
                        rule.support = FindSupport(itemsets);
                        rule.confidence = confidence;
                        if (rule.X.Count > 0 && rule.Y.Count > 0)
                        {
                            allRules.Add(rule);
                        }
                    }
                }
            }
            dgvRule.DataSource = SinhBangLuat(allRules);

        }

        public double FindSupport(Itemsets itemsets)
        {

            /*int matchCount = (from i in this
                              where i.Contains(itemset)
                              select i).Count();

            double support = ((double)matchCount / (double)this.Count) * 100.0;*/
            double support =0;
            return support;
        }

        public static DataTable SinhBangLuat(List<Rule> rules)
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Luật");
            dt.Columns.Add("Conf (%)");
            foreach (Rule rule in rules)
            {
                dt.Rows.Add(new object[] { rule.GetDisplay(), rule.confidence });
            }

            return dt;
        }
    }
}
