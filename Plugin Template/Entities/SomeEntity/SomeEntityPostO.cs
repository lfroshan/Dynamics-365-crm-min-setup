using Microsoft.Xrm.Sdk;
using Dynamics_365_Development_Template.BaseService;
using Dynamics_365_Development_Template.Entities.SomeEntity.Properties;
using Dynamics_365_Development_Template.BaseProperties.Constants.Errors;
using Dynamics_365_Development_Template.BaseProperties.Constants.OptionSets;
using Dynamics_365_Development_Template.Entities.SomeEntity.Service;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Dynamics_365_Development_Template.Entities.SomeEntity
{
    /// <summary>
    /// Custom plugin for handling post-operation events related to SomeEntity in Dynamics 365 CRM.
    /// </summary>
    public class SomeEntityPostOperationPlugin : BasePlugin
    {
        /// <summary>
        /// Executes the custom logic based on the type of event triggered.
        /// </summary>
        /// <param name="context">Derived execution context for plugin development.</param>
        public override void Execute(DerivedExecutionContext context)
        {
            switch (context._eventType)
            {
                case EventMessage.Create:
                    // Example: Run both blocking and non-blocking operations in parallel
                    List<Task> tasksList = new List<Task>
                    {
                        Task.Run(async () => await DoNonBlockingOperation(context)),
                        Task.Run(() => DoBlockingOperations(context))
                    };

                    Task.WaitAll(tasksList.ToArray());

                    PerformFinalOperation();
                    break;
                case EventMessage.Delete:
                    // Handle Delete event
                    break;
                case EventMessage.Update:
                    // Handle Update event
                    break;
                default:
                    throw new InvalidPluginExecutionException(ValidationErrors.UNINTENDED_EVENT);
            }

            // Perform final operations after event handling
            PerformFinalOperation();
        }

        /// <summary>
        /// Performs blocking operations related to the post-operation event.
        /// </summary>
        /// <param name="context">Derived execution context for plugin development.</param>
        public override void DoBlockingOperations(DerivedExecutionContext context)
        {
            // Example: Perform blocking operation here
        }

        /// <summary>
        /// Performs non-blocking operations asynchronously related to the post-operation event.
        /// </summary>
        /// <param name="context">Derived execution context for plugin development.</param>
        /// <returns>An asynchronous task.</returns>
        public override async Task DoNonBlockingOperation(DerivedExecutionContext context)
        {
            // Example: Perform non-blocking operation asynchronously (e.g., external network calls)
            await SomeNonBlockingAsyncTaskExample();
        }

        /// <summary>
        /// Performs final operations after all event handling logic.
        /// </summary>
        public override void PerformFinalOperation()
        {
            // Example: Perform final operations here
        }

        /// <summary>
        /// Example of a non-blocking asynchronous task.
        /// </summary>
        /// <returns>An asynchronous task.</returns>
        public async Task SomeNonBlockingAsyncTaskExample()
        {
            // Example: External network calls or asynchronous tasks
        }
    }
}
