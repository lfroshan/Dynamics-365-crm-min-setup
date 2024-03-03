using Microsoft.Xrm.Sdk;
using System.ComponentModel;
using System.CodeDom.Compiler;
using Microsoft.Xrm.Sdk.Client;
using System.Runtime.Serialization;


namespace Dynamics_365_Development_Template.Entities.SomeEntity.Properties
{
    /// <summary>
    /// Represents the state of the SomeEntity entity.
    /// </summary>
    [DataContractAttribute]
    [GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9154")]
    [EntityLogicalNameAttribute("pre_some_entity_logical_name")]
    public class State : Entity, INotifyPropertyChanging, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the State class.
        /// </summary>
        public State() : base(EntityLogicalName) { }

        /// <summary>
        /// Gets the logical name of the SomeEntity entity.
        /// </summary>
        public const string EntityLogicalName = "pre_some_entity_logical_name";

        /// <summary>
        /// Gets the entity type code for SomeEntity.
        /// </summary>
        public const int EntityTypeCode = 2;

        /// <summary>
        /// Event raised when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event raised when a property is changing.
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanging(string propertyName)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        /// <summary>
        /// Gets or sets the attribute present in the table.
        /// </summary>
        [AttributeLogicalNameAttribute("pre_some_entity_attribute")]
        public string SchemaName
        {
            get
            {
                return GetAttributeValue<string>("pre_some_entity_attribute");
            }
            set
            {
                OnPropertyChanging(nameof(SchemaName));
                SetAttributeValue("pre_some_entity_attribute", value);
                OnPropertyChanged(nameof(SchemaName));
            }
        }
    }
}
