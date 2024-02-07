
namespace Logger;
    public record class Employee(string FirstName, string LastName, int? EmployeeID) : Person(FirstName, LastName), IEntity
    {

        public int? EmployeeID { get; } = EmployeeID ?? throw new ArgumentNullException(nameof(EmployeeID));
        //Name member of IEntity should explicit becuase it has collision with Employee's name
        string IEntity.Name {get=> $"EntityType: {nameof(Employee)}, EntityID: {Id}, Name: {Name}, EmployeeID: {EmployeeID}"; }
        //Implicit, Id doesn't cause any issues
        public Guid Id { get; init; }

        public override string ToString() => $"Name: {base.ToString()}, EmployeeID: {EmployeeID}";


    }