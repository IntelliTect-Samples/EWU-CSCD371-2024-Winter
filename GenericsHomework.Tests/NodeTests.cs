using System.Xml.Linq;

namespace GenericsHomework.Tests;
    public class NodeTests
    {
       [Fact]
        public void Node_SingleNode_PointsToSelf()
            {
                // Arrange
                Node<string> newNode = new Node<string>("hola");

                // Act - Nothing to act on for this test

                // Assert
                Assert.NotNull(newNode.Next); // Ensure Next property is not null
                Assert.Equal(newNode, newNode.Next); // Ensure Next property points to itself
            }
        [Fact]
        public void Append_AddsNodeAfterFirst_Success()
        {
            Node<string> headNode = new("start");
            headNode.Append("second");

            Assert.NotNull(headNode.Next);
            Assert.Equal("second", headNode.Next.Value);
            Assert.Equal("start", headNode.Next.Next.Value); //checks that it is circular and links back to the first node
        }

        [Fact]
        public void Append_AddDuplicateNode_Failure()
        {
            Node<string> headNode = new("start");
            headNode.Append("second");

            Assert.Throws<ArgumentException>(() => headNode.Append("second"));
        }

        [Fact]
        public void Exists_ValueExists_ReturnsTrue()
        {
            // Arrange
            Node<string> node = new Node<string>("Hello");

            // Act
            bool exists = node.Exists("Hello");

            // Assert
            Assert.True(exists);
        }


        [Fact]
        public void Exists_ValueDoesNotExist_ReturnsFalse()
        {
            // Arrange
            Node<string> node = new Node<string>("Hello");

            // Act
            bool exists = node.Exists("World");

            // Assert
            Assert.False(exists);
        }

        [Fact]
        public void ToString_StringMatch_ReturnsCorrectStringRepresentation()
        {
            // Arrange
            Node<int> node = new Node<int>(42);

            // Act
            string result = node.ToString();

            // Assert
            Assert.Equal("42", result);
        }

        [Fact]
        public void Clear_OnlyCurrentNodeRemainsinList_Success()
        {
            Node<string> headNode = new("start");
            headNode.Append("second");
            headNode.Append("third");
            headNode.Append("fourth");
            headNode.Clear();
            Assert.Equal("start", headNode.Next.Value);
            Assert.False(headNode.Exists("second"));
            Assert.False(headNode.Exists("third"));
            Assert.False(headNode.Exists("fourth"));


        }
}
