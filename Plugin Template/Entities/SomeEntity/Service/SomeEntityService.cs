using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

using Dynamics_365_Development_Template.BaseService;
using Dynamics_365_Development_Template.Entities.SomeEntity.Properties;
using Dynamics_365_Development_Template.Entities.SomeEntity.ServiceInterface;

namespace Dynamics_365_Development_Template.Entities.SomeEntity.Service
{
    /// <summary>
    /// Service for performing operations related to SomeEntity.
    /// </summary>
    public class SomeEntityService : EntityService, ISomeEntityService
    {
        private static readonly Lazy<SomeEntityService> instance = new Lazy<SomeEntityService>(() => new SomeEntityService());

        /// <summary>
        /// Gets the singleton instance of SomeEntityService.
        /// </summary>
        public static SomeEntityService Instance => instance.Value;

        private SomeEntityService() { }

        /// <summary>
        /// Performs a sample query operation with join.
        /// </summary>
        /// <param name="id">Dummy Id to demonstrate the query.</param>
        /// <returns>The result of the query as an EntityCollection.</returns>
        public EntityCollection SomeOperation(Guid id)
        {
            // Initialize the required columns / attributes to fetch.
            string[] attributes = { EntityFieldValues.Name, EntityFieldValues.CreatedOn };

            // Initialize the QueryExpression.
            QueryExpression query = new QueryExpression(EntityFieldValues.EntityLogicalName)
            {
                Distinct = true,
                ColumnSet = new ColumnSet(attributes)
            };

            // Add conditions or filters as needed.
            query.Criteria.AddCondition(EntityFieldValues.Id, ConditionOperator.Equal, id);

            // Add an inner join with another entity.
            LinkEntity linkEntity = new LinkEntity(EntityFieldValues.EntityLogicalName, "relatedentity", EntityFieldValues.Id, "relatedentityid", JoinOperator.Inner)
            {
                Columns = new ColumnSet("relatedEntityLogicalName")
            };
            linkEntity.LinkCriteria.AddCondition("relatedEntityLogicalName", ConditionOperator.NotNull);
            query.LinkEntities.Add(linkEntity);

            // Set ordering for the results.
            query.AddOrder(EntityFieldValues.CreatedOn, OrderType.Descending);

            // Retrieve the records using the query.
            return service.RetrieveMultiple(query);
        }

        /// <summary>
        /// Demonstrates using the global Entity Service to perform an operation.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        public void EntityServiceExampleOne(Entity entity)
        {
            // Create the entity using the inherited Create method from EntityService.
            Create(entity);
        }
    }
}
