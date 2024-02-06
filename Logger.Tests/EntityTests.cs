using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests
{
    public class EntityTests
    {
        [Fact]
        public void Book_InitialzeBookWithTitle_Success()
        {
            string title = "Lord of the Flies";
            Book book1 = new(title);

            Assert.Equal(title, book1.Name);
        }

        [Fact]
        public void Book_InitialzeTwoBookWithSameTitle_NotEqual()
        {
            string title = "Lord of the Flies";
            Book book1 = new(title);
            Book book2 = new(title);

            Assert.NotEqual(book1, book2);
        }
        
        [Fact]
        public void Book_InitialzeBookWithNullTitle_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new Book(null!));
        }

        [Fact]
        public void Book_InitialzeBookWithBlankTitle_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Book(" "));
        }
    }
}
