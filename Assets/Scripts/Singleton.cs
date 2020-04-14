// code from http://wiki.unity3d.com/index.php/Singleton
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool _shuttingDown;
    private static readonly object Lock = new object();
    private static T _mInstance;
    
    public static T Instance
    {
        get
        {
            if (_shuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed. Returning null.");
                return null;
            }
 
            lock (Lock)
            {
                if (_mInstance == null)
                {
                    _mInstance = (T)FindObjectOfType(typeof(T));
                    
                    if (_mInstance == null)
                    {
                        var singletonObject = new GameObject();
                        _mInstance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T) + " (Singleton)";
                        
                        DontDestroyOnLoad(singletonObject);
                    }
                }
 
                return _mInstance;
            }
        }
    }

    private void OnApplicationQuit() => _shuttingDown = true;

    private void OnDestroy() => _shuttingDown = true;
}