using System;
using System.Collections.Generic;

namespace WorkWithGraphsLibrary
{
    public static class Graph_visualization
    {
        public static List<Edge> Modified_Eades_algorithm(int num_vertices, int[,] graph_matrix, double c_rep, double c_spring, double coefficient_d, double coefficient_l, int area_size)
        {
            List<Coords> coords_of_vertices = new List<Coords>(num_vertices);
            List<Coords> increments_of_coords = new List<Coords>(num_vertices);
            Random rnd = new Random();
            for (int i = 0; i < num_vertices; i++)
            {
                coords_of_vertices.Add(new Coords(rnd.Next(30, area_size - 30), rnd.Next(30, area_size - 30)));
                increments_of_coords.Add(new Coords(0, 0));
            }

            int num_edges = Count_edges(num_vertices, graph_matrix);
            double increment_module, increment_x, increment_y, max_increment;

            for (int iteration = 0; iteration < num_edges * 20; iteration++)
            {
                increments_of_coords.ForEach(list_element => list_element.Update_coords(0, 0));
                for (int vertex1 = 0; vertex1 < num_vertices; vertex1++)
                    for (int vertex2 = 0; vertex2 < num_vertices; vertex2++)
                        if (vertex1 != vertex2)
                        {
                            increment_x = coords_of_vertices[vertex1].x - coords_of_vertices[vertex2].x;
                            increment_y = coords_of_vertices[vertex1].y - coords_of_vertices[vertex2].y;
                            increment_module = Math.Sqrt(increment_x * increment_x + increment_y * increment_y);
                            if (graph_matrix[vertex1, vertex2] == 0)
                            {
                                increments_of_coords[vertex1].Update_coords(increments_of_coords[vertex1].x + c_rep * increment_x / Math.Pow(increment_module, 3), increments_of_coords[vertex1].y + c_rep * increment_y / Math.Pow(increment_module, 3));
                            }
                            else
                            {
                                increments_of_coords[vertex1].Update_coords(increments_of_coords[vertex1].x - c_spring * Math.Log(increment_module / coefficient_l, Math.E) * increment_x / increment_module, increments_of_coords[vertex1].y - c_spring * Math.Log(increment_module / coefficient_l, Math.E) * increment_y / increment_module);
                            }
                        }
                max_increment = 0.0;
                for (int vertex_number = 0; vertex_number < num_vertices; vertex_number++)
                {
                    max_increment = Math.Max(Math.Sqrt(Math.Pow(increments_of_coords[vertex_number].x, 2) + Math.Pow(increments_of_coords[vertex_number].y, 2)), max_increment);
                    coords_of_vertices[vertex_number].Update_coords(coords_of_vertices[vertex_number].x + coefficient_d * increments_of_coords[vertex_number].x, coords_of_vertices[vertex_number].y + coefficient_d * increments_of_coords[vertex_number].y);
                }
                if (max_increment < 2) break;
            }

            Resize_coords(ref coords_of_vertices, area_size);

            List<Edge> edges = new List<Edge>(num_edges);
            for (int i = 0; i < num_vertices - 1; i++)
                for (int j = i + 1; j < num_vertices; j++)
                    if (graph_matrix[i, j] == 1)
                        edges.Add(new Edge(i, j, coords_of_vertices[i], coords_of_vertices[j]));

            return edges;

            static int Count_edges(int num_vertices, in int[,] graph_matrix)
            {
                int num_edges = 0;
                for (int i = 0; i < num_vertices - 1; i++)
                    for (int j = i + 1; j < num_vertices; j++)
                        if (graph_matrix[i, j] == 1) num_edges++;
                return num_edges;
            }

            static void Resize_coords(ref List<Coords> coords_of_vertices, double area_size)
            {
                double coefficient_of_x_coordinate_change = (coords_of_vertices.Max(vertex => vertex.x) - coords_of_vertices.Min(vertex => vertex.x)) / (area_size - 2 * 30);
                double coefficient_of_y_coordinate_change = (coords_of_vertices.Max(vertex => vertex.y) - coords_of_vertices.Min(vertex => vertex.y)) / (area_size - 2 * 30);

                for (int vertex_number = 0; vertex_number < coords_of_vertices.Count; vertex_number++)
                {
                    coords_of_vertices[vertex_number].Update_coords(coords_of_vertices[vertex_number].x / coefficient_of_x_coordinate_change, coords_of_vertices[vertex_number].y / coefficient_of_y_coordinate_change);
                }

                double x_shift = coords_of_vertices.Min(vertex => vertex.x) - 30;
                double y_shift = coords_of_vertices.Min(vertex => vertex.y) - 30;

                for (int vertex_number = 0; vertex_number < coords_of_vertices.Count; vertex_number++)
                {
                    coords_of_vertices[vertex_number].Update_coords(coords_of_vertices[vertex_number].x - x_shift, coords_of_vertices[vertex_number].y - y_shift);
                }
            }
        }
    }

    public struct Edge
    {
        public int vertex1 { get; set; }
        public int vertex2 { get; set; }
        public List<Coords> coords { get; set; }

        internal Edge(int vertex1, int vertex2, Coords coords_of_vertex1, Coords coords_of_vertex2)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            coords = new List<Coords>(2) { coords_of_vertex1, coords_of_vertex2 };
        }
    }

    public struct Coords
    {
        public double x { get; set; }
        public double y { get; set; }

        public Coords(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Update_coords(double x = 0.0, double y = 0.0)
        {
            this.x = x; this.y = y;
        }
    }
}
