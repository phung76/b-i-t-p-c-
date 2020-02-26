namespace PhamNgocPhung_18607081
{
    partial class HDtheosanpham
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
            this.dgvhdtkh = new System.Windows.Forms.DataGridView();
            this.btntrove = new System.Windows.Forms.Button();
            this.btnreload = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.cbosanpham = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txttong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhdtkh)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvhdtkh
            // 
            this.dgvhdtkh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhdtkh.Location = new System.Drawing.Point(12, 63);
            this.dgvhdtkh.Name = "dgvhdtkh";
            this.dgvhdtkh.Size = new System.Drawing.Size(552, 230);
            this.dgvhdtkh.TabIndex = 0;
            // 
            // btntrove
            // 
            this.btntrove.Location = new System.Drawing.Point(467, 299);
            this.btntrove.Name = "btntrove";
            this.btntrove.Size = new System.Drawing.Size(90, 30);
            this.btntrove.TabIndex = 1;
            this.btntrove.Text = "trở về";
            this.btntrove.UseVisualStyleBackColor = true;
            // 
            // btnreload
            // 
            this.btnreload.Location = new System.Drawing.Point(371, 299);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(90, 30);
            this.btnreload.TabIndex = 2;
            this.btnreload.Text = "reload";
            this.btnreload.UseVisualStyleBackColor = true;
            this.btnreload.Click += new System.EventHandler(this.btnreload_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(263, 25);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(55, 24);
            this.btnok.TabIndex = 3;
            this.btnok.Text = "ok";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // cbosanpham
            // 
            this.cbosanpham.FormattingEnabled = true;
            this.cbosanpham.Location = new System.Drawing.Point(126, 25);
            this.cbosanpham.Name = "cbosanpham";
            this.cbosanpham.Size = new System.Drawing.Size(121, 21);
            this.cbosanpham.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "chọn mã  áo";
            // 
            // txttong
            // 
            this.txttong.Location = new System.Drawing.Point(509, 26);
            this.txttong.Name = "txttong";
            this.txttong.Size = new System.Drawing.Size(55, 20);
            this.txttong.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "tổng ";
            // 
            // HDtheosanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbosanpham);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.btnreload);
            this.Controls.Add(this.btntrove);
            this.Controls.Add(this.dgvhdtkh);
            this.Name = "HDtheosanpham";
            this.Text = "HDtheosảnpham";
            this.Load += new System.EventHandler(this.HDtheokhachhang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhdtkh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvhdtkh;
        private System.Windows.Forms.Button btntrove;
        private System.Windows.Forms.Button btnreload;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.ComboBox cbosanpham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttong;
        private System.Windows.Forms.Label label2;
    }
}