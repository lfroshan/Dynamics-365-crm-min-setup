using System;
using Microsoft.Xrm.Sdk;

using Dynamics_365_Development_Template.BaseService;
using Dynamics_365_Development_Template.BaseProperties.Constants.Errors;
using Dynamics_365_Development_Template.BaseInterface;
using System.Threading.Tasks;

namespace Dynamics_365_Development_Template
{
    /// <summary>
    /// Base class for custom plugins in Dynamics 365 CRM.
    /// </summary>
    public abstract class BasePlugin : IPlugin
    {
        /// <summary>
        /// Gets or sets the secure configuration string for the plugin.
        /// </summary>
        public string SecureConfigs { get; set; }

        /// <summary>
        /// Gets or sets the unsecure configuration string for the plugin.
        /// </summary>
        public string UnsecureConfigs { get; set; }

        private DerivedExecutionContext context;
        private IPluginExecutionContext baseContext;
        private IOrganizationService service;
        private ITracingService tracingService;

        /// <summary>
        /// Default constructor for BasePlugin.
        /// </summary>
        public BasePlugin() { }

        /// <summary>
        /// Parameterized constructor for BasePlugin.
        /// </summary>
        /// <param name="unsecureConfigs">Unsecure configuration string.</param>
        /// <param name="secureConfigs">Secure configuration string.</param>
        public BasePlugin(string unsecureConfigs, string secureConfigs) : this()
        {
            UnsecureConfigs = unsecureConfigs;
            SecureConfigs = secureConfigs;
        }

        /// <summary>
        /// Executes the custom plugin logic.
        /// </summary>
        /// <param name="serviceProvider">The service provider containing necessary services.</param>
        public void Execute(IServiceProvider serviceProvider)
        {
            InitializeServiceProviders(serviceProvider);

            // Ensure that the user is authorized to execute the plugin.
            Guid userId = baseContext.UserId;
            if (userId == Guid.Empty)
            {
                throw new InvalidPluginExecutionException(ValidationErrors.UNAUTHORIZED_PLUGIN_ACCESS);
            }

            // Create an organization service for the user.
            service = ((IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory)))
                        .CreateOrganizationService(userId);

            // Initialize the derived context for plugin development.
            context = new DerivedExecutionContext(baseContext, tracingService, service);

            // Execute the custom plugin logic after initialization.
            Execute(context);
        }

        /// <summary>
        /// Initializes the necessary service providers.
        /// </summary>
        /// <param name="serviceProvider">The service provider containing necessary services.</param>
        private void InitializeServiceProviders(IServiceProvider serviceProvider)
        {
            baseContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
        }

        /// <summary>
        /// Custom plugin logic to be implemented by derived classes.
        /// </summary>
        /// <param name="executionContext">Derived execution context for plugin development.</param>
        public abstract void Execute(DerivedExecutionContext executionContext);

        public abstract void DoBlockingOperations(DerivedExecutionContext context);

        public abstract Task DoNonBlockingOperation(DerivedExecutionContext context);

        public abstract void PerformFinalOperation();
    }
}
