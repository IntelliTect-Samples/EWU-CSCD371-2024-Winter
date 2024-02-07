using Xunit;

namespace Logger.Tests;

public class StorageTests {

     [Fact]
        public void Add_AddsItemToStorage_ItemExistsInStorage()
        {
            var storage = new Storage();
            var entity = new StudentRecord(new FullNameRecord("John", "uh", "Doe"));

            storage.Add(entity);

            Assert.True(storage.Contains(entity));
        }

    [Fact]
        public void Remove_RemovesItemFromStorage_ItemDoesNotExistInStorage()
        {
            var storage = new Storage();
            var entity = new StudentRecord(new FullNameRecord("John", "bruh", "Doe"));
            storage.Add(entity);

            storage.Remove(entity);

            Assert.False(storage.Contains(entity));
        }
}