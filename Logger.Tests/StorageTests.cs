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
    
    [Fact]
    public void Get_ReturnsEntityWithExpectedGuid_EntityExistsInStorage()
    {
        // Arrange
        var storage = new Storage();
        var expectedGuid = Guid.NewGuid();
        var student = new StudentRecord(new FullNameRecord("John", "Doe"))
        {
            Id = expectedGuid // Set the student's Id to the expected GUID
        };
        storage.Add(student);

        // Act
        var retrievedStudent = storage.Get(expectedGuid);

        // Assert
        Assert.NotNull(retrievedStudent);
        Assert.Equal(expectedGuid, retrievedStudent.Id);
    }

    [Fact]
        public void Get_ReturnsEmployeeWithExpectedGuid_EntityExistsInStorage()
        {
            // Arrange
            var storage = new Storage();
            var expectedGuid = Guid.NewGuid();
            var employee = new EmployeeRecord(new FullNameRecord("John", "Doe"))
            {
                Id = expectedGuid // Set the employee's Id to the expected GUID
            };
            storage.Add(employee);

            // Act
            var retrievedEmployee = storage.Get(expectedGuid);

            // Assert
            Assert.NotNull(retrievedEmployee);
            Assert.Equal(expectedGuid, retrievedEmployee.Id);
        }

}