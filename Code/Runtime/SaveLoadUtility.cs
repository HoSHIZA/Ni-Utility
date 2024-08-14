using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace NiGames.Utility
{
    public static class SaveLoadUtility
    {
        public static void Save<T>(string fileName, T data)
        {
            var path = Path.Combine(Application.persistentDataPath, fileName);
            var file = File.Create(path);
            var formatter = new BinaryFormatter();
            
            formatter.Serialize(file, data);
            
            file.Close();
        }

        public static T Load<T>(string fileName)
        {
            var path = Path.Combine(Application.persistentDataPath, fileName);
            
            if (File.Exists(path))
            {
                var file = File.Open(path, FileMode.Open);
                var formatter = new BinaryFormatter();
                var data = (T)formatter.Deserialize(file);
                
                file.Close();
                
                return data;
            }
            
            return default;
        }
        
        public static bool SaveExists(string fileName)
        {
            var path = Path.Combine(Application.persistentDataPath, fileName);
            
            return File.Exists(path);
        }
        
        public static void DeleteSave(string fileName)
        {
            var path = Path.Combine(Application.persistentDataPath, fileName);
            
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}