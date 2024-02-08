using GenericsHomework;
namespace GenericsTests
{
    public class NodeTests
    {
        [Fact]

        public void NodeConstructor_NullNode_ThrowsNulReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new Node<object>(null!));

        }
        [Fact]
        public void Append_NextNode_ReturnsValue()
        {
            Node<string> newNode = new Node<string>("Hiiii");
            newNode.Append("You rock");
            Assert.Equal("You rock", newNode.Next.Data);
           
        }

    }
}