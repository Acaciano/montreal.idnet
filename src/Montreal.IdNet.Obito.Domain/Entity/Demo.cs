using Montreal.IdNet.Obito.Domain.Exceptions;
using Montreal.IdNet.Obito.Domain.Exceptions.Entities.CIR;
using TSystems.Core.Crosscutting.Common.Entity.Base.V2;

namespace Montreal.IdNet.Obito.Domain.Entity
{
    public class Demo : BaseEntity
    {
        private Demo() { }

        public Demo(string name, string description)
        {
            this.SetName(name);
            this.SetDescription(description);
        }

        public string Name { get; private set; }
        
        public string Description { get; private set; }
        
        public void SetName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (name.Length <= 250)
                {
                    this.Name = name;
                }
                else
                {
                    throw new DemoNameTooLongException();
                }
            }
            else
            {
                throw new InvalidDemoNameException();
            }
        }

        public void SetDescription(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                if (description.Length < 500)
                {
                    this.Description = description;
                }
                else
                {
                    throw new DemoDescriptionTooLongException();
                }
            }
            else
            {
                throw new DemoDescriptionTooLongException();
            }
        }
    }
}
