using System.Collections.Specialized;

namespace SImpl.DotNetStack.Diagnostics
{
    public class PropertyDiagnosticsSection : IDiagnosticsSection
    {
        public string Headline { get; set; }

        public NameValueCollection Properties { get; } = new NameValueCollection();
        
        public void Append(IDiagnosticsWriter writer)
        {
            foreach (string key in Properties.Keys)
            {
                writer.AppendLine($"- {key}:{Properties[key]}");
            }
            
        }
    }
}