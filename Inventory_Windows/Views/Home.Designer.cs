namespace Inventory_Windows
{
    partial class Home
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
            this.btnMtsKafila = new System.Windows.Forms.Button();
            this.btnMtsFullDay = new System.Windows.Forms.Button();
            this.btnMtsAlkahfi = new System.Windows.Forms.Button();
            this.btnMasKafila = new System.Windows.Forms.Button();
            this.btnYayasan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Silakan Pilih Lembaga";
            // 
            // btnMtsKafila
            // 
            this.btnMtsKafila.Location = new System.Drawing.Point(60, 91);
            this.btnMtsKafila.Name = "btnMtsKafila";
            this.btnMtsKafila.Size = new System.Drawing.Size(92, 23);
            this.btnMtsKafila.TabIndex = 1;
            this.btnMtsKafila.Text = "MTS Kafila";
            this.btnMtsKafila.UseVisualStyleBackColor = true;
            this.btnMtsKafila.Click += new System.EventHandler(this.btnMtsKafila_Click);
            // 
            // btnMtsFullDay
            // 
            this.btnMtsFullDay.Location = new System.Drawing.Point(60, 120);
            this.btnMtsFullDay.Name = "btnMtsFullDay";
            this.btnMtsFullDay.Size = new System.Drawing.Size(92, 23);
            this.btnMtsFullDay.TabIndex = 2;
            this.btnMtsFullDay.Text = "MTS Fullday";
            this.btnMtsFullDay.UseVisualStyleBackColor = true;
            this.btnMtsFullDay.Click += new System.EventHandler(this.btnMtsFullDay_Click);
            // 
            // btnMtsAlkahfi
            // 
            this.btnMtsAlkahfi.Location = new System.Drawing.Point(60, 149);
            this.btnMtsAlkahfi.Name = "btnMtsAlkahfi";
            this.btnMtsAlkahfi.Size = new System.Drawing.Size(92, 23);
            this.btnMtsAlkahfi.TabIndex = 3;
            this.btnMtsAlkahfi.Text = "MTS Al-Kahfi";
            this.btnMtsAlkahfi.UseVisualStyleBackColor = true;
            this.btnMtsAlkahfi.Click += new System.EventHandler(this.btnMtsAlkahfi_Click);
            // 
            // btnMasKafila
            // 
            this.btnMasKafila.Location = new System.Drawing.Point(60, 178);
            this.btnMasKafila.Name = "btnMasKafila";
            this.btnMasKafila.Size = new System.Drawing.Size(92, 23);
            this.btnMasKafila.TabIndex = 4;
            this.btnMasKafila.Text = "MAS Kafila";
            this.btnMasKafila.UseVisualStyleBackColor = true;
            this.btnMasKafila.Click += new System.EventHandler(this.btnMasKafila_Click);
            // 
            // btnYayasan
            // 
            this.btnYayasan.Location = new System.Drawing.Point(60, 207);
            this.btnYayasan.Name = "btnYayasan";
            this.btnYayasan.Size = new System.Drawing.Size(92, 23);
            this.btnYayasan.TabIndex = 5;
            this.btnYayasan.Text = "Yayasan";
            this.btnYayasan.UseVisualStyleBackColor = true;
            this.btnYayasan.Click += new System.EventHandler(this.btnYayasan_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(370, 318);
            this.Controls.Add(this.btnYayasan);
            this.Controls.Add(this.btnMasKafila);
            this.Controls.Add(this.btnMtsAlkahfi);
            this.Controls.Add(this.btnMtsFullDay);
            this.Controls.Add(this.btnMtsKafila);
            this.Controls.Add(this.label1);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMtsKafila;
        private System.Windows.Forms.Button btnMtsFullDay;
        private System.Windows.Forms.Button btnMtsAlkahfi;
        private System.Windows.Forms.Button btnMasKafila;
        private System.Windows.Forms.Button btnYayasan;
    }
}