using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace WavenCore.Equipments
{
    internal static class DeserializeEquipment
    {
        #region Static Fields and Methods

        private const string BaseDirectory = "Ressources/Equipements";

        private static readonly string AssemblyDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public static (List<Ring> rings, List<Cuff> cuffs) Deserialize() {
            List<Ring> ringList = new();
            List<Cuff> cuffList = new();

            string   baseDirectory = Path.Combine(AssemblyDirectory, BaseDirectory);
            string[] directories   = Directory.GetDirectories(baseDirectory);

            foreach (string directory in directories) {
                string[] subdirectories = Directory.GetDirectories(directory);

                if (directory.Contains("Ring")) {
                    ringList = Deserialize<Ring>(subdirectories);
                } else if (directory.Contains("Cuff")) {
                    cuffList = Deserialize<Cuff>(subdirectories);
                }
            }

            return (ringList, cuffList);
        }

        private static List<T> Deserialize<T>(IEnumerable<string> directories) where T : class {
            var list          = new List<T>();
            var xmlSerializer = new XmlSerializer(typeof(T));

            foreach (string directory in directories) {
                string[] files = Directory.GetFiles(directory);

                foreach (string file in files) {
                    using var steamReader = new StreamReader(file);

                    var item = xmlSerializer.Deserialize(steamReader) as T;
                    list.Add(item);
                }
            }

            return list;
        }

        #endregion
    }
}