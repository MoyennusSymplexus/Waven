using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using WavenCore.Classes;

namespace WavenCore.Spells
{
    internal static class DeserializeSpells
    {
        #region Static Fields and Methods

        private const string BaseDirectory = "Ressources/Spells";

        private static readonly string AssemblyDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public static List<Spell> DeserializeGeneric(Character character) {
            string baseDirectory  = Path.Combine(AssemblyDirectory, BaseDirectory);
            string classDirectory = Path.Combine(baseDirectory,     character.Class);

            List<Spell> generic = Deserialize<Spell>(classDirectory);

            return generic;
        }

        public static List<Spell> DeserializeSpecific(Character character) {
            string      baseDirectory     = Path.Combine(AssemblyDirectory, BaseDirectory);
            string      classDirectory    = Path.Combine(baseDirectory,     character.Class);
            string      subclassDirectory = Path.Combine(classDirectory,    character.SubClass);
            List<Spell> specific          = Deserialize<Spell>(subclassDirectory);

            return specific;
        }

        private static List<T> Deserialize<T>(string directory) where T : class {
            var list          = new List<T>();
            var xmlSerializer = new XmlSerializer(typeof(T));

            string[] files = Directory.GetFiles(directory);

            foreach (string file in files) {
                using var steamReader = new StreamReader(file);

                var item = xmlSerializer.Deserialize(steamReader) as T;
                list.Add(item);
            }

            return list;
        }

        #endregion
    }
}