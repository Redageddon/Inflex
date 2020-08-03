using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static readonly object Lock = new object();
    private static          bool   shuttingDown;
    private static          T      instance;

    public static T Instance
    {
        get
        {
            if (shuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed. Returning null.");
                return null;
            }

            lock (Lock)
            {
                if (instance != null)
                {
                    return instance;
                }

                instance = (T)FindObjectOfType(typeof(T));

                if (instance != null)
                {
                    return instance;
                }

                GameObject singletonObject = new GameObject();
                instance             = singletonObject.AddComponent<T>();
                singletonObject.name = typeof(T) + " (Singleton)";

                DontDestroyOnLoad(singletonObject);

                return instance;
            }
        }
    }

    private void OnApplicationQuit() => shuttingDown = true;

    private void OnDestroy() => shuttingDown = true;
}