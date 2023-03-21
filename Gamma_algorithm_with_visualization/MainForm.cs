using System.Windows.Forms;
using System;
using WorkWithGraphsLibrary;
using static System.Windows.Forms.DataFormats;

namespace Gamma_algorithm_with_visualization
{
    public partial class MainForm : Form
    {
        int num_vertices = 0;
        int[,] graph_matrix;

        public MainForm()
        {
            InitializeComponent();
        }

        public static async Task<DialogResult> MessageToUser(string NameError, string message)
        {
            return await Task.Run(() => MessageBox.Show(NameError, message));
        }

        private async void �������ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            num_vertices= 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] file_strings = await File.ReadAllLinesAsync(openFileDialog1.FileName);
                    if (!Int32.TryParse(file_strings[0], out num_vertices)) throw new Exception("� ������ ������ ����� ������ ���� ����� ������");
                    if (num_vertices < 2 || num_vertices > 150) throw new Exception("����� ������ ������ ���� � ��������� �� 2 �� 150");
                    if (file_strings.Length-1!=num_vertices) throw new Exception("����� ������ �� ������������� ����� ����� ������� ���������");

                    for (int i=1; i<file_strings.Length; i++)
                    {
                        string[] string_split = file_strings[i].Split(new char[] {' '});
                        if (string_split.Length!=num_vertices) throw new Exception($"����� ��������� � {i} ������ ������� ��������� �� ������������� ����� ������ �����");
                        int matrix_element;
                        for (int j=0; j<num_vertices; j++)
                        {
                            if (!Int32.TryParse(string_split[j], out matrix_element)) throw new Exception($"������� [{i},{j+1}] ������� ��������� �� 0 ��� 1");
                            if (matrix_element!=0 && matrix_element!=1) throw new Exception($"������� [{i},{j + 1}] ������� ��������� �� 0 ��� 1");
                            if (i-1==j && matrix_element==1) throw new Exception($"������������ ������� [{i},{j + 1}] ������� ��������� �� ����� ���� ����� 1");
                            graph_matrix[i-1,j] = matrix_element;
                        }
                    }

                    if (!graph_matrix.IsSymmetric()) throw new Exception($"������� ��������� �� �������� ������������");
                    if (!Planar_graph.IsConnected(num_vertices, graph_matrix)) throw new Exception($"���� �� �������� �������");
                    var dialogResult = MessageToUser("������ ������� ���������","���� ������ �� �����");
                }
                catch (Exception ex)
                {
                    num_vertices= 0;
                    var dialogResult = MessageToUser(ex.Message,"������ ����� ������ �� �����");
                }


                /*str = s.ReadLine();
                num = int.Parse(str);

                matr = new int[num][];
                for (int i = 0; i < num; i++)
                {
                    str = s.ReadLine();
                    mass = str.Split(new char[] { ' ' });
                    matr[i] = new int[num];
                    for (int j = 0; j < num; j++)
                        matr[i][j] = int.Parse(mass[j]);
                }*/
            }
        }

        private void �����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            num_vertices = 0;
            InputFromKeyboard inputForm = new InputFromKeyboard();
            inputForm.ShowDialog();
            if (inputForm.DialogResult == DialogResult.OK)
            {
                num_vertices = inputForm.num_vertices;
                graph_matrix = inputForm.graph_matrix.Clone() as int[,];
            }
        }

        private void ����������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (num_vertices == 0)
            {
                var dialogResult = MessageToUser("������ �� ������", "������ �������� ����������� �����");
                return;
            }
            CreateFormForVisualization();

            async void CreateFormForVisualization()
            {
                await Task.Run(() =>
                {
                    VisualizationForm form_for_visualization = new VisualizationForm(num_vertices,graph_matrix);
                    form_for_visualization.ShowDialog();
                });
            }

        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}