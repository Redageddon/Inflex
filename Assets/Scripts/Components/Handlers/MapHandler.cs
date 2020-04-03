using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class MapHandler : Singleton<MapHandler>, IHandlerBase<Map>
 {
     public Map Map { get; set; }
 
     public Map Load(string path)
     {
         var json = Directory.GetFiles(path, @"*.json").First();
         var data = File.ReadAllText(json);
         JObject prePath = JObject.Parse(data);
         prePath.Add("Path", path);
         return prePath.ToObject<Map>();
     }
 
     public void Save(string path)
     {
         var json = JsonConvert.SerializeObject(Map, (Formatting) 1);
         File.WriteAllText(path, json);
     }
 }