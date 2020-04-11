using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class LevelLoader
 {
     public static Level Load(string path)
     {
         var json = Directory.GetFiles(path, @"*.json").First();
         var data = File.ReadAllText(json);
         JObject prePath = JObject.Parse(data);
         prePath.Add("Path", path);
         return prePath.ToObject<Level>();
     }
 
     public static void Save(string path)
     {
         var json = JsonConvert.SerializeObject(Assets.Instance.Level, (Formatting) 1);
         File.WriteAllText(path, json);
     }
 }