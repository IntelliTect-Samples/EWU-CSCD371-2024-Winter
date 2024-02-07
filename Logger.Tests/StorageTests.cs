using Xunit;

namespace Logger.Tests;

    public class StorageTests
    {

    public Storage Storage { get; set; }
    public StorageTests() { 
        Storage = new Storage();
        Storage.Add(new Student("Trevor", "Rabin"));
        Storage.Add(new Employee("Stuart", "Steiner"));
        Storage.Add(new Book("Hunger Games", 1028493829485));
    }

    [Fact]
    public void Add_BookEnity_UpdatesEnitySet()
    {
        //Act
        IEntity book = new Book("of Mice and Men", 0344828173920);

        Storage.Add(book);

        Assert.True(Storage.Contains(book));
    }

    [Fact]
    public void Remove_EmployeeEnity_RemovesSucessful()
    {
        IEntity employeeEntity = new Employee("Stuart", "Steiner");

        Storage.Remove(employeeEntity);

        Assert.False(Storage.Contains(employeeEntity));
    }

    [Fact]
    public void Get_StudentEnityExists_ReturnsStudentEnity()
    {
        var testGuid = Guid.NewGuid();
        IEntity student = new Student("Alexa", "Darrington")
        {
            Id = testGuid,
        };
        Guid studentGuid = student.Id;
        Storage.Add(student);

        IEntity copy = Storage.Get(studentGuid)!;
        Assert.NotNull(copy);
        Assert.Equal(student, copy);
    }

    }

