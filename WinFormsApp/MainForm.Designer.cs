namespace WinFormsApp
{
    partial class MainForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.headerControl = new WinFormsApp.Controls.HeaderControl();
            this.pnlFotter = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnNewList = new System.Windows.Forms.Button();
            this.pnlWordListsSection = new System.Windows.Forms.Panel();
            this.lbWordLists = new System.Windows.Forms.ListBox();
            this.pnlWordLists = new System.Windows.Forms.Panel();
            this.lblWordLists = new System.Windows.Forms.Label();
            this.pnlLanguagesSection = new System.Windows.Forms.Panel();
            this.lbLanguages = new System.Windows.Forms.ListBox();
            this.pnlLanguages = new System.Windows.Forms.Panel();
            this.lblLanguages = new System.Windows.Forms.Label();
            this.WordlistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlFotter.SuspendLayout();
            this.pnlWordListsSection.SuspendLayout();
            this.pnlWordLists.SuspendLayout();
            this.pnlLanguagesSection.SuspendLayout();
            this.pnlLanguages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WordlistBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.headerControl);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1374, 194);
            this.pnlHeader.TabIndex = 0;
            // 
            // headerControl
            // 
            this.headerControl.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.headerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerControl.Location = new System.Drawing.Point(0, 0);
            this.headerControl.Name = "headerControl";
            this.headerControl.Size = new System.Drawing.Size(1374, 194);
            this.headerControl.TabIndex = 0;
            // 
            // pnlFotter
            // 
            this.pnlFotter.Controls.Add(this.btnSelect);
            this.pnlFotter.Controls.Add(this.btnNewList);
            this.pnlFotter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFotter.Location = new System.Drawing.Point(0, 733);
            this.pnlFotter.Name = "pnlFotter";
            this.pnlFotter.Size = new System.Drawing.Size(1374, 96);
            this.pnlFotter.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(1160, 27);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(202, 46);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnNewList
            // 
            this.btnNewList.Location = new System.Drawing.Point(12, 27);
            this.btnNewList.Name = "btnNewList";
            this.btnNewList.Size = new System.Drawing.Size(202, 46);
            this.btnNewList.TabIndex = 0;
            this.btnNewList.Text = "New Wordlist";
            this.btnNewList.UseVisualStyleBackColor = true;
            // 
            // pnlWordListsSection
            // 
            this.pnlWordListsSection.Controls.Add(this.lbWordLists);
            this.pnlWordListsSection.Controls.Add(this.pnlWordLists);
            this.pnlWordListsSection.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlWordListsSection.Location = new System.Drawing.Point(0, 194);
            this.pnlWordListsSection.Name = "pnlWordListsSection";
            this.pnlWordListsSection.Size = new System.Drawing.Size(681, 539);
            this.pnlWordListsSection.TabIndex = 2;
            // 
            // lbWordLists
            // 
            this.lbWordLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbWordLists.FormattingEnabled = true;
            this.lbWordLists.ItemHeight = 32;
            this.lbWordLists.Location = new System.Drawing.Point(0, 81);
            this.lbWordLists.Name = "lbWordLists";
            this.lbWordLists.Size = new System.Drawing.Size(681, 458);
            this.lbWordLists.TabIndex = 1;
            // 
            // pnlWordLists
            // 
            this.pnlWordLists.Controls.Add(this.lblWordLists);
            this.pnlWordLists.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWordLists.Location = new System.Drawing.Point(0, 0);
            this.pnlWordLists.Name = "pnlWordLists";
            this.pnlWordLists.Size = new System.Drawing.Size(681, 81);
            this.pnlWordLists.TabIndex = 0;
            // 
            // lblWordLists
            // 
            this.lblWordLists.AutoSize = true;
            this.lblWordLists.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWordLists.Location = new System.Drawing.Point(12, 14);
            this.lblWordLists.Name = "lblWordLists";
            this.lblWordLists.Size = new System.Drawing.Size(169, 45);
            this.lblWordLists.TabIndex = 0;
            this.lblWordLists.Text = "WordLists";
            // 
            // pnlLanguagesSection
            // 
            this.pnlLanguagesSection.Controls.Add(this.lbLanguages);
            this.pnlLanguagesSection.Controls.Add(this.pnlLanguages);
            this.pnlLanguagesSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLanguagesSection.Location = new System.Drawing.Point(681, 194);
            this.pnlLanguagesSection.Name = "pnlLanguagesSection";
            this.pnlLanguagesSection.Size = new System.Drawing.Size(693, 539);
            this.pnlLanguagesSection.TabIndex = 3;
            // 
            // lbLanguages
            // 
            this.lbLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLanguages.FormattingEnabled = true;
            this.lbLanguages.ItemHeight = 32;
            this.lbLanguages.Location = new System.Drawing.Point(0, 81);
            this.lbLanguages.Name = "lbLanguages";
            this.lbLanguages.Size = new System.Drawing.Size(693, 458);
            this.lbLanguages.TabIndex = 1;
            // 
            // pnlLanguages
            // 
            this.pnlLanguages.Controls.Add(this.lblLanguages);
            this.pnlLanguages.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLanguages.Location = new System.Drawing.Point(0, 0);
            this.pnlLanguages.Name = "pnlLanguages";
            this.pnlLanguages.Size = new System.Drawing.Size(693, 81);
            this.pnlLanguages.TabIndex = 0;
            // 
            // lblLanguages
            // 
            this.lblLanguages.AutoSize = true;
            this.lblLanguages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLanguages.Location = new System.Drawing.Point(6, 14);
            this.lblLanguages.Name = "lblLanguages";
            this.lblLanguages.Size = new System.Drawing.Size(179, 45);
            this.lblLanguages.TabIndex = 1;
            this.lblLanguages.Text = "Languages";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1374, 829);
            this.Controls.Add(this.pnlLanguagesSection);
            this.Controls.Add(this.pnlWordListsSection);
            this.Controls.Add(this.pnlFotter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "MainForm";
            this.Text = "Vocabulary Trainer V.1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFotter.ResumeLayout(false);
            this.pnlWordListsSection.ResumeLayout(false);
            this.pnlWordLists.ResumeLayout(false);
            this.pnlWordLists.PerformLayout();
            this.pnlLanguagesSection.ResumeLayout(false);
            this.pnlLanguages.ResumeLayout(false);
            this.pnlLanguages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WordlistBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFotter;
        private System.Windows.Forms.Panel pnlWordListsSection;
        private System.Windows.Forms.Panel pnlLanguagesSection;
        private System.Windows.Forms.ListBox lbWordLists;
        private System.Windows.Forms.Panel pnlWordLists;
        private System.Windows.Forms.Label lblWordLists;
        private System.Windows.Forms.ListBox lbLanguages;
        private System.Windows.Forms.Panel pnlLanguages;
        private System.Windows.Forms.Label lblLanguages;
        private Controls.HeaderControl headerControl;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnNewList;
        private System.Windows.Forms.BindingSource WordlistBindingSource;
    }
}