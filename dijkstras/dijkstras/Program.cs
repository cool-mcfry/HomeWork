class Connection<T>
{
    Node<T> connectedNode;
    double weight;


    public Connection(Node<T> cN, double w)
    {
        connectedNode = cN;
        weight = w;
    }

    public double GetWeight()
    {
        return weight;
    }

    public Node<T> GetConnectedNode()
    {
        return connectedNode;
    }
}

class Node<T>
{
    public T data;
    List<Connection<T>> connections = new List<Connection<T>>();

    public Node(T d)
    {
        data = d;
    }

    public void AddConnection(Node<T> node, double weight)
    {
        connections.Add(new Connection<T>(node, weight));
    }
    public List<Connection<T>> GetConnections()
    {
        return connections;
    }

    public double GetConnectionWeight(Node<T> node)
    {
        foreach (Connection<T> c in connections)
        {
            if (c.GetConnectedNode() == node)
            {
                return c.GetWeight();
            }
        }
        return -1;
    }
    public override string ToString()
    {
        return data.ToString();
    }
}

class Graph<T>
{
    List<Node<T>> nodes = new List<Node<T>>();

    public void AddNode(Node<T> n)
    {
        nodes.Add(n);
    }

    public void CreateConnection(Node<T> na, Node<T> nb, double weight)
    {
        if (!nodes.Contains(na) || !nodes.Contains(nb))
        {
            Console.WriteLine("One of the two nodes is not in the graph");
            return;
        }
        na.AddConnection(nb, weight);
        nb.AddConnection(na, weight);
    }

    public void Dijkstras(Node<T> start, Node<T> end)
    {
        //write code here
        List<DijkstraRow<T>> rows = new List<DijkstraRow<T>>();
        foreach (Node<T> node in nodes)
        {

        }
    }
}

class DijkstraRow<T>
{
    public Node<T> node;
    public double distanceFromStart = double.MaxValue;
    public bool visited = false;
    public Node<T> previousNode = null;

    public DijkstraRow(Node<T> theNode)
    {
        node = theNode;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Graph<string> map = new Graph<string>();
        Node<string> A = new Node<string>("A");
        Node<string> B = new Node<string>("B");
        Node<string> C = new Node<string>("C");
        Node<string> D = new Node<string>("D");
        Node<string> E = new Node<string>("E");
        Node<string> F = new Node<string>("F");
        Node<string> G = new Node<string>("G");

        map.AddNode(A);
        map.AddNode(B);
        map.AddNode(C);
        map.AddNode(D);
        map.AddNode(E);
        map.AddNode(F);
        map.AddNode(G);

        map.CreateConnection(A, B, 11);
        map.CreateConnection(A, C, 5);
        map.CreateConnection(B, D, 9);
        map.CreateConnection(B, E, 6);
        map.CreateConnection(D, E, 2);
        map.CreateConnection(D, G, 7);
        map.CreateConnection(C, F, 8);
        map.CreateConnection(F, G, 12);

        map.Dijkstras(A, G);

    }
}
