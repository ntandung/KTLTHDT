using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            dgvRule.DataSource = SinhBangL(Program.tapL);
            List<Rule> allRules = new List<Rule>();
            foreach (Itemsets itemsets in Program.tapL)
            {
                ItemSetsCollection subsets = itemsets.findSubSet();
                foreach (Itemsets subset in subsets)
                {
                    double confidence = (FindSupport(itemsets) / FindSupport(subset)) * 100.0;
                    if (confidence >= minConf)
                    {
                        Rule rule = new Rule();
                        rule.X.AddRange(subset);
                        rule.Y.AddRange(itemsets.Remove(subset));
                        rule.support = FindSupport(itemsets);
                        rule.confidence = confidence;
                        if (rule.X.Count > 0 && rule.Y.Count > 0)
                        {
                            allRules.Add(rule);
                        }
                    }
                }
            }
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

        public static DataTable SinhBangL(ItemSetsCollection lCurrent)
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Tập mục");
            dt.Columns.Add("Support (%)");
            foreach (Itemsets item in lCurrent)
            {
                dt.Rows.Add(new object[] { item.GetDisplay(), item.support });
            }

            return dt;
        }
    }
}
