using System;
using System.Collections.Generic;

namespace WorkWithGraphsLibrary
{
    public static class Planar_graph
    {
        public static bool IsConnected(int num_vertices, int[,] graph_matrix)
        {
            bool[] visited_unique_vertices = new bool[num_vertices];
            int num_unique_vertices = 1;

            bool[] vertices_in_way = new bool[num_vertices];
            vertices_in_way[0] = true;
            var way = new List<int>(num_vertices) { 0 };

            bool new_vertex_is_found;
            int current_vertex, left_search_boundary = 0, vertex_number;

            while (way.Count > 0 && num_unique_vertices < num_vertices)
            {
                new_vertex_is_found = false;
                current_vertex = way.Last();

                for (vertex_number = left_search_boundary; vertex_number < num_vertices; vertex_number++)
                {
                    if (Math.Abs(graph_matrix[current_vertex, vertex_number]) == 1)
                    {
                        if (!vertices_in_way[vertex_number])
                        {
                            new_vertex_is_found = true;
                            if (!visited_unique_vertices[vertex_number])
                            {
                                visited_unique_vertices[vertex_number] = true;
                                num_unique_vertices++;
                            }
                            break;
                        }
                    }
                }

                if (new_vertex_is_found)
                {
                    way.Add(vertex_number);
                    left_search_boundary = 0;
                    vertices_in_way[vertex_number] = true;
                }
                else
                {
                    way.RemoveAt(way.Count - 1);
                    left_search_boundary = current_vertex + 1;
                    vertices_in_way[current_vertex] = false;
                }
            }
            return (num_unique_vertices == num_vertices);
        }

        public static bool IsPlanar(int num_vertices, int[,] graph_matrix)
        {
            List<Component> components = Planar_graph.Find_connected_components(num_vertices, graph_matrix);
            for (int number_of_component = 0; number_of_component < components.Count; number_of_component++)
            {
                if (!Gamma_algorithm(num_vertices, components[number_of_component])) return false;
            }
            return true;
        }

        static List<Component> Find_connected_components(in int num_vertices, in int[,] graph_matrix)
        {
            int[,] matrix_of_connected_components = graph_matrix.MatrixSubstract(Find_matrix_of_bridges(num_vertices, graph_matrix));
            var connected_components = new List<Component>();

            List<int> vertices_of_components = Get_vertices_of_components(num_vertices, matrix_of_connected_components);
            while (vertices_of_components.Count > 0)
            {
                connected_components.Add(Create_new_component(num_vertices, matrix_of_connected_components, ref vertices_of_components));
            }

            return connected_components;

            static int[,] Find_matrix_of_bridges(in int num_vertices, in int[,] graph_matrix)
            {
                int[,] matrix_of_bridges = graph_matrix.Clone() as int[,];

                bool[] vertices_in_way = new bool[num_vertices];
                vertices_in_way[0] = true;
                var way = new List<int>(num_vertices) { 0 };

                bool new_vertex_is_found;
                int current_vertex, left_search_boundary = 0, vertex_number;

                while (way.Count > 0)
                {
                    new_vertex_is_found = false;
                    current_vertex = way.Last();

                    for (vertex_number = left_search_boundary; vertex_number < num_vertices; vertex_number++)
                    {
                        if (Math.Abs(graph_matrix[current_vertex, vertex_number]) == 1)
                            if (vertices_in_way[vertex_number] && (way.Count - way.IndexOf(vertex_number)) > 2)
                            {
                                way.Add(vertex_number);
                                for (int i = way.IndexOf(vertex_number); i < way.Count - 1; i++)
                                {
                                    matrix_of_bridges[way[i], way[i + 1]] = 0;
                                    matrix_of_bridges[way[i + 1], way[i]] = 0;
                                }
                                way.RemoveAt(way.Count - 1);
                            }
                            else if (!vertices_in_way[vertex_number])
                            {
                                new_vertex_is_found = true;
                                break;
                            }
                    }

                    if (new_vertex_is_found)
                    {
                        way.Add(vertex_number);
                        left_search_boundary = 0;
                        vertices_in_way[vertex_number] = true;
                    }
                    else
                    {
                        way.RemoveAt(way.Count - 1);
                        left_search_boundary = current_vertex + 1;
                        vertices_in_way[current_vertex] = false;
                    }
                }
                return matrix_of_bridges;
            }

            static List<int> Get_vertices_of_components(in int num_vertices, in int[,] matrix_of_connected_components)
            {
                List<int> vertices_of_components = new List<int>();
                for (int i = 0; i < num_vertices; i++)
                    for (int j = 0; j < num_vertices; j++)
                    {
                        if (matrix_of_connected_components[i, j] == 1)
                        {
                            vertices_of_components.Add(i);
                            break;
                        }
                    }
                return vertices_of_components;
            }

            static Component Create_new_component(in int num_vertices, in int[,] matrix_of_connected_components, ref List<int> vertices_of_components)
            {
                Component component = new Component(num_vertices);
                Queue<int> queue_of_vertices = new Queue<int>();
                queue_of_vertices.Enqueue(vertices_of_components[0]);
                vertices_of_components.RemoveAt(0);

                while (queue_of_vertices.Count > 0)
                {
                    for (int vertex_number = 0; vertex_number < num_vertices; vertex_number++)
                    {
                        if (matrix_of_connected_components[queue_of_vertices.Peek(), vertex_number] == 1)
                        {
                            component.matrix_of_component[queue_of_vertices.Peek(), vertex_number] = 1;
                            component.matrix_of_component[vertex_number, queue_of_vertices.Peek()] = 1;
                            if (vertices_of_components.Contains(vertex_number)) queue_of_vertices.Enqueue(vertex_number);
                            vertices_of_components.Remove(vertex_number);
                        }
                    }
                    component.all_vertices.Add(queue_of_vertices.Dequeue());
                }
                return component;
            }
        }

