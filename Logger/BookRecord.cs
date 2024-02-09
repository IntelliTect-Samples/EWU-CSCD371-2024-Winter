using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
//Implemented implicitly because since it only implements one interface, there was no need to explicitly implement the interface member
public record class BookRecord(string Name, string Author) : BaseRecordEntity(Name)
{
    public string Author { get; init; } = Author;
}

