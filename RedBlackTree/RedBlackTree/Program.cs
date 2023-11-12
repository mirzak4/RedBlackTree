using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RedBlackTree
{
    internal class Program
    {
        private static readonly string _path = "C:\\Users\\mirza.kadric\\NASP\\RedBlackTree\\RedBlackTree\\RedBlackTree\\Content\\";
        public static void Main(string[] args)
        {
            var redBlackTree = new RedBlackTree<int>();


            for (int i = 0; i < 10; i++)
            {
                var key = Random.Shared.Next(100);
                Console.WriteLine($"Inserting key - {key}");
                redBlackTree.Insert(new Node<int>()
                {
                    Key = key,
                    Color = ColorEnum.Red
                });
            }

            var inOrder = redBlackTree.InOrderTraversal();

            var randIndex = Random.Shared.Next(inOrder.Count);

            var nodeToDelete = inOrder[randIndex];

            Console.WriteLine($"Node to delete is: {nodeToDelete.Key}");

            redBlackTree.Delete(nodeToDelete);

            //var inOrderAfterDeletion = redBlackTree.InOrderTraversal();

            //Console.WriteLine($"Number of elements left: {inOrderAfterDeletion.Count}");

            //foreach (var node in inOrderAfterDeletion)
            //{
            //    Console.WriteLine($"Key: {node.Key} | Parent: {node.Parent?.Key}");
            //}

            #region Main App
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Welcome to Red Black Tree Console App");

            //Console.WriteLine("Options:\n 1 - Insert New Node\n 2 - Inorder Traversal\n 3 - Exit");

            //var done = false;
            //while (!done)
            //{
            //    Console.Write("Pick option: ");
            //    var option = Console.ReadLine();

            //    switch (option)
            //    {
            //        case "1":
            //            Console.Write("Enter new key: ");
            //            int key;
            //            if (int.TryParse(Console.ReadLine(), out key))
            //            {
            //                redBlackTree.Insert(new Node<int>()
            //                {
            //                    Key = key,
            //                });
            //            }
            //            else
            //            {
            //                Console.WriteLine("Wrong input");
            //            }
            //            break;
            //        case "2":
            //            foreach (var node in redBlackTree.InOrderTraversal())
            //            {
            //                Console.WriteLine($"Key: {node.Key} | Color: {node.Color}");
            //            }
            //            break;
            //        default:
            //            done = true;
            //            break;
            //    }
            //}
            #endregion

            //var keys = new List<int>() { 8, 20, 74, 88, 80, 79, 26, 59, 82, 21 };
            //Node<int> nodeToDelete2 = null;

            //for (int i = 0; i < 10; i++)
            //{
            //    //var key = Random.Shared.Next(100);
            //    //Console.WriteLine($"Inserting key - {key}");
            //    var nodeToInsert = new Node<int>()
            //    {
            //        Key = keys[i],
            //        Color = ColorEnum.Red
            //    };
            //    redBlackTree.Insert(nodeToInsert);

            //    if (keys[i] == 8)
            //    {
            //        nodeToDelete2 = nodeToInsert;
            //    }
            //}

            //redBlackTree.Delete(nodeToDelete2);

            //var inOrderAfterDeletion = redBlackTree.InOrderTraversal();

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            string json = JsonConvert.SerializeObject(redBlackTree.Root, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            try
            {
                using (var streamWriter = new StreamWriter(_path + "rbt.json", false))
                {
                    streamWriter.Write(json);
                    Console.Write("Graph structure have been written to file");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }



            //Console.WriteLine($"Number of elements left: {inOrderAfterDeletion.Count}");

            //foreach (var node in inOrderAfterDeletion)
            //{
            //    Console.WriteLine($"Key: {node.Key} | Parent: {node.Parent?.Key}");
            //}
        }
    }
}