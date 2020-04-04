using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class LevelLoader : Singleton<LevelLoader>, ILoader<Level>
 {
     public Level Load(string path)
     {
         var json = Directory.GetFiles(path, @"*.json").First();
         var data = File.ReadAllText(json);
         JObject prePath = JObject.Parse(data);
         prePath.Add("Path", path);
         return prePath.ToObject<Level>();
     }
 
     public void Save(string path)
     {
         var json = JsonConvert.SerializeObject(AssetLoader.Instance.Level, (Formatting) 1);
         File.WriteAllText(path, json);
     }
 }