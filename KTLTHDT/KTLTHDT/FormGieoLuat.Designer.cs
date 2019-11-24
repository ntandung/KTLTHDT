namespace KTLTHDT
{
    partial class FormGieoLuat
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMinSup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNumRow = new System.Windows.Forms.TextBox();
            this.BtnSinhData = new System.Windows.Forms.Button();
            this.CheckListBoxMonHoc = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min Sup";
            // 
            // TxtMinSup
            // 
            this.TxtMinSup.Location = new System.Drawing.Point(555, 415);
            this.TxtMinSup.Name = "TxtMinSup";
            this.TxtMinSup.Size = new System.Drawing.Size(100, 20);
            this.TxtMinSup.TabIndex = 1;
            this.TxtMinSup.Text = "80";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số giao tác";
            // 
            // TxtNumRow
            // 
            this.TxtNumRow.Location = new System.Drawing.Point(365, 415);
            this.TxtNumRow.Name = "TxtNumRow";
            this.TxtNumRow.Size = new System.Drawing.Size(100, 20);
            this.TxtNumRow.TabIndex = 1;
            this.TxtNumRow.Text = "10";
            // 
            // BtnSinhData
            // 
            this.BtnSinhData.Location = new System.Drawing.Point(698, 414);
            this.BtnSinhData.Name = "BtnSinhData";
            this.BtnSinhData.Size = new System.Drawing.Size(75, 23);
            this.BtnSinhData.TabIndex = 2;
            this.BtnSinhData.Text = "Sinh data";
            this.BtnSinhData.UseVisualStyleBackColor = true;
            this.BtnSinhData.Click += new System.EventHandler(this.BtnSinhData_Click);
            // 
            // CheckListBoxMonHoc
            // 
            this.CheckListBoxMonHoc.FormattingEnabled = true;
            this.CheckListBoxMonHoc.Location = new System.Drawing.Point(12, 38);
            this.CheckListBoxMonHoc.Name = "CheckListBoxMonHoc";
            this.CheckListBoxMonHoc.Size = new System.Drawing.Size(776, 349);
            this.CheckListBoxMonHoc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "DANH SÁCH MÔN HỌC";
            // 
            // FormGieoLuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CheckListBoxMonHoc);
            this.Controls.Add(this.BtnSinhData);
            this.Controls.Add(this.TxtNumRow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtMinSup);
            this.Controls.Add(this.label1);
            this.Name = "FormGieoLuat";
            this.Text = "GIEO LUẬT";
            this.Load += new System.EventHandler(this.FormGieoLuat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtMinSup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNumRow;
        private System.Windows.Forms.Button BtnSinhData;
        private System.Windows.Forms.CheckedListBox CheckListBoxMonHoc;
        private System.Windows.Forms.Label label3;
    }
}