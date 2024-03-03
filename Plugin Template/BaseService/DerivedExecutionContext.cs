using System;
using Microsoft.Xrm.Sdk;

namespace Dynamics_365_Development_Template.BaseService
{
    /// <summary>
    /// Initializes the execution context for plugin development.
    /// </summary>
    public class DerivedExecutionContext
    {
        // Access any necessary context parameters from here.
        public IPluginExecutionContext context { get; set; }

        public Guid _entityRecordId { get; set; }
        public Entity _target {  get; set; }
        public Entity _preImage { get; set; }
        public Entity _postImage { get; set; }
        public int _operationStage { get; set; }
        public string _eventType { get; set; }

        // Services
        public ITracingService tracingService { get; set; }
        public IOrganizationService service { get; set; }

        public DerivedExecutionContext(IPluginExecutionContext context, ITracingService tracingService, IOrganizationService service)
        {
            this.context = context;

            _operationStage = context.Stage;
            _entityRecordId = context.PrimaryEntityId;
            _target = context.InputParameters["Target"] as Entity;
            _preImage = context.PreEntityImages["preimage"] as Entity;
            _postImage = context.PostEntityImages["postimage"] as Entity;
            _eventType = context.MessageName;
            this.tracingService = tracingService;
            this.service = service;
        }
    }
}
