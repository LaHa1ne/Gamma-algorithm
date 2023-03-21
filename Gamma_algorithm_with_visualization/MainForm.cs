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

        private async void изФайлаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            num_vertices= 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] file_strings = await File.ReadAllLinesAsync(openFileDialog1.FileName);
                    if (!Int32.TryParse(file_strings[0], out num_vertices)) throw new Exception("В первой строке файла должно быть число вершин");
                    if (num_vertices < 2 || num_vertices > 150) throw new Exception("Число вершин должно быть в диапазоне от 2 до 150");
                    if (file_strings.Length-1!=num_vertices) throw new Exception("Число вершин не соответствует числу строк матрицы смежности");

                    for (int i=1; i<file_strings.Length; i++)
                    {
                        string[] string_split = file_strings[i].Split(new char[] {' '});
                        if (string_split.Length!=num_vertices) throw new Exception($"Число элементов в {i} строке матрицы смежности не соответствует числу вершин графа");
                        int matrix_element;
                        for (int j=0; j<num_vertices; j++)
                        {
                            if (!Int32.TryParse(string_split[j], out matrix_element)) throw new Exception($"Элемент [{i},{j+1}] матрицы смежности не 0 или 1");
                            if (matrix_element!=0 && matrix_element!=1) throw new Exception($"Элемент [{i},{j + 1}] матрицы смежности не 0 или 1");
                            if (i-1==j && matrix_element==1) throw new Exception($"Диагональный элемент [{i},{j + 1}] матрицы смежности не может быть раным 1");
                            graph_matrix[i-1,j] = matrix_element;
                        }
                    }

                    if (!graph_matrix.IsSymmetric()) throw new Exception($"Матрица смежности не является симметричной");
                    if (!Planar_graph.IsConnected(num_vertices, graph_matrix)) throw new Exception($"Граф не является связным");
                    var dialogResult = MessageToUser("Данные успешно прочитаны","Ввод данных из файла");
                }
                catch (Exception ex)
                {
                    num_vertices= 0;
                    var dialogResult = MessageToUser(ex.Message,"Ошибка ввода данных из файла");
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

        private void сКлавиатурыToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void проверитьНаПланарностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (num_vertices == 0)
            {
                var dialogResult = MessageToUser("Данные не заданы", "Ошибка проверки планарности графа");
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

        private void завершениеРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ввестиДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}