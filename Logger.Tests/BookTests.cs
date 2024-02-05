﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookRecord_InitilizeName_Success()
        {
            BookRecord book = new BookRecord("My Book");
            Assert.Equal("My Book", book.Name);
        }

        [Fact]
        public void BookRecord_SameBookEquals_Success()
        {
            BookRecord book1 = new BookRecord("Is it my book?");
            BookRecord book2 = book1 with { };
            Assert.True(book1.Equals(book2));   
        }

        [Fact]
        public void BookRecord_TwoBooksNotEquals_Success()
        {
            BookRecord book1 = new BookRecord("Narnia");
            BookRecord book2 = new BookRecord("Narnia");
            Assert.False(book1.Equals(book2));
        }
    }
}
