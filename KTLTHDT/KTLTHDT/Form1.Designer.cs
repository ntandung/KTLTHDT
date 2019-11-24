namespace KTLTHDT
{
    partial class Form1
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMinSup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTimD = new System.Windows.Forms.Button();
            this.btnTimItemSets = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvMH = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(52, 82);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv1.Size = new System.Drawing.Size(938, 470);
            this.dgv1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TÌM LUẬT THEO THUẬT TOÁN APRIORI-TID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BẢNG GIAO TÁC (TẬP D)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 573);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "MinSup";
            // 
            // txtMinSup
            // 
            this.txtMinSup.Location = new System.Drawing.Point(122, 570);
            this.txtMinSup.Name = "txtMinSup";
            this.txtMinSup.Size = new System.Drawing.Size(58, 20);
            this.txtMinSup.TabIndex = 4;
            this.txtMinSup.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 573);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "%";
            // 
            // btnTimD
            // 
            this.btnTimD.Location = new System.Drawing.Point(67, 614);
            this.btnTimD.Name = "btnTimD";
            this.btnTimD.Size = new System.Drawing.Size(165, 23);
            this.btnTimD.TabIndex = 6;
            this.btnTimD.Text = "TÌM TẬP D THỎA MINSUP";
            this.btnTimD.UseVisualStyleBackColor = true;
            this.btnTimD.Click += new System.EventHandler(this.btnTimD_Click);
            // 
            // btnTimItemSets
            // 
            this.btnTimItemSets.Location = new System.Drawing.Point(270, 614);
            this.btnTimItemSets.Name = "btnTimItemSets";
            this.btnTimItemSets.Size = new System.Drawing.Size(165, 23);
            this.btnTimItemSets.TabIndex = 7;
            this.btnTimItemSets.Text = "TÌM ITEMSETS";
            this.btnTimItemSets.UseVisualStyleBackColor = true;
            this.btnTimItemSets.Click += new System.EventHandler(this.btnTimItemSets_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1049, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "BẢNG MÃ HÓA";
            // 
            // dgvMH
            // 
            this.dgvMH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMH.Location = new System.Drawing.Point(1031, 82);
            this.dgvMH.Name = "dgvMH";
            this.dgvMH.Size = new System.Drawing.Size(226, 470);
            this.dgvMH.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.dgvMH);
            this.Controls.Add(this.btnTimItemSets);
            this.Controls.Add(this.btnTimD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMinSup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1 - [ĐỀ TÀI 3] QUẢN LÍ ĐIỂM SINH VIÊN";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMinSup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTimD;
        private System.Windows.Forms.Button btnTimItemSets;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvMH;
    }
}