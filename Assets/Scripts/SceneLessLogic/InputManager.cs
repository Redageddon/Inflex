using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SceneLessLogic
{
    public class InputManager : MonoBehaviour
    {
        private static readonly Dictionary<string, KeyCode[]> CustomInput = new Dictionary<string, KeyCode[]>
        {
            {"RefreshMaps", new[] {KeyCode.LeftControl, KeyCode.R}}
        };

        public static bool MacroDown(string input) =>
            CustomInput[input].Take(CustomInput[input].Length - 1).All(Input.GetKey) &&
            Input.GetKeyDown(CustomInput[input][CustomInput.Count]);
    }
}