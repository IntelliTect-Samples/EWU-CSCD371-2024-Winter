using GenericsHomework;
namespace GenericsTests
{
    public class NodeTests
    {
        [Fact]
        public void NodeConstructor_NullNode_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new Node<object>(null!));

        }

        [Fact]
        public void ToString_NullData_ThrowsException()
        {
            Assert.Throws<NullReferenceException>(() => new Node<object>(null!).ToString());
        }

        [Fact]
        public void ToString_ValidData_ReturnsStringSuccesfully()
        {
            Node<string> newNode = new Node<string>("Benjamin");
            newNode.Append("rocks!");
            Assert.Equal("Benjamin", newNode.ToString());
            Assert.Equal("rocks!", newNode.Next.ToString());

        }

        [Fact]
        public void Append_AddedNodes_SuccesfullyReturnsValue()
        {
            Node <string> newNode = new Node<string>("Hiiii");
            newNode.Append("You rock");
            
            Assert.Equal("You rock", newNode.Next.Data);
           
        }
        [Fact]
        public void Append_DuplicateNodeValue_ThrowsErrorSuccessfully()
        {
            Node<string> newNode = new Node<string>("Copy");
            Assert.Throws<DuplicateWaitObjectException>(() => newNode.Append("Copy"));

        }

        [Fact]
        public void Clear_ManyNodes_SuccessfullyClears()
        {
            Node<string> newNode = new Node<string>("Lets goo");
            newNode.Append("New Node1");
            newNode.Append("New Node2");
            newNode.Clear();

            Assert.Equal(newNode, newNode.Next);
        }

        [Fact]
        public void Exists_NodeExists_ReturnsTrue()
        {
            Node<string> newNode = new Node<string>("Johanne");
            newNode.Append("is");
            newNode.Append("the");
            newNode.Append("best!");

            Assert.True(newNode.Exists("best!"));
        }

        [Fact]
        public void Exists_NodeDoesNotExists_ReturnsFalse()
        {
            Node<string> newNode = new Node<string>("Johanne");
            newNode.Append("is");
            newNode.Append("the");
            newNode.Append("best!");

            Assert.False(newNode.Exists("Reeehat"));
        }


    }
}