
namespace CourseProject
{
    partial class School
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(School));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marksControl = new System.Windows.Forms.TabControl();
            this.studentsPage = new System.Windows.Forms.TabPage();
            this.studentsGridView = new System.Windows.Forms.DataGridView();
            this.teachersPage = new System.Windows.Forms.TabPage();
            this.teachersGridView = new System.Windows.Forms.DataGridView();
            this.classPage = new System.Windows.Forms.TabPage();
            this.classesGridView = new System.Windows.Forms.DataGridView();
            this.subjectPage = new System.Windows.Forms.TabPage();
            this.subjectsGridView = new System.Windows.Forms.DataGridView();
            this.marksPage = new System.Windows.Forms.TabPage();
            this.marksGridView = new System.Windows.Forms.DataGridView();
            this.classBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.insertButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.marksControl.SuspendLayout();
            this.studentsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentsGridView)).BeginInit();
            this.teachersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teachersGridView)).BeginInit();
            this.classPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classesGridView)).BeginInit();
            this.subjectPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsGridView)).BeginInit();
            this.marksPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(700, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.closeToolStripMenuItem.Text = "Закрыть";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.ResetFilterToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.viewToolStripMenuItem.Text = "Поиск и фильтр";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.searchToolStripMenuItem.Text = "Поиск...";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.filterToolStripMenuItem.Text = "Фильтр...";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // ResetFilterToolStripMenuItem
            // 
            this.ResetFilterToolStripMenuItem.Enabled = false;
            this.ResetFilterToolStripMenuItem.Name = "ResetFilterToolStripMenuItem";
            this.ResetFilterToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ResetFilterToolStripMenuItem.Text = "Сбросить фильтр";
            this.ResetFilterToolStripMenuItem.Click += new System.EventHandler(this.ResetFilterToolStripMenuItem_Click);
            // 
            // marksControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.marksControl, 3);
            this.marksControl.Controls.Add(this.studentsPage);
            this.marksControl.Controls.Add(this.teachersPage);
            this.marksControl.Controls.Add(this.classPage);
            this.marksControl.Controls.Add(this.subjectPage);
            this.marksControl.Controls.Add(this.marksPage);
            this.marksControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marksControl.Location = new System.Drawing.Point(0, 0);
            this.marksControl.Margin = new System.Windows.Forms.Padding(0);
            this.marksControl.Name = "marksControl";
            this.marksControl.SelectedIndex = 0;
            this.marksControl.Size = new System.Drawing.Size(700, 291);
            this.marksControl.TabIndex = 1;
            this.marksControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // studentsPage
            // 
            this.studentsPage.Controls.Add(this.studentsGridView);
            this.studentsPage.Location = new System.Drawing.Point(4, 24);
            this.studentsPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.studentsPage.Name = "studentsPage";
            this.studentsPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.studentsPage.Size = new System.Drawing.Size(692, 263);
            this.studentsPage.TabIndex = 0;
            this.studentsPage.Text = "Ученики";
            this.studentsPage.UseVisualStyleBackColor = true;
            // 
            // studentsGridView
            // 
            this.studentsGridView.AllowUserToAddRows = false;
            this.studentsGridView.AllowUserToDeleteRows = false;
            this.studentsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.studentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentsGridView.Location = new System.Drawing.Point(3, 2);
            this.studentsGridView.Margin = new System.Windows.Forms.Padding(0);
            this.studentsGridView.Name = "studentsGridView";
            this.studentsGridView.RowHeadersWidth = 51;
            this.studentsGridView.RowTemplate.Height = 29;
            this.studentsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studentsGridView.Size = new System.Drawing.Size(686, 259);
            this.studentsGridView.TabIndex = 0;
            this.studentsGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.studentsGridView_CellValidating);
            this.studentsGridView.SelectionChanged += new System.EventHandler(this.studentsGridView_SelectionChanged);
            // 
            // teachersPage
            // 
            this.teachersPage.Controls.Add(this.teachersGridView);
            this.teachersPage.Location = new System.Drawing.Point(4, 24);
            this.teachersPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.teachersPage.Name = "teachersPage";
            this.teachersPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.teachersPage.Size = new System.Drawing.Size(692, 263);
            this.teachersPage.TabIndex = 1;
            this.teachersPage.Text = "Учителя";
            this.teachersPage.UseVisualStyleBackColor = true;
            // 
            // teachersGridView
            // 
            this.teachersGridView.AllowUserToAddRows = false;
            this.teachersGridView.AllowUserToDeleteRows = false;
            this.teachersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.teachersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teachersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teachersGridView.Location = new System.Drawing.Point(3, 2);
            this.teachersGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.teachersGridView.Name = "teachersGridView";
            this.teachersGridView.RowHeadersWidth = 51;
            this.teachersGridView.RowTemplate.Height = 29;
            this.teachersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.teachersGridView.Size = new System.Drawing.Size(686, 259);
            this.teachersGridView.TabIndex = 0;
            this.teachersGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.teachersGridView_CellValidating);
            this.teachersGridView.SelectionChanged += new System.EventHandler(this.teachersGridView_SelectionChanged);
            // 
            // classPage
            // 
            this.classPage.Controls.Add(this.classesGridView);
            this.classPage.Location = new System.Drawing.Point(4, 24);
            this.classPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.classPage.Name = "classPage";
            this.classPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.classPage.Size = new System.Drawing.Size(692, 263);
            this.classPage.TabIndex = 2;
            this.classPage.Text = "Классы";
            this.classPage.UseVisualStyleBackColor = true;
            // 
            // classesGridView
            // 
            this.classesGridView.AllowUserToAddRows = false;
            this.classesGridView.AllowUserToDeleteRows = false;
            this.classesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.classesGridView.ColumnHeadersHeight = 29;
            this.classesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.classesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classesGridView.Location = new System.Drawing.Point(3, 2);
            this.classesGridView.Margin = new System.Windows.Forms.Padding(0);
            this.classesGridView.Name = "classesGridView";
            this.classesGridView.RowHeadersWidth = 51;
            this.classesGridView.RowTemplate.Height = 29;
            this.classesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.classesGridView.Size = new System.Drawing.Size(686, 259);
            this.classesGridView.TabIndex = 0;
            this.classesGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.classesGridView_CellValidating);
            this.classesGridView.SelectionChanged += new System.EventHandler(this.classesGridView_SelectionChanged);
            // 
            // subjectPage
            // 
            this.subjectPage.Controls.Add(this.subjectsGridView);
            this.subjectPage.Location = new System.Drawing.Point(4, 24);
            this.subjectPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.subjectPage.Name = "subjectPage";
            this.subjectPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.subjectPage.Size = new System.Drawing.Size(692, 263);
            this.subjectPage.TabIndex = 3;
            this.subjectPage.Text = "Предметы";
            this.subjectPage.UseVisualStyleBackColor = true;
            // 
            // subjectsGridView
            // 
            this.subjectsGridView.AllowUserToAddRows = false;
            this.subjectsGridView.AllowUserToDeleteRows = false;
            this.subjectsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectsGridView.Location = new System.Drawing.Point(3, 2);
            this.subjectsGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.subjectsGridView.Name = "subjectsGridView";
            this.subjectsGridView.RowHeadersWidth = 51;
            this.subjectsGridView.RowTemplate.Height = 29;
            this.subjectsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subjectsGridView.Size = new System.Drawing.Size(686, 259);
            this.subjectsGridView.TabIndex = 0;
            this.subjectsGridView.SelectionChanged += new System.EventHandler(this.subjectsGridView_SelectionChanged);
            // 
            // marksPage
            // 
            this.marksPage.Controls.Add(this.marksGridView);
            this.marksPage.Location = new System.Drawing.Point(4, 24);
            this.marksPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.marksPage.Name = "marksPage";
            this.marksPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.marksPage.Size = new System.Drawing.Size(692, 263);
            this.marksPage.TabIndex = 4;
            this.marksPage.Text = "Успеваемость";
            this.marksPage.UseVisualStyleBackColor = true;
            // 
            // marksGridView
            // 
            this.marksGridView.AllowUserToAddRows = false;
            this.marksGridView.AllowUserToDeleteRows = false;
            this.marksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.marksGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marksGridView.Location = new System.Drawing.Point(3, 2);
            this.marksGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.marksGridView.Name = "marksGridView";
            this.marksGridView.RowHeadersWidth = 51;
            this.marksGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.marksGridView.Size = new System.Drawing.Size(686, 259);
            this.marksGridView.TabIndex = 0;
            this.marksGridView.SelectionChanged += new System.EventHandler(this.marksGridView_SelectionChanged);
            // 
            // classBindingSource
            // 
            this.classBindingSource.DataSource = typeof(CourseProject.Class);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.marksControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.insertButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.deleteButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 317);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // insertButton
            // 
            this.insertButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insertButton.Location = new System.Drawing.Point(0, 291);
            this.insertButton.Margin = new System.Windows.Forms.Padding(0);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(140, 26);
            this.insertButton.TabIndex = 2;
            this.insertButton.Text = "Вставить строку";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(140, 291);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(140, 26);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Удалить строки";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // School
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(700, 341);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "School";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Школа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.school_FormClosing);
            this.Load += new System.EventHandler(this.school_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.marksControl.ResumeLayout(false);
            this.studentsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentsGridView)).EndInit();
            this.teachersPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teachersGridView)).EndInit();
            this.classPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.classesGridView)).EndInit();
            this.subjectPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.subjectsGridView)).EndInit();
            this.marksPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.marksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.TabControl marksControl;
        private System.Windows.Forms.TabPage studentsPage;
        private System.Windows.Forms.TabPage teachersPage;
        private System.Windows.Forms.TabPage classPage;
        private System.Windows.Forms.DataGridView studentsGridView;
        private System.Windows.Forms.DataGridView teachersGridView;
        private System.Windows.Forms.DataGridView classesGridView;
        private System.Windows.Forms.ToolStripMenuItem ResetFilterToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TabPage subjectPage;
        private System.Windows.Forms.DataGridView subjectsGridView;
        private System.Windows.Forms.TabPage marksPage;
        private System.Windows.Forms.DataGridView marksGridView;
        private System.Windows.Forms.BindingSource classBindingSource;
    }
}

