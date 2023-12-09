using Montreal.IdNet.Obito.Core.Resources;
using System;

namespace Montreal.IdNet.Obito.Domain.Exceptions.Entities.CIR
{
    public class DemoDescriptionTooLongException : DomainException
    {
        public DemoDescriptionTooLongException() : base(DomainMessages.Demo_Description_Too_Long)
        {

        }
    }
}
