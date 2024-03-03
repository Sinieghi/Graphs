class Program
{
    static void Main(string[] args)
    {
        int I = int.MaxValue;
        int[,] G = {
        {0,0,0,0,0,0,0},
        {0,0,1,1,0,0,0},
        {0,1,0,0,1,0,0},
        {0,1,0,0,1,0,0},
        {0,0,1,1,0,1,1},
        {0,0,0,0,1,0,0},
        {0,0,0,0,1,0,0}
        };
        Graphs graphs = new();
        System.Console.WriteLine("BFS");
        graphs.BFS(G, 4, 7);
        System.Console.WriteLine("DFS");
        graphs.DFS(G, 4, 7);

        //prim's spanning tree
        System.Console.WriteLine("Prim's algorithm");
        //notice that matrix is a mirror, so is just search in upper or lower
        //triangle to find minimum value, witch is 5 in this case
        int[,] cost = {
            {I, I, I, I, I, I, I, I},
            {I, I, 25, I, I, I, 5, I},
            {I, 25, I, 12, I, I, I, 10},
            {I, I, 12, I, 8, I, I, I},
            {I, I, I, 8, I, 16, I, 14},
            {I, I, I, I, 16, I, 20, 18},
            {I, 5, I, I, I, 20, I, I},
            {I, I, 10, I, 14, 18, I, I},
        };
        int[] near = [I, I, I, I, I, I, I, I];
        int[,] t = new int[2, 6];
        graphs.PrimsMST(cost, 7);

        //Kruska'l section
        graphs.Kruskals();

    }


}