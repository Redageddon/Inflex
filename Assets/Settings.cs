using System;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public static KeyCode[] Keys = {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};
    public static float Volume;
    
    public void SetVolume(float volume)
    {
        Volume = volume;
    }

    public void SetKeyCode0()
    {
        foreach (KeyCode keyCode in )
        {
            if (Input.GetKeyDown(keyCode))
            {
                
            }
        }
    }
}
