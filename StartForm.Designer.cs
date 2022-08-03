namespace _2048WinFormsApp
{
    partial class StartForm
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
            this.inputUserNameTextBox = new System.Windows.Forms.TextBox();
            this.okayButton = new System.Windows.Forms.Button();
            this.fieldSizeComboBox = new System.Windows.Forms.ComboBox();
            this.fieldSizeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputUserNameTextBox
            // 
            this.inputUserNameTextBox.Location = new System.Drawing.Point(75, 68);
            this.inputUserNameTextBox.Name = "inputUserNameTextBox";
            this.inputUserNameTextBox.Size = new System.Drawing.Size(115, 23);
            this.inputUserNameTextBox.TabIndex = 1;
            this.inputUserNameTextBox.Text = "Введите ваше имя...";
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(90, 189);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(81, 43);
            this.okayButton.TabIndex = 2;
            this.okayButton.Text = "okay";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // fieldSizeComboBox
            // 
            this.fieldSizeComboBox.FormattingEnabled = true;
            this.fieldSizeComboBox.Items.AddRange(new object[] {
            "2 x 2",
            "3 x 3",
            "4 x 4",
            "5 x 5",
            "6 x 6"});
            this.fieldSizeComboBox.Location = new System.Drawing.Point(105, 137);
            this.fieldSizeComboBox.Name = "fieldSizeComboBox";
            this.fieldSizeComboBox.Size = new System.Drawing.Size(52, 23);
            this.fieldSizeComboBox.TabIndex = 3;
            this.fieldSizeComboBox.Text = "2 x 2";
            // 
            // fieldSizeLabel
            // 
            this.fieldSizeLabel.AutoSize = true;
            this.fieldSizeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fieldSizeLabel.Location = new System.Drawing.Point(105, 119);
            this.fieldSizeLabel.Name = "fieldSizeLabel";
            this.fieldSizeLabel.Size = new System.Drawing.Size(52, 15);
            this.fieldSizeLabel.TabIndex = 4;
            this.fieldSizeLabel.Text = "field size";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 244);
            this.Controls.Add(this.fieldSizeLabel);
            this.Controls.Add(this.fieldSizeComboBox);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.inputUserNameTextBox);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox inputUserNameTextBox;
        private System.Windows.Forms.Button okayButton;
        public System.Windows.Forms.ComboBox fieldSizeComboBox;
        private System.Windows.Forms.Label fieldSizeLabel;
    }
}