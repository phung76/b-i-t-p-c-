namespace PhamNgocPhung_18607081
{
    partial class hoadontheokhachhang
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
            this.dgvhdkh = new System.Windows.Forms.DataGridView();
            this.btntrove = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.btnreload = new System.Windows.Forms.Button();
            this.cboKH = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhdkh)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvhdkh
            // 
            this.dgvhdkh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhdkh.Location = new System.Drawing.Point(32, 65);
            this.dgvhdkh.Name = "dgvhdkh";
            this.dgvhdkh.Size = new System.Drawing.Size(555, 229);
            this.dgvhdkh.TabIndex = 0;
            // 
            // btntrove
            // 
            this.btntrove.Location = new System.Drawing.Point(512, 317);
            this.btntrove.Name = "btntrove";
            this.btntrove.Size = new System.Drawing.Size(75, 23);
            this.btntrove.TabIndex = 1;
            this.btntrove.Text = "trở về";
            this.btntrove.UseVisualStyleBackColor = true;
            this.btntrove.Click += new System.EventHandler(this.btntrove_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(272, 30);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 2;
            this.btnok.Text = "ok";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(533, 32);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(48, 20);
            this.txtsoluong.TabIndex = 3;
            // 
            // btnreload
            // 
            this.btnreload.Location = new System.Drawing.Point(419, 317);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(75, 23);
            this.btnreload.TabIndex = 4;
            this.btnreload.Text = "reload";
            this.btnreload.UseVisualStyleBackColor = true;
            this.btnreload.Click += new System.EventHandler(this.btnreload_Click);
            // 
            // cboKH
            // 
            this.cboKH.FormattingEnabled = true;
            this.cboKH.Location = new System.Drawing.Point(170, 32);
            this.cboKH.Name = "cboKH";
            this.cboKH.Size = new System.Drawing.Size(82, 21);
            this.cboKH.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "chọn khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "số lượng";
            // 
            // hoadontheokhachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 352);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboKH);
            this.Controls.Add(this.btnreload);
            this.Controls.Add(this.txtsoluong);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.btntrove);
            this.Controls.Add(this.dgvhdkh);
            this.Name = "hoadontheokhachhang";
            this.Text = "hoadontheokhachhang";
            this.Load += new System.EventHandler(this.hoadontheokhachhang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhdkh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvhdkh;
        private System.Windows.Forms.Button btntrove;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.Button btnreload;
        private System.Windows.Forms.ComboBox cboKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}