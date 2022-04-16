using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

namespace Tech.IO.Saves
{
    public static class SaveIO
    {
        public static void SaveFile(object data, string path)
        {
            //if path doesnt have .dmg ending add it
            if (!path.Substring(path.Length - 4).Equals(".dmg")) path += ".dmg";
            
            var stream = File.Open(path, FileMode.Create);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }

        public static Dictionary<string, object> LoadFile(string path)
        {
            //wenn es noch keinen save file gibt
            if (!File.Exists(path))
            {
                return new Dictionary<string, object>();
            }

            //file stream machen und deserializete data in dictionary packen
            FileStream stream = File.Open(path, FileMode.Open);
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>) formatter.Deserialize(stream);
        }

        public static string GenerateNewFileName(string prefix = "save")
        {
            return prefix + "-" + GUID.Generate().ToString().Substring(0,10);
        }
    }
}