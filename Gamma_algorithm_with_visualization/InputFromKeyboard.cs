using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkWithGraphsLibrary;

namespace Gamma_algorithm_with_visualization
{
    public partial class InputFromKeyboard : Form
    {
        public int num_vertices = 0;
        public int[,] graph_matrix;
        public InputFromKeyboard()
        {
            InitializeComponent();
        }

        private void InputNumVertex_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Int32.TryParse(NumVertices_textBox.Text, out num_vertices)) throw new Exception($"Число вершин должно быть числом в диапазоне от 2 до 150");
                if (num_vertices < 2 || num_vertices > 150) throw new Exception($"Число вершин должно быть числом в диапазоне от 2 до 150");

                Size = new Size(Size.Width, 411);
                CloseInputForm_button.Visible = false;
                GraphMatrix_panel.Visible = true;
                GraphMatrix_dataGridView.RowCount = num_vertices;
                GraphMatrix_dataGridView.ColumnCount = num_vertices;
                for (int i=0; i<num_vertices; i++)
                    GraphMatrix_dataGridView.Columns[i].Width = 25;

                graph_matrix = new int[num_vertices, num_vertices];
            }
            catch(Exception ex)
            {
                num_vertices = 0;
                CloseInputForm_button.Visible = true;
                GraphMatrix_panel.Visible = false;
                Size = new Size(Size.Width, 104);
                var dialogResult = MessageToUser(ex.Message, "Некорректное число вершин");
            }
        }

        private void GraphMatrix_label_Click(object sender, EventArgs e)
        {

        }

        private void CloseInputForm_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseInputForm_button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static async Task<DialogResult> MessageToUser(string NameError, string message)
        {
            return await Task.Run(() => MessageBox.Show(NameError, message));
        }

        private void InputGraphMatrix_button_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < num_vertices; i++)
                    for (int j = 0; j < num_vertices; j++)
                    {
                        if (GraphMatrix_dataGridView[j, i].Value==null) throw new Exception($"Элемент [{i + 1},{j + 1}] матрицы смежности не задан");
                        if (!Int32.TryParse(GraphMatrix_dataGridView[j,i].Value.ToString(), out graph_matrix[i,j])) throw new Exception($"Элемент [{i + 1},{j + 1}] матрицы смежности не 0 или 1");
                        if (graph_matrix[i, j] != 0 && graph_matrix[i, j] != 1) throw new Exception($"Элемент [{i + 1},{j + 1}] матрицы смежности не 0 или 1");
                        if (i == j && graph_matrix[i, j] == 1) throw new Exception($"Диагональный элемент [{i + 1},{j + 1}] матрицы смежности не может быть раным 1");
                    }
                if (!graph_matrix.IsSymmetric()) throw new Exception($"Матрица смежности не является симметричной");
                if (!Planar_graph.IsConnected(num_vertices, graph_matrix)) throw new Exception($"Граф не является связным");
                this.DialogResult= DialogResult.OK;
            }
            catch (Exception ex)
            {
                var dialogResult = MessageToUser(ex.Message, "Некорректная матрица смежности");
            }
        }
    }
}
