﻿using System;

namespace Logger.Entity;

public record Employee(Guid Id, FullName FullName) : Person(Id, FullName), IEntity
{
    protected override string CalculateName()
    {
        return nameof(Employee);
    }
}

