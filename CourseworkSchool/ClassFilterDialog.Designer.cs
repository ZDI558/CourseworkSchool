
namespace CourseProject
{
    partial class ClassFilterDialog 
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
            this.components = new System.ComponentModel.Container();
            this.FormCancelButton = new System.Windows.Forms.Button();
            this.FormOkButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // FormCancelButton
            // 
            this.FormCancelButton.Location = new System.Drawing.Point(495, 41);
            this.FormCancelButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.FormCancelButton.Name = "FormCancelButton";
            this.FormCancelButton.Size = new System.Drawing.Size(88, 26);
            this.FormCancelButton.TabIndex = 4;
            this.FormCancelButton.Text = "Отмена";
            this.FormCancelButton.UseVisualStyleBackColor = true;
            this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButton_Click);
            // 
            // FormOkButton
            // 
            this.FormOkButton.Location = new System.Drawing.Point(400, 41);
            this.FormOkButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.FormOkButton.Name = "FormOkButton";
            this.FormOkButton.Size = new System.Drawing.Size(88, 26);
            this.FormOkButton.TabIndex = 3;
            this.FormOkButton.Text = "ОК";
            this.FormOkButton.UseVisualStyleBackColor = true;
            this.FormOkButton.Click += new System.EventHandler(this.FormOkButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID учителя";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(104, 8);
            this.textBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(478, 27);
            this.textBox.TabIndex = 14;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ClassFilterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(601, 74);
            this.ControlBox = false;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.FormCancelButton);
            this.Controls.Add(this.FormOkButton);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassFilterDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фильтр";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MoneyOperationFilterDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button FormCancelButton;
        private System.Windows.Forms.Button FormOkButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}