namespace Techl.TestForm
{
    partial class ControlBindingHelperTestForm
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
            this.EnumBindingComboBox = new System.Windows.Forms.ComboBox();
            this.EnumBindingComboBoxValueTextBox = new System.Windows.Forms.TextBox();
            this.ObjectBindingComboBox = new System.Windows.Forms.ComboBox();
            this.ObjectBindingComboBoxValueTextBox = new System.Windows.Forms.TextBox();
            this.EnumComboBoxLabel = new System.Windows.Forms.Label();
            this.ObjectComboBoxLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SimpleBindingComboBoxValueTextBox = new System.Windows.Forms.TextBox();
            this.SimpleBindingComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // EnumBindingComboBox
            // 
            this.EnumBindingComboBox.FormattingEnabled = true;
            this.EnumBindingComboBox.Location = new System.Drawing.Point(150, 39);
            this.EnumBindingComboBox.Name = "EnumBindingComboBox";
            this.EnumBindingComboBox.Size = new System.Drawing.Size(121, 21);
            this.EnumBindingComboBox.TabIndex = 0;
            // 
            // EnumBindingComboBoxValueTextBox
            // 
            this.EnumBindingComboBoxValueTextBox.Location = new System.Drawing.Point(277, 39);
            this.EnumBindingComboBoxValueTextBox.Name = "EnumBindingComboBoxValueTextBox";
            this.EnumBindingComboBoxValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.EnumBindingComboBoxValueTextBox.TabIndex = 1;
            // 
            // ObjectBindingComboBox
            // 
            this.ObjectBindingComboBox.FormattingEnabled = true;
            this.ObjectBindingComboBox.Location = new System.Drawing.Point(150, 66);
            this.ObjectBindingComboBox.Name = "ObjectBindingComboBox";
            this.ObjectBindingComboBox.Size = new System.Drawing.Size(121, 21);
            this.ObjectBindingComboBox.TabIndex = 2;
            // 
            // ObjectBindingComboBoxValueTextBox
            // 
            this.ObjectBindingComboBoxValueTextBox.Location = new System.Drawing.Point(277, 66);
            this.ObjectBindingComboBoxValueTextBox.Name = "ObjectBindingComboBoxValueTextBox";
            this.ObjectBindingComboBoxValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.ObjectBindingComboBoxValueTextBox.TabIndex = 3;
            // 
            // EnumComboBoxLabel
            // 
            this.EnumComboBoxLabel.AutoSize = true;
            this.EnumComboBoxLabel.Location = new System.Drawing.Point(12, 42);
            this.EnumComboBoxLabel.Name = "EnumComboBoxLabel";
            this.EnumComboBoxLabel.Size = new System.Drawing.Size(132, 13);
            this.EnumComboBoxLabel.TabIndex = 4;
            this.EnumComboBoxLabel.Text = "Enum ComboBox Binding :";
            // 
            // ObjectComboBoxLabel
            // 
            this.ObjectComboBoxLabel.AutoSize = true;
            this.ObjectComboBoxLabel.Location = new System.Drawing.Point(12, 69);
            this.ObjectComboBoxLabel.Name = "ObjectComboBoxLabel";
            this.ObjectComboBoxLabel.Size = new System.Drawing.Size(136, 13);
            this.ObjectComboBoxLabel.TabIndex = 5;
            this.ObjectComboBoxLabel.Text = "Object ComboBox Binding :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Simple ComboBox Binding :";
            // 
            // SimpleBindingComboBoxValueTextBox
            // 
            this.SimpleBindingComboBoxValueTextBox.Location = new System.Drawing.Point(277, 12);
            this.SimpleBindingComboBoxValueTextBox.Name = "SimpleBindingComboBoxValueTextBox";
            this.SimpleBindingComboBoxValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.SimpleBindingComboBoxValueTextBox.TabIndex = 8;
            // 
            // SimpleBindingComboBox
            // 
            this.SimpleBindingComboBox.FormattingEnabled = true;
            this.SimpleBindingComboBox.Location = new System.Drawing.Point(150, 12);
            this.SimpleBindingComboBox.Name = "SimpleBindingComboBox";
            this.SimpleBindingComboBox.Size = new System.Drawing.Size(121, 21);
            this.SimpleBindingComboBox.TabIndex = 7;
            // 
            // ControlBindingHelperTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 426);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SimpleBindingComboBoxValueTextBox);
            this.Controls.Add(this.SimpleBindingComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ObjectComboBoxLabel);
            this.Controls.Add(this.EnumComboBoxLabel);
            this.Controls.Add(this.ObjectBindingComboBoxValueTextBox);
            this.Controls.Add(this.ObjectBindingComboBox);
            this.Controls.Add(this.EnumBindingComboBoxValueTextBox);
            this.Controls.Add(this.EnumBindingComboBox);
            this.Name = "ControlBindingHelperTestForm";
            this.Text = "ControlBindingHelperTestForm";
            this.Load += new System.EventHandler(this.ControlBindingHelperTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EnumBindingComboBox;
        private System.Windows.Forms.TextBox EnumBindingComboBoxValueTextBox;
        private System.Windows.Forms.ComboBox ObjectBindingComboBox;
        private System.Windows.Forms.TextBox ObjectBindingComboBoxValueTextBox;
        private System.Windows.Forms.Label EnumComboBoxLabel;
        private System.Windows.Forms.Label ObjectComboBoxLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SimpleBindingComboBoxValueTextBox;
        private System.Windows.Forms.ComboBox SimpleBindingComboBox;
    }
}