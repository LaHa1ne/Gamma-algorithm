namespace Gamma_algorithm_with_visualization
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ввестиДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сКлавиатурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проверитьНаПланарностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завершениеРаботыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ввестиДанныеToolStripMenuItem,
            this.проверитьНаПланарностьToolStripMenuItem,
            this.завершениеРаботыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(412, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ввестиДанныеToolStripMenuItem
            // 
            this.ввестиДанныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изФайлаToolStripMenuItem,
            this.сКлавиатурыToolStripMenuItem});
            this.ввестиДанныеToolStripMenuItem.Name = "ввестиДанныеToolStripMenuItem";
            this.ввестиДанныеToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.ввестиДанныеToolStripMenuItem.Text = "Ввести данные";
            this.ввестиДанныеToolStripMenuItem.Click += new System.EventHandler(this.ввестиДанныеToolStripMenuItem_Click);
            // 
            // изФайлаToolStripMenuItem
            // 
            this.изФайлаToolStripMenuItem.Name = "изФайлаToolStripMenuItem";
            this.изФайлаToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.изФайлаToolStripMenuItem.Text = "из файла";
            this.изФайлаToolStripMenuItem.Click += new System.EventHandler(this.изФайлаToolStripMenuItem_Click_1);
            // 
            // сКлавиатурыToolStripMenuItem
            // 
            this.сКлавиатурыToolStripMenuItem.Name = "сКлавиатурыToolStripMenuItem";
            this.сКлавиатурыToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.сКлавиатурыToolStripMenuItem.Text = "с клавиатуры";
            this.сКлавиатурыToolStripMenuItem.Click += new System.EventHandler(this.сКлавиатурыToolStripMenuItem_Click);
            // 
            // проверитьНаПланарностьToolStripMenuItem
            // 
            this.проверитьНаПланарностьToolStripMenuItem.Name = "проверитьНаПланарностьToolStripMenuItem";
            this.проверитьНаПланарностьToolStripMenuItem.Size = new System.Drawing.Size(169, 20);
            this.проверитьНаПланарностьToolStripMenuItem.Text = "Проверить на планарность";
            this.проверитьНаПланарностьToolStripMenuItem.Click += new System.EventHandler(this.проверитьНаПланарностьToolStripMenuItem_Click);
            // 
            // завершениеРаботыToolStripMenuItem
            // 
            this.завершениеРаботыToolStripMenuItem.Name = "завершениеРаботыToolStripMenuItem";
            this.завершениеРаботыToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.завершениеРаботыToolStripMenuItem.Text = "Завершение работы";
            this.завершениеРаботыToolStripMenuItem.Click += new System.EventHandler(this.завершениеРаботыToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 31);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ввестиДанныеToolStripMenuItem;
        private ToolStripMenuItem изФайлаToolStripMenuItem;
        private ToolStripMenuItem сКлавиатурыToolStripMenuItem;
        private ToolStripMenuItem проверитьНаПланарностьToolStripMenuItem;
        private ToolStripMenuItem завершениеРаботыToolStripMenuItem;
    }
}