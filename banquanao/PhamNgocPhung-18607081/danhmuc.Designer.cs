namespace PhamNgocPhung_18607081
{
    partial class danhmuc
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
            this.lbdanhmuc = new System.Windows.Forms.Label();
            this.dgvdanhmuc = new System.Windows.Forms.DataGridView();
            this.btntrove = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanhmuc)).BeginInit();
            this.SuspendLayout();
            // 
            // lbdanhmuc
            // 
            this.lbdanhmuc.AutoSize = true;
            this.lbdanhmuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdanhmuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbdanhmuc.Location = new System.Drawing.Point(46, 35);
            this.lbdanhmuc.Name = "lbdanhmuc";
            this.lbdanhmuc.Size = new System.Drawing.Size(221, 31);
            this.lbdanhmuc.TabIndex = 0;
            this.lbdanhmuc.Text = "danh mục bán áo";
            // 
            // dgvdanhmuc
            // 
            this.dgvdanhmuc.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvdanhmuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdanhmuc.Location = new System.Drawing.Point(21, 75);
            this.dgvdanhmuc.Name = "dgvdanhmuc";
            this.dgvdanhmuc.Size = new System.Drawing.Size(384, 168);
            this.dgvdanhmuc.TabIndex = 1;
            // 
            // btntrove
            // 
            this.btntrove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btntrove.Location = new System.Drawing.Point(172, 264);
            this.btntrove.Name = "btntrove";
            this.btntrove.Size = new System.Drawing.Size(75, 23);
            this.btntrove.TabIndex = 2;
            this.btntrove.Text = "Trở về";
            this.btntrove.UseVisualStyleBackColor = true;
            this.btntrove.Click += new System.EventHandler(this.btntrove_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Image = global::PhamNgocPhung_18607081.Properties.Resources.p;
            this.button1.Location = new System.Drawing.Point(367, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // danhmuc
            // 
            this.AcceptButton = this.btntrove;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(421, 299);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btntrove);
            this.Controls.Add(this.dgvdanhmuc);
            this.Controls.Add(this.lbdanhmuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "danhmuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "danhmucbanquanao";
            this.Load += new System.EventHandler(this.danhmuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanhmuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbdanhmuc;
        private System.Windows.Forms.DataGridView dgvdanhmuc;
        private System.Windows.Forms.Button btntrove;
        private System.Windows.Forms.Button button1;
    }
}