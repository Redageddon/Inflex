#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using UnityEditor;

namespace Packages.SFB
{
    public class StandaloneFileBrowserEditor : IStandaloneFileBrowser
    {
        public string[] OpenFilePanel(string title, string directory, ExtensionFilter[] extensions, bool multiSelect)
        {
            string path = extensions == null
                ? EditorUtility.OpenFilePanel(title, directory, "")
                : EditorUtility.OpenFilePanelWithFilters(title, directory, GetFilterFromFileExtensionList(extensions));

            return string.IsNullOrEmpty(path) ? new string[0] : new[] {path};
        }

        public void OpenFilePanelAsync(string title, string directory, ExtensionFilter[] extensions, bool multiSelect, Action<string[]> cb) =>
            cb.Invoke(this.OpenFilePanel(title, directory, extensions, multiSelect));

        public string[] OpenFolderPanel(string title, string directory, bool multiSelect)
        {
            string path = EditorUtility.OpenFolderPanel(title, directory, "");
            return string.IsNullOrEmpty(path) ? new string[0] : new[] {path};
        }

        public void OpenFolderPanelAsync(string title, string directory, bool multiSelect, Action<string[]> cb) =>
            cb.Invoke(this.OpenFolderPanel(title, directory, multiSelect));

        public string SaveFilePanel(string title, string directory, string defaultName, ExtensionFilter[] extensions)
        {
            string ext  = extensions != null ? extensions[0].Extensions[0] : "";
            string name = string.IsNullOrEmpty(ext) ? defaultName : defaultName + "." + ext;
            return EditorUtility.SaveFilePanel(title, directory, name, ext);
        }

        public void SaveFilePanelAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb) =>
            cb.Invoke(this.SaveFilePanel(title, directory, defaultName, extensions));

        // EditorUtility.OpenFilePanelWithFilters extension filter format
        private static string[] GetFilterFromFileExtensionList(IList<ExtensionFilter> extensions)
        {
            var filters = new string[extensions.Count * 2];
            for (int i = 0; i < extensions.Count; i++)
            {
                filters[i * 2]     = extensions[i].Name;
                filters[i * 2 + 1] = string.Join(",", extensions[i].Extensions);
            }

            return filters;
        }
    }
}

#endif