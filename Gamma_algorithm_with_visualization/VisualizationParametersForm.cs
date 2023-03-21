using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamma_algorithm_with_visualization
{
    public partial class VisualizationParametersForm : Form
    {
        public Color vertex_color;
        public VertexMapping vertex_mapping;
        public VisualizationParametersForm(Color vertex_color, VertexMapping vertex_mapping)
        {
            InitializeComponent();
            this.vertex_color = vertex_color;
            this.vertex_mapping = vertex_mapping;

            VertexMapping_comboBox.Text = vertex_mapping switch
            {
                VertexMapping.simple => "Упрощенное",
                VertexMapping.with_captions => "С подписями",
                _ => "Упрощенное"
            };
            VertexColor_comboBox.Text= vertex_color.ToString();

        }

        private void ApplySettings_button_Click(object sender, EventArgs e)
        {
            vertex_color = Color.FromName(VertexColor_comboBox.Text);
            vertex_mapping = VertexMapping_comboBox.Text switch
            {
                "Упрощенное" => VertexMapping.simple,
                "С подписями" => VertexMapping.with_captions,
                _ => VertexMapping.simple
            };
            DialogResult = DialogResult.OK;
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public enum VertexMapping
    {
        simple,
        with_captions
    }
}
