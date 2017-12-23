namespace Techl.TestForm
{
    partial class TextBoxHelperTestForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.NullableCurrencyTextBox = new System.Windows.Forms.TextBox();
            this.NullableCurrencyShowButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NullableCurrencyTextBox
            // 
            this.NullableCurrencyTextBox.Location = new System.Drawing.Point(12, 67);
            this.NullableCurrencyTextBox.Name = "NullableCurrencyTextBox";
            this.NullableCurrencyTextBox.Size = new System.Drawing.Size(100, 20);
            this.NullableCurrencyTextBox.TabIndex = 2;
            // 
            // NullableCurrencyShowButton
            // 
            this.NullableCurrencyShowButton.Location = new System.Drawing.Point(36, 94);
            this.NullableCurrencyShowButton.Name = "NullableCurrencyShowButton";
            this.NullableCurrencyShowButton.Size = new System.Drawing.Size(75, 23);
            this.NullableCurrencyShowButton.TabIndex = 3;
            this.NullableCurrencyShowButton.Text = "button2";
            this.NullableCurrencyShowButton.UseVisualStyleBackColor = true;
            this.NullableCurrencyShowButton.Click += new System.EventHandler(this.NullableCurrencyShowButton_Click);
            // 
            // TextBoxHelperTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.NullableCurrencyShowButton);
            this.Controls.Add(this.NullableCurrencyTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "TextBoxHelperTestForm";
            this.Text = "TextBoxHelperTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NullableCurrencyTextBox;
        private System.Windows.Forms.Button NullableCurrencyShowButton;
    }
}