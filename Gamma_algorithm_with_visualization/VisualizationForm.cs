using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WorkWithGraphsLibrary;

namespace Gamma_algorithm_with_visualization
{
    public partial class VisualizationForm : Form
    {
        int num_vertices;
        int[,] graph_matrix;
        private double scale = 1.0;
        private Color vertex_color = Color.Orange;
        private VertexMapping vertex_mapping=VertexMapping.simple;
        private List<Edge> graph_edges;



        public VisualizationForm(int num_vertices, int[,] graph_matrix)
        {
            InitializeComponent();
            this.num_vertices = num_vertices;
            this.graph_matrix = graph_matrix.Clone() as int[,];
        }

        private void VisualizationForm_Shown(object sender, EventArgs e)
        {
            CheckIsPlanar(num_vertices, graph_matrix);
            graph_edges = Graph_visualization.Modified_Eades_algorithm(num_vertices, graph_matrix, c_rep: 1, c_spring: 2, coefficient_d: 0.1, coefficient_l: 2, area_size: 400);
            DrawGraph();
            Scale_label.Text = $"Масштаб {(int)(scale * 100)}%";


            async void CheckIsPlanar(int num_vertices, int[,] graph_matrix)
            {
                await Task.Run(() =>
                {
                    bool IsPlanar = Planar_graph.IsPlanar(num_vertices, graph_matrix);
                    Invoke(() => {
                        PlanarityStatus_label.Text += IsPlanar ? "Да" : "Нет";
                        PlanarityStatus_label.Visible = true;
                    });
                });
            }

        }

        private void CloseVisualizationForm_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReduceScale_button_Click(object sender, EventArgs e)
        {
            scale=Math.Max(scale-0.1, 0.5);
            Scale_label.Text = $"Масштаб {(int)(scale * 100)}%";
            DrawGraph();
        }

        private void IncreaseScale_button_Click(object sender, EventArgs e)
        {
            scale = Math.Min(scale + 0.1, 2.0);
            Scale_label.Text = $"Масштаб {(int)(scale * 100)}%";
            DrawGraph();
        }

        private void ChangeVisualizationSettings_button_Click(object sender, EventArgs e)
        {
            VisualizationParametersForm visualization_parametrs_form = new VisualizationParametersForm(vertex_color, vertex_mapping);
            visualization_parametrs_form.ShowDialog();
            if (visualization_parametrs_form.DialogResult == DialogResult.OK)
            {
                vertex_color = visualization_parametrs_form.vertex_color;
                vertex_mapping = visualization_parametrs_form.vertex_mapping;
                DrawGraph();
            }
        }

        private void DrawGraph()
        {
            Pen edge_line=new Pen(Color.Black, 1);
            Pen vertex_line = new Pen(vertex_color, 2);
            Font vertex_signature_font= new Font("Arial", (int)(14.0 * scale));

            int vertex_radius = vertex_mapping switch
            {
                VertexMapping.simple => (int)(7 * scale),
                VertexMapping.with_captions => (int)((((int)Math.Log10(num_vertices) + 1) * 8 + 5) * scale)
            };

            GraphImage_pictureBox.Image = new Bitmap((int)(GraphImage_pictureBox.Width*scale), (int)(GraphImage_pictureBox.Height*scale));
            using (Graphics g = Graphics.FromImage(GraphImage_pictureBox.Image))
            {
                g.Clear(Color.White);

                for (int i = 0; i < graph_edges.Count; i++)
                    g.DrawLine(edge_line, (int)(graph_edges[i].coords[0].x*scale), (int)(graph_edges[i].coords[0].y*scale), (int)(graph_edges[i].coords[1].x*scale), (int)(graph_edges[i].coords[1].y*scale));

                for (int i=0; i<graph_edges.Count; i++)
                {
                    for (int j = 0; j < graph_edges[i].coords.Count; j++)
                    {

                        g.FillEllipse(Brushes.White, (int)(graph_edges[i].coords[j].x*scale) - vertex_radius, (int)(graph_edges[i].coords[j].y * scale) - vertex_radius, vertex_radius * 2, vertex_radius * 2);
                        g.DrawEllipse(vertex_line, (int)(graph_edges[i].coords[j].x * scale) - vertex_radius, (int)(graph_edges[i].coords[j].y * scale) - vertex_radius, vertex_radius * 2, vertex_radius * 2);                     
                    }

                    if (vertex_mapping == VertexMapping.with_captions)
                    { 
                        SizeF string_size_in_pixels = g.MeasureString(graph_edges[i].vertex1.ToString(), vertex_signature_font);
                        g.DrawString(graph_edges[i].vertex1.ToString(), vertex_signature_font, Brushes.Black, (int)(graph_edges[i].coords[0].x * scale) - (int)(string_size_in_pixels.Width / 2), (int)(graph_edges[i].coords[0].y * scale) - (int)(string_size_in_pixels.Height / 2));
                        string_size_in_pixels = g.MeasureString(graph_edges[i].vertex2.ToString(), vertex_signature_font);
                        g.DrawString(graph_edges[i].vertex2.ToString(), vertex_signature_font, Brushes.Black, (int)(graph_edges[i].coords[1].x * scale) - (int)(string_size_in_pixels.Width / 2), (int)(graph_edges[i].coords[1].y * scale) - (int)(string_size_in_pixels.Height / 2));
                    }
                }
            }
        }

        private void RebuildImage_button_Click(object sender, EventArgs e)
        {
            graph_edges = Graph_visualization.Modified_Eades_algorithm(num_vertices, graph_matrix, c_rep: 1, c_spring: 2, coefficient_d: 0.1, coefficient_l: 2, area_size: 400);
            DrawGraph();
        }

    }
}
