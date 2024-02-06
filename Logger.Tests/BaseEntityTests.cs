using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Logger.Tests;
public class BaseEntityTests{
    private class TestEntity(string name) : BaseEntity
    {
        public override string Name { get; set; } = name;
    }
    [Fact]
    public void BaseEntity_ShouldImplementIEntityInterfaceImplicitly_SuccessfulSet()
    {
        TestEntity entity = new ("name");

        Assert.IsAssignableFrom<IEntity>(entity);
    }
    [Fact]
    public void RetrieveName_Name_Successful()
    {
        TestEntity entity = new("Name");

        Assert.Equal("Name", entity.Name);
    }
}

