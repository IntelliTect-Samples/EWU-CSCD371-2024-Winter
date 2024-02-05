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
        private string _name = name;

        public override string GetName()
        { 
            return _name; 
        }
        protected override void SetName(string name)
        {
            _name = name;
        }

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
        TestEntity entity = new("name");

        Assert.Equal("Name", entity.GetName());
    }
}

