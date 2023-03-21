namespace Gamma_algorithm_with_visualization
{
    partial class VisualizationParametersForm
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
            this.VertexMapping_label = new System.Windows.Forms.Label();
            this.VertexColor_label = new System.Windows.Forms.Label();
            this.VertexMapping_comboBox = new System.Windows.Forms.ComboBox();
            this.VertexColor_comboBox = new System.Windows.Forms.ComboBox();
            this.ApplySettings_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VertexMapping_label
            // 
            this.VertexMapping_label.AutoSize = true;
            this.VertexMapping_label.Location = new System.Drawing.Point(12, 9);
            this.VertexMapping_label.Name = "VertexMapping_label";
            this.VertexMapping_label.Size = new System.Drawing.Size(130, 15);
            this.VertexMapping_label.TabIndex = 0;
            this.VertexMapping_label.Text = "Отображение вершин";
            // 
            // VertexColor_label
            // 
            this.VertexColor_label.AutoSize = true;
            this.VertexColor_label.Location = new System.Drawing.Point(12, 58);
            this.VertexColor_label.Name = "VertexColor_label";
            this.VertexColor_label.Size = new System.Drawing.Size(80, 15);
            this.VertexColor_label.TabIndex = 1;
            this.VertexColor_label.Text = "Цвет вершин";
            // 
            // VertexMapping_comboBox
            // 
            this.VertexMapping_comboBox.FormattingEnabled = true;
            this.VertexMapping_comboBox.Items.AddRange(new object[] {
            "Упрощенное",
            "С подписями"});
            this.VertexMapping_comboBox.Location = new System.Drawing.Point(12, 27);
            this.VertexMapping_comboBox.Name = "VertexMapping_comboBox";
            this.VertexMapping_comboBox.Size = new System.Drawing.Size(121, 23);
            this.VertexMapping_comboBox.TabIndex = 2;
            // 
            // VertexColor_comboBox
            // 
            this.VertexColor_comboBox.FormattingEnabled = true;
            this.VertexColor_comboBox.Items.AddRange(new object[] {
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "Cyan",
            "Blue",
            "Purple"});
            this.VertexColor_comboBox.Location = new System.Drawing.Point(12, 76);
            this.VertexColor_comboBox.Name = "VertexColor_comboBox";
            this.VertexColor_comboBox.Size = new System.Drawing.Size(121, 23);
            this.VertexColor_comboBox.TabIndex = 3;
            // 
            // ApplySettings_button
            // 
            this.ApplySettings_button.Location = new System.Drawing.Point(12, 105);
            this.ApplySettings_button.Name = "ApplySettings_button";
            this.ApplySettings_button.Size = new System.Drawing.Size(80, 23);
            this.ApplySettings_button.TabIndex = 4;
            this.ApplySettings_button.Text = "Применить";
            this.ApplySettings_button.UseVisualStyleBackColor = true;
            this.ApplySettings_button.Click += new System.EventHandler(this.ApplySettings_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(98, 105);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.TabIndex = 5;
            this.Cancel_button.Text = "Отмена";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // VisualizationParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 133);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.ApplySettings_button);
            this.Controls.Add(this.VertexColor_comboBox);
            this.Controls.Add(this.VertexMapping_comboBox);
            this.Controls.Add(this.VertexColor_label);
            this.Controls.Add(this.VertexMapping_label);
            this.Name = "VisualizationParametersForm";
            this.Text = "VisualizationParametersForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label VertexMapping_label;
        private Label VertexColor_label;
        private ComboBox VertexMapping_comboBox;
        private ComboBox VertexColor_comboBox;
        private Button ApplySettings_button;
        private Button Cancel_button;
    }
}