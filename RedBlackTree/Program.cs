namespace RedBlackTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var redBlackTree = new RedBlackTree<int>();

            //for (int i = 0; i < 10; i++)
            //{
            //    var key = Random.Shared.Next(100);
            //    Console.WriteLine($"Inserting key - {key}");
            //    redBlackTree.Insert(new Node<int>()
            //    {
            //        Key = key,
            //        Color = ColorEnum.Red
            //    });
            //}

            //var inOrder = redBlackTree.InOrderTraversal();
            //Console.WriteLine($"Inorder Traversal of Red Black Tree at the end: {inOrder.Count}");
            //foreach (var node in inOrder)
            //{
            //    Console.WriteLine($"Key: {node.Key} | Parent: {node.Parent?.Key} | Color: {node.Color}");
            //}

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Red Black Tree Console App");

            Console.WriteLine("Options:\n 1 - Insert New Node\n 2 - Inorder Traversal\n 3 - Exit");

            var done = false;
            while (!done)
            {
                Console.Write("Pick option: ");
                var option = Console.ReadLine();
                
                switch(option)
                {
                    case "1":
                        Console.Write("Enter new key: ");
                        int key;
                        if (int.TryParse(Console.ReadLine(), out key))
                        {
                            redBlackTree.Insert(new Node<int>()
                            {
                                Key = key,
                            });
                        }
                        else
                        {
                            Console.WriteLine("Wrong input");
                        }
                        break;
                    case "2":
                        foreach (var node in redBlackTree.InOrderTraversal())
                        {
                            Console.WriteLine($"Key: {node.Key} | Color: {node.Color}");
                        }
                        break;
                    default:
                        done = true;
                        break;
                }
            }

        }
    }
}