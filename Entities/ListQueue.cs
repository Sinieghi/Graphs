class ListQueue
{
    //Front is pointing to start Node and point to all subsequential ones.
    public Node? Front = null;
    //Rear is responsible to point o last node
    public Node? Rear = null;
    //Node is used to create new nodes
    public Node? node = null;
    public void Enqueue(int x)
    {
        node = new()
        {
            data = x,
            next = null
        };
        //if is null, stack is full already
        if (node == null) System.Console.WriteLine("Queue is full");
        else
        {
            if (Front == null) Front = Rear = node;
            else
            {
                Rear.next = node;
                Rear = node;
            }

        }
    }
    public int Dequeue()
    {
        int x = -1;
        if (node == null) System.Console.WriteLine("Queue is full");
        else
        {
            Node n = null;
            if (Front == null) Front = Rear = node;
            else
            {
                x = Front.data;
                n = Front;
                Front = Front.next;

            }
            if (n != null) System.Console.WriteLine("Dequeue: " + n.data);
            n = null;
        }
        return x;
    }

    public bool isEmpty()
    {
        return Front == null;
    }

}