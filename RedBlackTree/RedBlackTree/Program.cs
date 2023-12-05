using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RedBlackTree
{
    internal class Program
    {
        // Specify your directory to the project
        private static readonly string _jsonPath = "C:\\Users\\mirza.kadric\\NASP\\RedBlackTree\\RedBlackTree\\RedBlackTree\\Content\\";
        public static void Main(string[] args)
        {
            var redBlackTree = new RedBlackTree<int>();

            #region Random Test
            for (int i = 0; i < 30; i++)
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

            var deleteIndexes = new List<int>();

            for (int i = 0; i < 13; i++)
            {
                var randIndex = Random.Shared.Next(inOrder.Count);

                if (!deleteIndexes.Contains(randIndex))
                {
                    deleteIndexes.Add(randIndex);
                }
                else
                {
                    i--;
                }
            }

            foreach (var index in deleteIndexes)
            {
                var nodeToDelete = inOrder[index];
                redBlackTree.Delete(nodeToDelete);
                Console.WriteLine($"Node to delete is: {nodeToDelete.Key}");
            }

            string json = JsonConvert.SerializeObject(redBlackTree.Root, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.All });

            try
            {
                using (var streamWriter = new StreamWriter(_jsonPath + "rbt.json", false))
                {
                    streamWriter.Write(json);
                    Console.WriteLine("Graph structure have been written to file");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            #endregion

            #region Custom Test
            //var keys = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            //Node<int> nodeToDelete2 = null;

            //for (int i = 0; i < 10; i++)
            //{
            //    var key = Random.Shared.Next(100);
            //    Console.WriteLine($"Inserting key - {key}");
            //    var nodeToInsert = new Node<int>()
            //    {
            //        Key = keys[i],
            //        Color = ColorEnum.Red
            //    };
            //    redBlackTree.Insert(nodeToInsert);

            //    if (keys[i] == 71)
            //    {
            //        nodeToDelete2 = nodeToInsert;
            //    }
            //}

            //redBlackTree.Delete(nodeToDelete2);

            //var inOrderAfterDeletion = redBlackTree.InOrderTraversal();
            #endregion

            #region Main App
            //Console.WriteLine("Welcome to Red Black Tree Console App");

            //Console.WriteLine("Options:\n 1 - Insert New Node\n 2 - Inorder Traversal\n 3 - Delete Node\n 4 - Write to JSON file\n 5 - Exit");

            //var done = false;
            //while (!done)
            //{
            //    Console.Write("Pick option: ");
            //    var option = Console.ReadLine();

            //    switch (option)
            //    {
            //        case "1":
            //            Console.Write("Enter new key: ");
            //            int newKey;
            //            if (int.TryParse(Console.ReadLine(), out newKey))
            //            {
            //                redBlackTree.Insert(new Node<int>()
            //                {
            //                    Key = newKey,
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
            //        case "3":
            //            Console.Write("Enter key to delete: ");
            //            int keyToDelete;
            //            if (int.TryParse(Console.ReadLine(), out keyToDelete))
            //            {
            //                var nodeToDelete = redBlackTree.Find(keyToDelete);
            //                if (nodeToDelete.IsNill())
            //                {
            //                    Console.WriteLine("Key does not exist in the tree");
            //                }
            //                else
            //                {
            //                    redBlackTree.Delete(nodeToDelete);
            //                    Console.WriteLine($"Node with key: {keyToDelete} deleted");
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Wrong input");
            //            }
            //            break;
            //        case "4":
            //            string json = JsonConvert.SerializeObject(redBlackTree.Root, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.All });

            //            try
            //            {
            //                using (var streamWriter = new StreamWriter(_jsonPath + "rbt.json", false))
            //                {
            //                    streamWriter.Write(json);
            //                    Console.WriteLine("Graph structure have been written to file");
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.Write(ex.Message);
            //            }
            //            break;

            //        default:
            //            done = true;
            //            break;
            //    }
            //}
            #endregion
        }
    }
}