using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record struct BookRecord : IEntity
    {
        public Guid Id { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



        public BookRecord() 
        {
        
        }
    }
}
