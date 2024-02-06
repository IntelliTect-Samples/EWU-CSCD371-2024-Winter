using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class BookRecord ( string Author, string Title) : IEntity
{
    public Guid Id {  get; init; }
    public string Author { get; set; } = Author ?? throw new ArgumentNullException(nameof(Title));

    public string Title { get; set; } = Title ?? throw new ArgumentNullException(nameof(Title));

    public string Name { get => $"{nameof(BookRecord)}:{Author}, {Title}"; }

    //public override string Name { get => throw new NotImplementedException();  }


    public override string ToString() => $"{Author}, {Title}";


}

