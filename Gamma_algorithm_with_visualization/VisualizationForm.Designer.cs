namespace Gamma_algorithm_with_visualization
{
    partial class VisualizationForm
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
            this.GraphImage_pictureBox = new System.Windows.Forms.PictureBox();
            this.ReduceScale_button = new System.Windows.Forms.Button();
            this.IncreaseScale_button = new System.Windows.Forms.Button();
            this.Scale_label = new System.Windows.Forms.Label();
            this.Scale_panel = new System.Windows.Forms.Panel();
            this.ChangeVisualizationSettings_button = new System.Windows.Forms.Button();
            this.CloseVisualizationForm_button = new System.Windows.Forms.Button();
            this.PlanarityStatus_label = new System.Windows.Forms.Label();
            this.panel_for_pictureBox = new System.Windows.Forms.Panel();
            this.RebuildImage_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GraphImage_pictureBox)).BeginInit();
            this.Scale_panel.SuspendLayout();
            this.panel_for_pictureBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GraphImage_pictureBox
            // 
            this.GraphImage_pictureBox.Location = new System.Drawing.Point(2, 0);
            this.GraphImage_pictureBox.Name = "GraphImage_pictureBox";
            this.GraphImage_pictureBox.Size = new System.Drawing.Size(400, 400);
            this.GraphImage_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.GraphImage_pictureBox.TabIndex = 0;
            this.GraphImage_pictureBox.TabStop = false;
            // 
            // ReduceScale_button
            // 
            this.ReduceScale_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReduceScale_button.Location = new System.Drawing.Point(3, 3);
            this.ReduceScale_button.Name = "ReduceScale_button";
            this.ReduceScale_button.Size = new System.Drawing.Size(28, 28);
            this.ReduceScale_button.TabIndex = 1;
            this.ReduceScale_button.Text = "-";
            this.ReduceScale_button.UseVisualStyleBackColor = true;
            this.ReduceScale_button.Click += new System.EventHandler(this.ReduceScale_button_Click);
            // 
            // IncreaseScale_button
            // 
            this.IncreaseScale_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IncreaseScale_button.Location = new System.Drawing.Point(208, 3);
            this.IncreaseScale_button.Name = "IncreaseScale_button";
            this.IncreaseScale_button.Size = new System.Drawing.Size(28, 28);
            this.IncreaseScale_button.TabIndex = 2;
            this.IncreaseScale_button.Text = "+";
            this.IncreaseScale_button.UseVisualStyleBackColor = true;
            this.IncreaseScale_button.Click += new System.EventHandler(this.IncreaseScale_button_Click);
            // 
            // Scale_label
            // 
            this.Scale_label.AutoSize = true;
            this.Scale_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Scale_label.Location = new System.Drawing.Point(37, 5);
            this.Scale_label.Name = "Scale_label";
            this.Scale_label.Size = new System.Drawing.Size(106, 26);
            this.Scale_label.TabIndex = 3;
            this.Scale_label.Text = "Масштаб";
            // 
            // Scale_panel
            // 
            this.Scale_panel.Controls.Add(this.Scale_label);
            this.Scale_panel.Controls.Add(this.ReduceScale_button);
            this.Scale_panel.Controls.Add(this.IncreaseScale_button);
            this.Scale_panel.Location = new System.Drawing.Point(99, 418);
            this.Scale_panel.Name = "Scale_panel";
            this.Scale_panel.Size = new System.Drawing.Size(239, 36);
            this.Scale_panel.TabIndex = 4;
            // 
            // ChangeVisualizationSettings_button
            // 
            this.ChangeVisualizationSettings_button.Location = new System.Drawing.Point(430, 86);
            this.ChangeVisualizationSettings_button.Name = "ChangeVisualizationSettings_button";
            this.ChangeVisualizationSettings_button.Size = new System.Drawing.Size(142, 38);
            this.ChangeVisualizationSettings_button.TabIndex = 5;
            this.ChangeVisualizationSettings_button.Text = "Изменить параметры визуализации";
            this.ChangeVisualizationSettings_button.UseVisualStyleBackColor = true;
            this.ChangeVisualizationSettings_button.Click += new System.EventHandler(this.ChangeVisualizationSettings_button_Click);
            // 
            // CloseVisualizationForm_button
            // 
            this.CloseVisualizationForm_button.Location = new System.Drawing.Point(430, 174);
            this.CloseVisualizationForm_button.Name = "CloseVisualizationForm_button";
            this.CloseVisualizationForm_button.Size = new System.Drawing.Size(142, 23);
            this.CloseVisualizationForm_button.TabIndex = 6;
            this.CloseVisualizationForm_button.Text = "Закрыть форму";
            this.CloseVisualizationForm_button.UseVisualStyleBackColor = true;
            this.CloseVisualizationForm_button.Click += new System.EventHandler(this.CloseVisualizationForm_button_Click);
            // 
            // PlanarityStatus_label
            // 
            this.PlanarityStatus_label.AutoSize = true;
            this.PlanarityStatus_label.Font = new System.Drawing.Font("Sitka Heading", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PlanarityStatus_label.Location = new System.Drawing.Point(430, 12);
            this.PlanarityStatus_label.Name = "PlanarityStatus_label";
            this.PlanarityStatus_label.Size = new System.Drawing.Size(103, 23);
            this.PlanarityStatus_label.TabIndex = 7;
            this.PlanarityStatus_label.Text = "Планарный:";
            this.PlanarityStatus_label.Visible = false;
            // 
            // panel_for_pictureBox
            // 
            this.panel_for_pictureBox.AutoScroll = true;
            this.panel_for_pictureBox.Controls.Add(this.GraphImage_pictureBox);
            this.panel_for_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.panel_for_pictureBox.Name = "panel_for_pictureBox";
            this.panel_for_pictureBox.Size = new System.Drawing.Size(410, 410);
            this.panel_for_pictureBox.TabIndex = 8;
            // 
            // RebuildImage_button
            // 
            this.RebuildImage_button.Location = new System.Drawing.Point(430, 130);
            this.RebuildImage_button.Name = "RebuildImage_button";
            this.RebuildImage_button.Size = new System.Drawing.Size(142, 38);
            this.RebuildImage_button.TabIndex = 9;
            this.RebuildImage_button.Text = "Перестроить изображение";
            this.RebuildImage_button.UseVisualStyleBackColor = true;
            this.RebuildImage_button.Click += new System.EventHandler(this.RebuildImage_button_Click);
            // 
            // VisualizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 461);
            this.Controls.Add(this.RebuildImage_button);
            this.Controls.Add(this.panel_for_pictureBox);
            this.Controls.Add(this.PlanarityStatus_label);
            this.Controls.Add(this.CloseVisualizationForm_button);
            this.Controls.Add(this.ChangeVisualizationSettings_button);
            this.Controls.Add(this.Scale_panel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "VisualizationForm";
            this.Text = "VisualizationForm";
            this.Shown += new System.EventHandler(this.VisualizationForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.GraphImage_pictureBox)).EndInit();
            this.Scale_panel.ResumeLayout(false);
            this.Scale_panel.PerformLayout();
            this.panel_for_pictureBox.ResumeLayout(false);
            this.panel_for_pictureBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox GraphImage_pictureBox;
        private Button ReduceScale_button;
        private Button IncreaseScale_button;
        private Label Scale_label;
        private Panel Scale_panel;
        private Button ChangeVisualizationSettings_button;
        private Button CloseVisualizationForm_button;
        private Label PlanarityStatus_label;
        private Panel panel_for_pictureBox;
        private Button RebuildImage_button;
    }
}