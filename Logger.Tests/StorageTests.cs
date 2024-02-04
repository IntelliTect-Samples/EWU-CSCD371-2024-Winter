using Xunit;

namespace Logger.Tests;

    public class StorageTests
    {

    public Storage Storage { get; set; }
    public StorageTests() { 
        Storage = new Storage();
        Storage.Add(new Student("Trevor", "Rabin", 3455));
        Storage.Add(new Employee("Stuart", "Steiner", 120000));
        Storage.Add(new Book("Hunger Games", "Suzanne Collins"));
    }

    [Fact]
    public void Add_BookEnity_UpdatesEnitySet()
    {
        //Act
        IEntity book = new Book("of Mice and Men", "John Steinbeck");

        Storage.Add(book);

        Assert.True(Storage.Contains(book));
    }

    [Fact]
    public void Remove_HungerGamesBook_RemovesSucessful()
    {
        IEntity hungerGames = new Employee("Stuart", "Steiner", 120000);

        Storage.Remove(hungerGames);

        Assert.False(Storage.Contains(hungerGames));
    }

    }

