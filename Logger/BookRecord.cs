using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class BookRecord(string Name, string Author) : BaseRecordEntity(Name)
{
    public string Author { get; init; } = Author;
}

