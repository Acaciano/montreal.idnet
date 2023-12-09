using Montreal.IdNet.Obito.Application.Exceptions;
using Montreal.IdNet.Obito.Domain.Entity;
using System;
using TSystems.Core.Crosscutting.Domain.ViewModel.Base.V2;

namespace Montreal.IdNet.Obito.Application.ViewModels
{
    public class DemoViewModel : BaseViewModelWithoutEntityProperties<Demo>
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override void LoadFromEntity(Demo entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public override Demo ConvertToEntity() => throw new ViewModelCannotBeCastedToEntity();

        public override void OverwriteEntity(Demo entity)
        {
            throw new ViewModelCannotBeCastedToEntity();
        }
    }
}
