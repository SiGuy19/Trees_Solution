public class PrimeTree
{
    // Create a class for the tree nodes
    public class Node
    {
        public Node left, right;
        public int data;
    };
    static Node root;
 
    // Create a function to create a new tree Node
    static Node newNode(int data)
    {
        Node prime = new Node();
        prime.data = data;
        prime.left = null;
        prime.right = null;
        return prime;
    }
 
    // This function creates the prime factor tree for the value chosen by the user
    // It then stores the value as the root of the tree
    static Node createPrimeFactorTree(Node root_node, int number)
    {
        (root_node) = newNode(number);
 
        // This for loop factorizes the number
        for (int i = 2 ; i < number ; i++)
        {
            if (number % i != 0)
                continue;
 
            // If the loop finds a factor, then create a left and right subtree and return.
            // The left child will have the smaller factor since the program is set to 
            // traverse the factors from smaller to bigger
            root_node.left = createPrimeFactorTree(((root_node).left), i);
            root_node.right =  createPrimeFactorTree(((root_node).right), number/i);
            return root_node;
        }
        return root_node;
    }
 
    // Create a function that iterates through the tree find the height of the tree
    // and prints out each node in the tree
    static void printPrimeFactorTree(Node root)
    {
        
        if (root == null)  return;
        // Create a queue to add nodes from tree to print later
        Queue<Node > queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
 
            // Print first item of the queue and then remove it
            Node node = queue.Peek();
            Console.Write(node.data + " ");
            queue.Dequeue();
            // This goes through the tree and adds each factor to the queue
            if (node.left != null)
                queue.Enqueue(node.left);
            if (node.right != null)
                queue.Enqueue(node.right);
        }
    }
 
    // The function that runs the program
    public static void Main()
    {
        Console.Write("Enter the value of number:");
        int number = Convert.ToInt32(Console.ReadLine());
        root = null;
        root = createPrimeFactorTree(root, number);
        Console.WriteLine("Order of prime factor tree:");
        printPrimeFactorTree(root);
    }
}

