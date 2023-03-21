namespace Gamma_algorithm_with_visualization
{
    partial class InputFromKeyboard
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
            this.NumVertices_label = new System.Windows.Forms.Label();
            this.NumVertices_textBox = new System.Windows.Forms.TextBox();
            this.InputNumVertices_button = new System.Windows.Forms.Button();
            this.CloseInputForm_button = new System.Windows.Forms.Button();
            this.CloseInputForm_button2 = new System.Windows.Forms.Button();
            this.InputGraphMatrix_button = new System.Windows.Forms.Button();
            this.GraphMatrix_label = new System.Windows.Forms.Label();
            this.GraphMatrix_dataGridView = new System.Windows.Forms.DataGridView();
            this.GraphMatrix_panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.GraphMatrix_dataGridView)).BeginInit();
            this.GraphMatrix_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NumVertices_label
            // 
            this.NumVertices_label.AutoSize = true;
            this.NumVertices_label.Location = new System.Drawing.Point(12, 9);
            this.NumVertices_label.Name = "NumVertices_label";
            this.NumVertices_label.Size = new System.Drawing.Size(89, 15);
            this.NumVertices_label.TabIndex = 0;
            this.NumVertices_label.Text = "Число вершин";
            // 
            // NumVertices_textBox
            // 
            this.NumVertices_textBox.Location = new System.Drawing.Point(12, 27);
            this.NumVertices_textBox.Name = "NumVertices_textBox";
            this.NumVertices_textBox.Size = new System.Drawing.Size(89, 23);
            this.NumVertices_textBox.TabIndex = 1;
            // 
            // InputNumVertices_button
            // 
            this.InputNumVertices_button.Location = new System.Drawing.Point(124, 9);
            this.InputNumVertices_button.Name = "InputNumVertices_button";
            this.InputNumVertices_button.Size = new System.Drawing.Size(138, 23);
            this.InputNumVertices_button.TabIndex = 2;
            this.InputNumVertices_button.Text = "Ввести число вершин";
            this.InputNumVertices_button.UseVisualStyleBackColor = true;
            this.InputNumVertices_button.Click += new System.EventHandler(this.InputNumVertex_button_Click);
            // 
            // CloseInputForm_button
            // 
            this.CloseInputForm_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseInputForm_button.Location = new System.Drawing.Point(124, 38);
            this.CloseInputForm_button.Name = "CloseInputForm_button";
            this.CloseInputForm_button.Size = new System.Drawing.Size(138, 23);
            this.CloseInputForm_button.TabIndex = 3;
            this.CloseInputForm_button.Text = "Закрыть форму";
            this.CloseInputForm_button.UseVisualStyleBackColor = true;
            this.CloseInputForm_button.Click += new System.EventHandler(this.CloseInputForm_button_Click);
            // 
            // CloseInputForm_button2
            // 
            this.CloseInputForm_button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseInputForm_button2.Location = new System.Drawing.Point(140, 277);
            this.CloseInputForm_button2.Name = "CloseInputForm_button2";
            this.CloseInputForm_button2.Size = new System.Drawing.Size(119, 23);
            this.CloseInputForm_button2.TabIndex = 6;
            this.CloseInputForm_button2.Text = "Закрыть форму";
            this.CloseInputForm_button2.UseVisualStyleBackColor = true;
            this.CloseInputForm_button2.Click += new System.EventHandler(this.CloseInputForm_button2_Click);
            // 
            // InputGraphMatrix_button
            // 
            this.InputGraphMatrix_button.Location = new System.Drawing.Point(9, 277);
            this.InputGraphMatrix_button.Name = "InputGraphMatrix_button";
            this.InputGraphMatrix_button.Size = new System.Drawing.Size(89, 23);
            this.InputGraphMatrix_button.TabIndex = 5;
            this.InputGraphMatrix_button.Text = "Ввести";
            this.InputGraphMatrix_button.UseVisualStyleBackColor = true;
            this.InputGraphMatrix_button.Click += new System.EventHandler(this.InputGraphMatrix_button_Click);
            // 
            // GraphMatrix_label
            // 
            this.GraphMatrix_label.AutoSize = true;
            this.GraphMatrix_label.Location = new System.Drawing.Point(9, 3);
            this.GraphMatrix_label.Name = "GraphMatrix_label";
            this.GraphMatrix_label.Size = new System.Drawing.Size(121, 15);
            this.GraphMatrix_label.TabIndex = 7;
            this.GraphMatrix_label.Text = "Матрица смежности";
            this.GraphMatrix_label.Click += new System.EventHandler(this.GraphMatrix_label_Click);
            // 
            // GraphMatrix_dataGridView
            // 
            this.GraphMatrix_dataGridView.AllowUserToAddRows = false;
            this.GraphMatrix_dataGridView.AllowUserToDeleteRows = false;
            this.GraphMatrix_dataGridView.AllowUserToResizeColumns = false;
            this.GraphMatrix_dataGridView.AllowUserToResizeRows = false;
            this.GraphMatrix_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GraphMatrix_dataGridView.Location = new System.Drawing.Point(9, 21);
            this.GraphMatrix_dataGridView.Name = "GraphMatrix_dataGridView";
            this.GraphMatrix_dataGridView.RowHeadersWidth = 18;
            this.GraphMatrix_dataGridView.RowTemplate.Height = 25;
            this.GraphMatrix_dataGridView.Size = new System.Drawing.Size(250, 250);
            this.GraphMatrix_dataGridView.TabIndex = 4;
            // 
            // GraphMatrix_panel
            // 
            this.GraphMatrix_panel.Controls.Add(this.GraphMatrix_dataGridView);
            this.GraphMatrix_panel.Controls.Add(this.GraphMatrix_label);
            this.GraphMatrix_panel.Controls.Add(this.CloseInputForm_button2);
            this.GraphMatrix_panel.Controls.Add(this.InputGraphMatrix_button);
            this.GraphMatrix_panel.Location = new System.Drawing.Point(3, 67);
            this.GraphMatrix_panel.Name = "GraphMatrix_panel";
            this.GraphMatrix_panel.Size = new System.Drawing.Size(271, 312);
            this.GraphMatrix_panel.TabIndex = 8;
            this.GraphMatrix_panel.Visible = false;
            // 
            // InputFromKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 65);
            this.Controls.Add(this.GraphMatrix_panel);
            this.Controls.Add(this.CloseInputForm_button);
            this.Controls.Add(this.InputNumVertices_button);
            this.Controls.Add(this.NumVertices_textBox);
            this.Controls.Add(this.NumVertices_label);
            this.Name = "InputFromKeyboard";
            this.Text = "InputFromKeyboard";
            ((System.ComponentModel.ISupportInitialize)(this.GraphMatrix_dataGridView)).EndInit();
            this.GraphMatrix_panel.ResumeLayout(false);
            this.GraphMatrix_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label NumVertices_label;
        private TextBox NumVertices_textBox;
        private Button InputNumVertices_button;
        private Button CloseInputForm_button;
        private Button CloseInputForm_button2;
        private Button InputGraphMatrix_button;
        private Label GraphMatrix_label;
        private DataGridView GraphMatrix_dataGridView;
        private Panel GraphMatrix_panel;
    }
}