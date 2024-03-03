using System;
using Microsoft.Xrm.Sdk;

namespace Dynamics_365_Development_Template.BaseInterface
{
    public interface IEntityService
    {
        Guid Create(Entity entity);
        void Update(Entity entity);
        void Delete(string entityLogicalName, Guid id);
        T GetById<T>(string entityLogicalName, Guid id) where T : Entity;
        T GetById<T>(string entityLogicalName, Guid id, string[] selectedAttributes) where T : Entity;
    }
}
