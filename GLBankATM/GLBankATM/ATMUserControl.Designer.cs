namespace GLBankATM
{
    partial class ATMUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSkuska = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSkuska
            // 
            this.lblSkuska.AutoSize = true;
            this.lblSkuska.Location = new System.Drawing.Point(121, 114);
            this.lblSkuska.Name = "lblSkuska";
            this.lblSkuska.Size = new System.Drawing.Size(35, 13);
            this.lblSkuska.TabIndex = 0;
            this.lblSkuska.Text = "label1";
            this.lblSkuska.Click += new System.EventHandler(this.lblSkuska_Click);
            // 
            // ATMUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSkuska);
            this.Name = "ATMUserControl";
            this.Size = new System.Drawing.Size(456, 363);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSkuska;
    }
}
