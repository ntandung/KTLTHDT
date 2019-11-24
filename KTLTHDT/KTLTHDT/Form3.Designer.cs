namespace KTLTHDT
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRule = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinConf = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFindRule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRule
            // 
            this.dgvRule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRule.Location = new System.Drawing.Point(12, 98);
            this.dgvRule.Name = "dgvRule";
            this.dgvRule.Size = new System.Drawing.Size(1234, 532);
            this.dgvRule.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiến hành sinh luật";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Min Conf :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtMinConf
            // 
            this.txtMinConf.Location = new System.Drawing.Point(15, 30);
            this.txtMinConf.Name = "txtMinConf";
            this.txtMinConf.Size = new System.Drawing.Size(100, 20);
            this.txtMinConf.TabIndex = 3;
            this.txtMinConf.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "%";
            // 
            // btnFindRule
            // 
            this.btnFindRule.Location = new System.Drawing.Point(167, 26);
            this.btnFindRule.Name = "btnFindRule";
            this.btnFindRule.Size = new System.Drawing.Size(75, 23);
            this.btnFindRule.TabIndex = 5;
            this.btnFindRule.Text = "Tìm luật";
            this.btnFindRule.UseVisualStyleBackColor = true;
            this.btnFindRule.Click += new System.EventHandler(this.btnFindRule_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.btnFindRule);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMinConf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRule);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3 - [ĐỀ TÀI 3] QUẢN LÍ ĐIỂM SINH VIÊN";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMinConf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFindRule;
    }
}