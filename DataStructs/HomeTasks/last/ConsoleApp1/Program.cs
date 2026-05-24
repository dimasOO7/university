using System;

class Program
{
    static void Main()
    {
        int[,] graph = new int[,]
        {
            { 0, 7, 9, int.MaxValue, int.MaxValue, 14 },
            { 7, 0, 10, 15, int.MaxValue, int.MaxValue },
            { 9, 10, 0, 11, int.MaxValue, 2 },
            { int.MaxValue, 15, 11, 0, 6, int.MaxValue },
            { int.MaxValue, int.MaxValue, int.MaxValue, 6, 0, 9 },
            { 14, int.MaxValue, 2, int.MaxValue, 9, 0 }
        };

        int n = 6;
        int[] dist = new int[n];
        bool[] visited = new bool[n];
        int[] parent = new int[n];

        for (int i = 0; i < n; i++)
        {
            dist[i] = graph[0, i];
            parent[i] = 0;
        }

        visited[0] = true;

        string[] pathEdges = new string[n];
        int edgeCount = 0;

        Console.WriteLine("{0,-4} | {1,-16} | {2,-22} | {3,-22} | {4,-22} | {5,-22} | {6,-22}", "Iter", "Path / Connected", "D2", "D3", "D4", "D5", "D6");

        string[] dStrs = new string[n];
        for (int i = 1; i < n; i++)
        {
            dStrs[i] = dist[i] == int.MaxValue ? "inf" : dist[i].ToString();
        }

        Console.WriteLine("{0,-4} | {1,-16} | {2,-22} | {3,-22} | {4,-22} | {5,-22} | {6,-22}", "0", "-> 1", dStrs[1], dStrs[2], dStrs[3], dStrs[4], dStrs[5]);

        int iter = 1;
        int u = 0;
        while (iter < n && u != -1)
        {
            int min_val = int.MaxValue;
            u = -1;

            for (int i = 1; i < n; i++)
            {
                if (!visited[i] && dist[i] < min_val)
                {
                    min_val = dist[i];
                    u = i;
                }
            }
            if (u != -1)
            {
                visited[u] = true;
                pathEdges[edgeCount] = (parent[u] + 1) + "-" + (u + 1);
                edgeCount++;

                for (int i = 1; i < n; i++)
                {
                    if (visited[i])
                    {
                        dStrs[i] = dist[i].ToString();
                    }
                    else
                    {
                        if (graph[u, i] != int.MaxValue)
                        {
                            int oldD = dist[i];
                            int newD = (dist[u] == int.MaxValue || graph[u, i] == int.MaxValue) ? int.MaxValue : dist[u] + graph[u, i];
                            string oldStr = oldD == int.MaxValue ? "inf" : oldD.ToString();

                            if (newD < dist[i])
                            {
                                dist[i] = newD;
                                parent[i] = u;
                            }

                            dStrs[i] = "min(" + oldStr + "," + dist[u] + "+" + graph[u, i] + ")=" + dist[i];
                        }
                        else
                        {
                            dStrs[i] = dist[i] == int.MaxValue ? "inf" : dist[i].ToString();
                        }
                    }
                }

                for (int line = 0; line < edgeCount; line++)
                {
                    string iterStr = line == 0 ? iter.ToString() : "";
                    string pathStr = pathEdges[line];
                    if (line == 0) pathStr += " -> " + (u + 1);

                    if (line == 0)
                    {
                        Console.WriteLine("{0,-4} | {1,-16} | {2,-22} | {3,-22} | {4,-22} | {5,-22} | {6,-22}", iterStr, pathStr, dStrs[1], dStrs[2], dStrs[3], dStrs[4], dStrs[5]);
                    }
                    else
                    {
                        Console.WriteLine("{0,-4} | {1,-16} | {2,-22} | {3,-22} | {4,-22} | {5,-22} | {6,-22}", iterStr, pathStr, "", "", "", "", "");
                    }
                }
                
                iter++;
            }
        }
    }
}