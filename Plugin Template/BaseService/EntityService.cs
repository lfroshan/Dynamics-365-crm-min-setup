using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

using Dynamics_365_Development_Template.BaseInterface;

namespace Dynamics_365_Development_Template.BaseService
{
    /// <summary>
    /// Service for basic CRUD operations on entities.
    /// </summary>
    public class EntityService : IEntityService
    {
        public IOrganizationService service { get; set; }

        public void InitializeOrganizationService(IOrganizationService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Creates the targeted record.
        /// </summary>
        /// <param name="entity">The entity record to be created.</param>
        /// <returns>Id of the record created.</returns>
        /// <exception cref="InvalidPluginExecutionException">Thrown if an error occurs during record creation.</exception>
        public Guid Create(Entity entity)
        {
            try
            {
                return service.Create(entity);
            }
            catch (System.ServiceModel.FaultException<OrganizationServiceFault> ex)
            {
                // Specific exception for invalid plugin execution
                throw new InvalidPluginExecutionException($"Error creating record: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions as needed
                throw new Exception($"Error creating record: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes the targeted record.
        /// </summary>
        /// <param name="entityLogicalName">The logical name of the entity.</param>
        /// <param name="id">The Id of the entity record to be deleted.</param>
        /// <exception cref="InvalidPluginExecutionException">Thrown if an error occurs during record deletion.</exception>
        public void Delete(string entityLogicalName, Guid id)
        {
            try
            {
                service.Delete(entityLogicalName, id);
            }
            catch (System.ServiceModel.FaultException<OrganizationServiceFault> ex)
            {
                // Specific exception for invalid plugin execution
                throw new InvalidPluginExecutionException($"Error deleting record: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions as needed
                throw new Exception($"Error deleting record: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the targeted record.
        /// </summary>
        /// <param name="entity">The entity record to be updated.</param>
        /// <exception cref="InvalidPluginExecutionException">Thrown if an error occurs during record update.</exception>
        public void Update(Entity entity)
        {
            try
            {
                service.Update(entity);
            }
            catch (System.ServiceModel.FaultException<OrganizationServiceFault> ex)
            {
                // Specific exception for invalid plugin execution
                throw new InvalidPluginExecutionException($"Error updating record: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions as needed
                throw new Exception($"Error updating record: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the Entity record based on the id and entity logical name.
        /// </summary>
        /// <typeparam name="T">The generic entity that is to be converted to and returned.</typeparam>
        /// <param name="entityLogicalName">The Logical name of the entity.</param>
        /// <param name="id">The id of the entity record.</param>
        /// <returns>Entity of Targeted type.</returns>
        /// <exception cref="InvalidPluginExecutionException">Thrown if an error occurs during record retrieval.</exception>
        public T GetById<T>(string entityLogicalName, Guid id) where T : Entity
        {
            try
            {
                return service.Retrieve(entityLogicalName, id, new ColumnSet(true)).ToEntity<T>();
            }
            catch (System.ServiceModel.FaultException<OrganizationServiceFault> ex)
            {
                // Specific exception for invalid plugin execution
                throw new InvalidPluginExecutionException($"Error retrieving record: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions as needed
                throw new Exception($"Error retrieving record: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the Entity record based on the id and entity logical name.
        /// </summary>
        /// <typeparam name="T">The generic entity that is to be converted to and returned.</typeparam>
        /// <param name="entityLogicalName">The Logical name of the entity.</param>
        /// <param name="id">The id of the entity record.</param>
        /// <param name="selectedAttributes">The requried columns/attributes to fetch.</param>
        /// <returns>Entity of Targeted type.</returns>
        /// <exception cref="InvalidPluginExecutionException">Thrown if an error occurs during record retrieval.</exception>
        public T GetById<T>(string entityLogicalName, Guid id, string[] selectedAttributes) where T : Entity
        {
            try
            {
                return service.Retrieve(entityLogicalName, id, new ColumnSet(selectedAttributes)).ToEntity<T>();
            }
            catch (System.ServiceModel.FaultException<OrganizationServiceFault> ex)
            {
                // Specific exception for invalid plugin execution
                throw new InvalidPluginExecutionException($"Error retrieving record: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions as needed
                throw new Exception($"Error retrieving record: {ex.Message}");
            }
        }
    }
}
