using System.Runtime.Serialization;

namespace Dapplo.Confluence.Entities
{
    /// <summary>
    ///     Plain information, used in the description.
    ///     TODO: Find a better name
    ///     See: https://docs.atlassian.com/confluence/REST/latest
    /// </summary>
    [DataContract]
    public class Labels<TId>
    {
        /// <summary>
        ///     
        /// </summary>
        [DataMember(Name = "prefix", EmitDefaultValue = false)]
        public string Prefix { get; set; }

        /// <summary>
        ///    
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        ///    
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public TId Id { get; set; }

        /// <summary>
        ///    
        /// </summary>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }
    }
}