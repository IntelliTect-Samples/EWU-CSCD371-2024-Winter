using System;

namespace Logger;

public interface IEntity
{
// Place members here
// Int only setter "Guid"
Guid Id { get; init; }
string Name { get; }
}