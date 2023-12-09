using Montreal.IdNet.Obito.Core.Resources;
using System;

namespace Montreal.IdNet.Obito.Domain.Exceptions
{
    public class InvalidDemoNameException : DomainException
    {
        public InvalidDemoNameException() : base(DomainMessages.Demo_Name_Invalid)
        {

        }
    }
}
