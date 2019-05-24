using BongoBD.Tasks.Task03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BngoBD.TasksTest
{
    [TestClass]
    public class Task03_WithoutRecursionTest
    {
        [TestMethod]
        public void LCA_WhenGivenInputIsNotCorrect_1()
        {
            var lcaNode = Task03.Lca1(null, null);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void LCA_WhenGivenInputIsNotCorrect_2()
        {
            var lcaNode = Task03.Lca1(null, new Node(null, 1));
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void LCA_NodeAreCorrect01()
        {
            Node node1 = new Node(null, 1);

            Node node2 = new Node(node1, 2);
            Node node3 = new Node(node1, 3);

            Node node4 = new Node(node2, 4);
            Node node5 = new Node(node2, 5);

            Node node6 = new Node(node3, 6);
            Node node7 = new Node(node3, 7);

            Node node8 = new Node(node4, 8);
            Node node9 = new Node(node4, 9);


            var lcaNode = Task03.Lca1(node6, node7);

            Assert.AreEqual(node3, lcaNode);
        }

        [TestMethod]
        public void LCA_NodeAreCorrect02()
        {
            Node node1 = new Node(null, 1);

            Node node2 = new Node(node1, 2);
            Node node3 = new Node(node1, 3);

            Node node4 = new Node(node2, 4);
            Node node5 = new Node(node2, 5);

            Node node6 = new Node(node3, 6);
            Node node7 = new Node(node3, 7);

            Node node8 = new Node(node4, 8);
            Node node9 = new Node(node4, 9);


            var lcaNode = Task03.Lca1(node3, node7);

            Assert.AreEqual(node3, lcaNode);
        }

    }
}