        static bool Gamma_algorithm(in int num_vertices, in Component component)
        {
            int[,] builded_matrix = new int[num_vertices, num_vertices];
            List<int> builded_vertices = new List<int>() { component.all_vertices[0] };
            List<int>? cycle = Find_cycle(ref builded_matrix, ref builded_vertices, num_vertices, component);
            List<Graph_face> graph_faces = new List<Graph_face>() { new Graph_face(cycle), new Graph_face(cycle) };

            while (true)
            {
                List<Component> finded_connected_parts = Find_connected_parts(num_vertices, component, builded_matrix, builded_vertices);

                if (finded_connected_parts.Count > 0)
                {
                    Find_minimum_available_component(graph_faces, finded_connected_parts, out int number_of_selected_connected_part, out int number_of_selected_graph_face);
                    if (number_of_selected_connected_part < 0) return false;
                    List<int>? chain = Find_chain(ref builded_matrix, ref builded_vertices, num_vertices, finded_connected_parts[number_of_selected_connected_part]);
                    Add_chain(ref graph_faces, number_of_selected_graph_face, chain);
                }
                else
                {
                    cycle = Find_cycle(ref builded_matrix, ref builded_vertices, num_vertices, component);
                    if (cycle is null) return true;
                    for (int i = 0; i < graph_faces.Count; i++)
                        if (graph_faces[i].cycle.Contains(cycle[0])) { Add_cycle(ref graph_faces, i, cycle); break; }
                }
            }

            static List<Component> Find_connected_parts(in int num_vertices, in Component component, in int[,] builded_matrix, in List<int> builded_vertices)
            {
                List<Component> finded_parts = new List<Component>();
                int[,] not_builded_matrix = component.matrix_of_component.MatrixSubstract(builded_matrix);

                while (true)
                {
                    Component? part = null;
                    Queue<int> queue_of_vertices = new Queue<int>();

                    foreach (int builded_vertex in builded_vertices)
                    {
                        foreach (int vertex in component.all_vertices)
                            if (not_builded_matrix[builded_vertex, vertex] == 1)
                            {
                                part = new Component(num_vertices, new int[] { builded_vertex, vertex }, new int[] { builded_vertex });
                                part.Value.matrix_of_component[builded_vertex, vertex] = 1;
                                part.Value.matrix_of_component[vertex, builded_vertex] = 1;
                                not_builded_matrix[builded_vertex, vertex] = 0;
                                not_builded_matrix[vertex, builded_vertex] = 0;

                                if (builded_vertices.Contains(vertex)) part.Value.connected_vertices.Add(vertex);
                                else queue_of_vertices.Enqueue(vertex);
                                break;
                            }
                        if (part is not null) break;
                    }
                    if (part is null) break;

                    while (queue_of_vertices.Count > 0)
                    {
                        foreach (int vertex in component.all_vertices)
                            if (not_builded_matrix[queue_of_vertices.Peek(), vertex] == 1)
                            {
                                part.Value.matrix_of_component[queue_of_vertices.Peek(), vertex] = 1;
                                part.Value.matrix_of_component[vertex, queue_of_vertices.Peek()] = 1;
                                not_builded_matrix[queue_of_vertices.Peek(), vertex] = 0;
                                not_builded_matrix[vertex, queue_of_vertices.Peek()] = 0;
                                if (!part.Value.all_vertices.Contains(vertex)) part.Value.all_vertices.Add(vertex);

                                if (builded_vertices.Contains(vertex) && !part.Value.connected_vertices.Contains(vertex)) part.Value.connected_vertices.Add(vertex);
                                else if (!queue_of_vertices.Contains(vertex)) queue_of_vertices.Enqueue(vertex); part.Value.connected_vertices.Add(vertex);
                            }
                        queue_of_vertices.Dequeue();
                    }
                    if (part.Value.connected_vertices.Count >= 2) finded_parts.Add(part.Value);
                }
                return finded_parts;
            }

            static void Find_minimum_available_component(in List<Graph_face> graph_faces, in List<Component> finded_connected_parts, out int number_of_selected_connected_part, out int number_of_selected_graph_face)
            {
                number_of_selected_connected_part = number_of_selected_graph_face = -1;
                int min_num_available_graph_faces = int.MaxValue;

                foreach (Component connected_part in finded_connected_parts)
                {
                    int num_available_graph_faces = 0, number_of_avaliable_graph_face = -1;
                    foreach (Graph_face graph_face in graph_faces)
                    {
                        int num_connected_vertices = 0;
                        foreach (int connected_vertex in connected_part.connected_vertices)
                        {
                            if (!graph_face.cycle.Contains(connected_vertex)) break;
                            num_connected_vertices++;
                        }

                        if (num_connected_vertices == connected_part.connected_vertices.Count)
                        {
                            num_available_graph_faces++;
                            number_of_avaliable_graph_face = graph_faces.IndexOf(graph_face);
                        }
                    }

                    if (num_available_graph_faces == 0) { number_of_selected_connected_part = -1; return; }
                    if (num_available_graph_faces < min_num_available_graph_faces)
                    {
                        min_num_available_graph_faces = num_available_graph_faces;
                        number_of_selected_connected_part = finded_connected_parts.IndexOf(connected_part);
                        number_of_selected_graph_face = number_of_avaliable_graph_face;
                    }
                }
            }

            static List<int>? Find_chain(ref int[,] builded_matrix, ref List<int> builded_vertices, in int num_vertices, in Component part)
            {
                List<int>? chain = null;
                bool[] vertices_in_way = new bool[num_vertices];
                vertices_in_way[part.connected_vertices[0]] = true;
                var way = new List<int>(num_vertices + 1) { part.connected_vertices[0] };

                bool new_vertex_is_found;
                int current_vertex, left_search_boundary = 0, vertex_number;

                while (way.Count > 0)
                {
                    new_vertex_is_found = false;
                    current_vertex = way.Last();

                    for (vertex_number = left_search_boundary; vertex_number < num_vertices; vertex_number++)
                    {
                        if (part.matrix_of_component[current_vertex, vertex_number] == 1 && builded_matrix[current_vertex, vertex_number] == 0)
                        {
                            if (vertex_number != part.connected_vertices[0] && part.connected_vertices.Contains(vertex_number))
                            {
                                way.Add(vertex_number);
                                chain = new List<int>(way);

                                for (int i = 0; i < chain.Count - 1; i++)
                                {
                                    builded_matrix[chain[i], chain[i + 1]] = builded_matrix[chain[i + 1], chain[i]] = 1;
                                    if (!builded_vertices.Contains(chain[i])) builded_vertices.Add(chain[i]);
                                }
                                return chain;
                            }
                            else if (!vertices_in_way[vertex_number])
                            {
                                new_vertex_is_found = true;
                                break;
                            }
                        }
                    }
                    if (new_vertex_is_found)
                    {
                        way.Add(vertex_number);
                        left_search_boundary = 0;
                        vertices_in_way[vertex_number] = true;
                    }
                    else
                    {
                        way.RemoveAt(way.Count - 1);
                        left_search_boundary = current_vertex + 1;
                        vertices_in_way[current_vertex] = false;
                    }
                }
                return chain;
            }

            static List<int>? Find_cycle(ref int[,] builded_matrix, ref List<int> builded_vertices, in int num_vertices, in Component component)
            {
                List<int>? cycle = null;
                foreach (int starting_vertice in builded_vertices)
                {
                    bool[] vertices_in_way = new bool[num_vertices];
                    vertices_in_way[starting_vertice] = true;
                    var way = new List<int>(num_vertices + 1) { starting_vertice };

                    bool new_vertex_is_found;
                    int current_vertex, left_search_boundary = 0, vertex_number;

                    while (way.Count > 0)
                    {
                        new_vertex_is_found = false;
                        current_vertex = way.Last();

                        for (vertex_number = left_search_boundary; vertex_number < num_vertices; vertex_number++)
                        {
                            if (component.matrix_of_component[current_vertex, vertex_number] == 1 && builded_matrix[current_vertex, vertex_number] == 0)
                            {
                                if (vertex_number == starting_vertice && way.Count > 2)
                                {
                                    way.Add(vertex_number);
                                    cycle = new List<int>(way);

                                    for (int i = 0; i < cycle.Count - 1; i++)
                                    {
                                        builded_matrix[cycle[i], cycle[i + 1]] = builded_matrix[cycle[i + 1], cycle[i]] = 1;
                                        if (!builded_vertices.Contains(cycle[i])) builded_vertices.Add(cycle[i]);
                                    }
                                    return cycle;
                                }
                                else if (!vertices_in_way[vertex_number])
                                {
                                    new_vertex_is_found = true;
                                    break;
                                }
                            }
                        }
                        if (new_vertex_is_found)
                        {
                            way.Add(vertex_number);
                            left_search_boundary = 0;
                            vertices_in_way[vertex_number] = true;
                        }
                        else
                        {
                            way.RemoveAt(way.Count - 1);
                            left_search_boundary = current_vertex + 1;
                            vertices_in_way[current_vertex] = false;
                        }
                    }
                }
                return cycle;
            }

            static void Add_chain(ref List<Graph_face> graph_faces, int num_graph_face, in List<int> chain)
            {
                if (graph_faces[num_graph_face].cycle.IndexOf(chain[chain.Count - 1]) < graph_faces[num_graph_face].cycle.IndexOf(chain[0])) chain.Reverse();
                List<int> cycle1 = graph_faces[num_graph_face].cycle.GetRange(0, graph_faces[num_graph_face].cycle.IndexOf(chain[0]));
                cycle1.AddRange(chain.GetRange(0, chain.Count - 1));
                cycle1.AddRange(graph_faces[num_graph_face].cycle.GetRange(graph_faces[num_graph_face].cycle.IndexOf(chain[chain.Count - 1]), graph_faces[num_graph_face].cycle.Count() - graph_faces[num_graph_face].cycle.IndexOf(chain[chain.Count - 1])));

                List<int> cycle2 = graph_faces[num_graph_face].cycle.GetRange(graph_faces[num_graph_face].cycle.IndexOf(chain[0]), graph_faces[num_graph_face].cycle.IndexOf(chain[chain.Count - 1]) - graph_faces[num_graph_face].cycle.IndexOf(chain[0]));
                chain.Reverse();
                cycle2.AddRange(chain);

                graph_faces[num_graph_face] = new Graph_face(cycle1);
                graph_faces.Add(new Graph_face(cycle2));
            }

            static void Add_cycle(ref List<Graph_face> graph_faces, int num_graph_face, in List<int> cycle)
            {
                List<int> cycle1 = graph_faces[num_graph_face].cycle.GetRange(0, graph_faces[num_graph_face].cycle.IndexOf(cycle[0]));
                cycle1.AddRange(cycle.GetRange(0, cycle.Count - 1));
                cycle1.AddRange(graph_faces[num_graph_face].cycle.GetRange(graph_faces[num_graph_face].cycle.IndexOf(cycle[0]) + 1, graph_faces[num_graph_face].cycle.Count - graph_faces[num_graph_face].cycle.IndexOf(cycle[0]) - 1));

                graph_faces[num_graph_face] = new Graph_face(cycle1);
                graph_faces.Add(new Graph_face(cycle));
            }
        }


        struct Component
        {
            public int[,] matrix_of_component { get; set; }
            public List<int> all_vertices { get; set; } = new List<int>();
            public List<int> connected_vertices { get; set; } = new List<int>();
            public Component(int num_vertices)
            {
                this.matrix_of_component = new int[num_vertices, num_vertices];
            }

            public Component(int num_vertices, int[] all_vertices, int[] connected_vertices)
            {
                this.matrix_of_component = new int[num_vertices, num_vertices];
                this.all_vertices = new List<int>(all_vertices);
                this.connected_vertices = new List<int>(connected_vertices);
            }
        }

        struct Graph_face
        {
            public List<int> cycle { get; set; }
            public Graph_face(List<int> cycle)
            {
                this.cycle = new List<int>(cycle);
            }

        }

    }
}
