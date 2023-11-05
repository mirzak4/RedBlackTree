using RedBlackTree;
using Xunit.Sdk;

namespace RedBlackTreeTests
{
    [TestClass]
    public class RedBlackTreeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var rbt = new RedBlackTree<int>();
            var result = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                var key = Random.Shared.Next(100);
                result.Add(key);

                rbt.Insert(new Node<int>()
                {
                    Key = key,
                    Color = ColorEnum.Red
                });
            }

            //var inorderTraversal = rbt.InOrderTraversal().Select;

            //Assert.IsTrue(result.SequenceEqual(inorderTraversal));
        }
    }
}