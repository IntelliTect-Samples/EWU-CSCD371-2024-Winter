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
        public void Append_AddedNodes_SuccesfullyReturnsValue()
        {
            Node <string> newNode = new Node<string>("Hiiii");
            newNode.Append("You rock");
            
            Assert.Equal("You rock", newNode.Next.Data);
           
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

    }
}