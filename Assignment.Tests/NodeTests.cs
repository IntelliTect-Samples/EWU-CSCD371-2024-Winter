using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8602 
// Nullability of reference types in this context is checked appropriately

namespace Assignment.Tests;
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_SingleNode_PointsToSelf()
        {
            Node<string> newNode = new Node<string>("hola");

            Assert.IsNotNull(newNode.Next); // Ensure Next property is not null
            Assert.AreEqual(newNode, newNode.Next); // Ensure Next property points to itself
        }

        [TestMethod]
        public void Append_AddsNodeAfterFirst_Success()
        {
            Node<string> headNode = new("start");
            headNode.Append("second");

            Assert.IsNotNull(headNode.Next);
            Assert.AreEqual("second", headNode.Next.Value);
            Assert.AreEqual("start", headNode.Next.Next.Value); //checks that it is circular and links back to the first node
        }

        [TestMethod]
        public void Append_AddDuplicateNode_Failure()
        {
            Node<string> headNode = new("start");
            headNode.Append("second");

            Assert.ThrowsException<ArgumentException>(() => headNode.Append("second"));
        }

        [TestMethod]
        public void Exists_ValueExists_ReturnsTrue()
        {
            Node<string> node = new Node<string>("Hello");

            bool exists = node.Exists("Hello");

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void Exists_ValueDoesNotExist_ReturnsFalse()
        {
            Node<string> node = new Node<string>("Hello");

            bool exists = node.Exists("World");

            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void ToString_StringMatch_ReturnsCorrectStringRepresentation()
        {
            Node<int> node = new Node<int>(42);

            string result = node.ToString();

            Assert.AreEqual("42", result);
        }

        [TestMethod]
        public void ToString_HeadsNext_ReturnsCorrectStringRepresentation()
        {
            Node<int> node = new Node<int>(42);
            node.Append(16);

            string result = node.Next.ToString();

            Assert.AreEqual("16", result);
        }

        [TestMethod]
        public void Clear_OnlyCurrentNodeRemainsinList_Success()
        {
            Node<string> headNode = new("start");
            headNode.Append("second");
            headNode.Append("third");
            headNode.Append("fourth");
            headNode.Clear();
            Assert.AreEqual("start", headNode.Next.Value);
            Assert.IsFalse(headNode.Exists("second"));
            Assert.IsFalse(headNode.Exists("third"));
            Assert.IsFalse(headNode.Exists("fourth"));
        }

         [TestMethod]
        public void ChildItems_ReturnsExpectedItems_WhenMaximumIsLessThanNumberOfItems()
        {
            // Arrange
            var node1 = new Node<int>(1);
            var node2 = new Node<int>(2);
            var node3 = new Node<int>(3);

            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node1); // Create a circular linked list

            // Act
            var childItems = node1.ChildItems(maximum: 2);

            // Convert IEnumerable<int> to array
            var childItemsArray = childItems.ToArray();

            // Assert
            var expectedItems = new int[] { 1, 2 };
            CollectionAssert.AreEqual(expectedItems, childItemsArray);
        }

        [TestMethod]
        public void ChildItems_ReturnsAllItems_WhenMaximumIsGreaterThanNumberOfItems()
        {
            // Arrange
            var node1 = new Node<int>(1);
            var node2 = new Node<int>(2);
            var node3 = new Node<int>(3);

            node1.SetNext(node2);
            node2.SetNext(node3);
            node3.SetNext(node1); // Create a circular linked list

            // Act
            var childItems = node1.ChildItems(maximum: 4); // Requesting more items than available

            // Assert
            var expectedItems = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedItems, childItems.ToArray());
        }

        [TestMethod]
        public void ChildItems_ReturnsNoItems_WhenMaximumIsZero()
        {
            // Arrange
            var node1 = new Node<int>(1);

            // Act
            var childItems = node1.ChildItems(maximum: 0); // Requesting zero items

            // Assert
            Assert.IsFalse(childItems.Any()); // Check if the sequence is empty
        }

    [TestMethod]
    public void GetEnumerator_CircularLinkedList_EnumeratesItemsInOrder()
    {
        // Arrange
        var node1 = new Node<int>(1);
        var node2 = new Node<int>(2);
        var node3 = new Node<int>(3);

        node1.SetNext(node2);
        node2.SetNext(node3);
        node3.SetNext(node1);

        IEnumerator<int> enumerator = node1.GetEnumerator();
        List<int> actualItems = new List<int>();

        while (enumerator.MoveNext())
        {
            actualItems.Add(enumerator.Current);
        }

        int[] check = new int[] { 1, 2, 3 };
        CollectionAssert.AreEqual(check, actualItems);
    }

}
