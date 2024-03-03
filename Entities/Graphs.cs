class Graphs
{
    //Breadth First Search
    public void BFS(int[,] G, int start, int n)
    {
        int i = start;
        ListQueue q = new();
        int[] visited = new int[7];

        System.Console.WriteLine(i);
        visited[i] = 1;
        q.Enqueue(i);

        while (!q.isEmpty())
        {
            i = q.Dequeue();
            for (int j = 1; j < n; j++)
            {
                if (G[i, j] == 1 && visited[j] == 0)
                {
                    System.Console.WriteLine(j);
                    visited[j] = 1;
                    q.Enqueue(j);
                }
            }
        }
    }

    //Depth First Search
    static int[] visited = new int[7];
    public void DFS(int[,] G, int start, int n)
    {

        if (visited[start] == 0)
        {
            System.Console.WriteLine(start);
            visited[start] = 1;
            for (int j = 1; j < n; j++)
            {
                if (G[start, j] == 1 && visited[j] == 0)
                {
                    DFS(G, j, n);
                }
            }
        }

    }
    static int V = 8;
    public void PrimsMST(int[,] G, int n)
    {
        int u = 0;
        int I = int.MaxValue;
        int v = 0;
        int min = I;
        int[] track = new int[V];
        int[,] T = new int[2, V - 2];

        // Initial: Find min cost edge
        for (int i = 1; i < V; i++)
        {
            track[i] = I;  // Initialize track array with INFINITY
            for (int j = i; j < V; j++)
            {
                if (G[i, j] < min)
                {
                    min = G[i, j];
                    u = i;
                    v = j;
                }
            }
        }
        T[0, 0] = u;
        T[1, 0] = v;
        track[u] = track[v] = 0;

        // Initialize track array to track min cost edges
        for (int i = 1; i < V; i++)
        {
            if (track[i] != 0)
            {
                if (G[i, u] < G[i, v])
                {
                    track[i] = u;
                }
                else
                {
                    track[i] = v;
                }
            }
        }

        // Repeat
        for (int i = 1; i < n - 1; i++)
        {
            int k = 0;
            min = I;
            for (int j = 1; j < V; j++)
            {
                if (track[j] != 0 && G[j, track[j]] < min)
                {
                    k = j;
                    min = G[j, track[j]];
                }
            }
            T[0, i] = k;
            T[1, i] = track[k];
            track[k] = 0;

            // Update track array to track min cost edges
            for (int j = 1; j < V; j++)
            {
                if (track[j] != 0 && G[j, k] < G[j, track[j]])
                {
                    track[j] = k;
                }
            }
        }
        PrintMST(T, G);
    }
    void PrintMST(int[,] T, int[,] G)
    {
        System.Console.WriteLine("Minimum Spanning Tree Edges");
        int sum = 0;
        for (int i = 0; i < V - 2; i++)
        {
            int c = G[T[0, i], T[1, i]];
            System.Console.Write("[");
            System.Console.Write(T[0, i]);
            System.Console.Write("]---[");
            System.Console.Write(T[1, i]);
            System.Console.Write("] cost: ");
            System.Console.WriteLine(c);
            sum += c;
        }
        System.Console.WriteLine("Total cost of MST: " + sum);
    }

    //Kruskal's

    static int[] set = [-1, -1, -1, -1, -1, -1, -1, -1];
    public int[,] edges = {
        {1,1,2,2,3,4,4,5,5},
        {2,6,3,7,4,5,7,6,7},
        {25,5,12,10,8,16,14,20,18}
    };
    static int[] included = new int[9];
    static int[,] t = new int[2, 6];

    public void Kruskals()
    {
        int I = int.MaxValue;
        int i = 0, j, k = 0, u = 0, v = 0, min = I, n = 7, e = 9;

        while (i < n - 1)
        {
            min = I;
            for (j = 0; j < e; j++)
            {
                if (included[j] == 0 && edges[2, j] < min)
                {
                    min = edges[2, j];
                    u = edges[0, j];
                    V = edges[1, j];
                    k = j;
                }

            }
            if (find(u) != find(v))
            {
                t[0, i] = u;
                t[1, i] = V;
                union(find(u), find(v));
                i++;
            }
            included[k] = 1;
        }
    }
    //Disjoint subset
    public void union(int u, int v)
    {
        if (set[u] < set[v])
        {
            set[u] = set[u] + set[v];
            set[v] = u;
        }
        else
        {
            set[v] = set[u] + set[v];
            set[u] = u;

        }
    }

    public int find(int u)
    {
        int x = u;
        while (set[x] > 0) x = set[x];
        while (u != x) { V = set[u]; set[u] = x; }
        return x;
    }

}