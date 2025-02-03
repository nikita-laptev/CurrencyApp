namespace CurrencyApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.ComboBox comboBoxTo;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.Button buttonSwap;
        private System.Windows.Forms.Label labelRate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxTo = new System.Windows.Forms.ComboBox();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.buttonSwap = new System.Windows.Forms.Button();
            this.labelRate = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Настройка comboBoxFrom
            this.comboBoxFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.Location = new System.Drawing.Point(20, 20);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.Size = new System.Drawing.Size(100, 21);

            // Настройка textBoxFrom
            this.textBoxFrom.Location = new System.Drawing.Point(20, 60);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(100, 20);

            // Настройка comboBoxTo
            this.comboBoxTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTo.FormattingEnabled = true;
            this.comboBoxTo.Location = new System.Drawing.Point(200, 20);
            this.comboBoxTo.Name = "comboBoxTo";
            this.comboBoxTo.Size = new System.Drawing.Size(100, 21);

            // Настройка textBoxTo
            this.textBoxTo.Location = new System.Drawing.Point(200, 60);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.ReadOnly = true;
            this.textBoxTo.Size = new System.Drawing.Size(100, 20);

            // Настройка buttonSwap
            this.buttonSwap.Location = new System.Drawing.Point(140, 20);
            this.buttonSwap.Name = "buttonSwap";
            this.buttonSwap.Size = new System.Drawing.Size(40, 23);
            this.buttonSwap.Text = "⇄";
            this.buttonSwap.UseVisualStyleBackColor = true;

            // Настройка labelRate
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(20, 100);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(80, 13);
            this.labelRate.Text = "Курс: 1 USD = ...";

            // Настройка Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 140);
            this.Controls.Add(this.labelRate);
            this.Controls.Add(this.buttonSwap);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.comboBoxTo);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.comboBoxFrom);
            this.Name = "Form1";
            this.Text = "Конвертер валют";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}