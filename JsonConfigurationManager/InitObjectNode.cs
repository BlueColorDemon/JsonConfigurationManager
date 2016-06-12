using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using static System.Environment;
using static System.Activator;

namespace JsonConfigurationManager
{
    public class InitObjectNode
    {
        public string TypeName { get; set; }
        public int? UseProcessorCount { get; set; }
        public Dictionary<string, Object> InitArgs { get; set; }

        public InitObjectNode() { }

        public InitObjectNode(string typeName)
        {
            var type = Type.GetType(typeName, false);
            if (type == null)
            {
                var fullName = typeName + ", " + Assembly.GetCallingAssembly().FullName;
                type = Type.GetType(fullName, true);
            }
            Init(type);
        }

        public InitObjectNode(Type type)
        {
            Init(type);
        }

        private void Init(Type type) => TypeName = type.AssemblyQualifiedName;

        public virtual IEnumerable<T> GetObject<T>()
        {
            if (TypeName == null)
            {
                yield break;
            }

            Type type = Type.GetType(TypeName, true);

            var initArgsArr = InitArgs.Values.ToArray();

            int antal = UseProcessorCount.HasValue ? ProcessorCount + UseProcessorCount.Value : 1;

            for (int i = 0; i < antal; i++)
            {
                yield return (T)CreateInstance(type, initArgsArr);
            }
        }

    }
}
