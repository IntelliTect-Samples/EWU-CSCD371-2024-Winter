
namespace Logger;
public abstract record class BaseEntity : IEntity

    {
        //because this is an internal ID used by developers and not the same as an employee or student id it is implemented explicitly
         private Guid _InternalId = Guid.NewGuid();    
         Guid IEntity.Id { get => _InternalId; init => _InternalId = value; }

        // Name is abstract so classes that inherit are forced to implement it
        public abstract string Name { 
        get; 
       // set; 
    }
        public BaseEntity(Guid Id)
    {
        _InternalId = Id;
    }
    }