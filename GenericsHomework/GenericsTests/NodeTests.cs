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
    }
}