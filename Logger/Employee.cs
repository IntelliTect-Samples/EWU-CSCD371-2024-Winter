﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record Employee(Guid Id, Name FullName) : IEntity
{
    public string Name => string.IsNullOrEmpty(FullName.MiddleName)
        ? $"{FullName.FirstName} {FullName.LastName}"
        : $"{FullName.FirstName} {FullName.MiddleName} {FullName.LastName}";
}
