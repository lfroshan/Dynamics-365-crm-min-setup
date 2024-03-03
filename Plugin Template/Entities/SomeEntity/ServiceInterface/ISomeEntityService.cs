using System;
using Microsoft.Xrm.Sdk;

using Dynamics_365_Development_Template.BaseInterface;

namespace Dynamics_365_Development_Template.Entities.SomeEntity.ServiceInterface
{
    public interface ISomeEntityService: IEntityService
    {
        EntityCollection SomeOperation(Guid id);
    }
}
