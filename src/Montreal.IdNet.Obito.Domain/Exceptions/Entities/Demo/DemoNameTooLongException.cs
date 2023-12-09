using Montreal.IdNet.Obito.Core.Resources;
using System;

namespace Montreal.IdNet.Obito.Domain.Exceptions.Entities.CIR
{
    public class DemoNameTooLongException : DomainException
    {
        public DemoNameTooLongException() : base(DomainMessages.Demo_Name_TooLong)
        {

        }
    }
}
