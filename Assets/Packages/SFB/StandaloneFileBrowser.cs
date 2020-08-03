using System;

namespace SFB
{
    public readonly struct ExtensionFilter
    {
        public readonly string   Name;
        public readonly string[] Extensions;

        public ExtensionFilter(string filterName, params string[] filterExtensions)
        {
            this.Name       = filterName;
            this.Extensions = filterExtensions;
        }
    }

    public static class StandaloneFileBrowser
    {
        private static readonly IStandaloneFileBrowser PlatformWrapper;

        static StandaloneFileBrowser()
        {
            #if UNITY_STANDALONE_OSX
            PlatformWrapper = new StandaloneFileBrowserMac();
            #elif UNITY_STANDALONE_WIN
            PlatformWrapper = new StandaloneFileBrowserWindows();
            #elif UNITY_STANDALONE_LINUX
            PlatformWrapper = new StandaloneFileBrowserLinux();
            #elif UNITY_EDITOR
            PlatformWrapper = new StandaloneFileBrowserEditor();
            #endif
        }

        /// <summary>
        ///     Native open file dialog
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="directory">Root directory</param>
        /// <param name="extension">Allowed extension</param>
        /// <param name="multiSelect">Allow multiple file selection</param>
        /// <returns>Returns array of chosen paths. Zero length array when cancelled</returns>
        public static string[] OpenFilePanel(string title, string directory, string extension, bool multiSelect)
        {
            var extensions = string.IsNullOrEmpty(extension) ? null : new[] {new ExtensionFilter("", extension)};
            return OpenFilePanel(title, directory, extensions, multiSelect);
        }

        /// <summary>
        ///     Native open file dialog
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="directory">Root directory</param>
        /// <param name="extensions">List of extension filters. Filter Example: new ExtensionFilter("Image Files", "jpg", "png")</param>
        /// <param name="multiSelect">Allow multiple file selection</param>
        /// <returns>Returns array of chosen paths. Zero length array when cancelled</returns>
        public static string[] OpenFilePanel(string title, string directory, ExtensionFilter[] extensions, bool multiSelect) =>
            PlatformWrapper.OpenFilePanel(title, directory, extensions, multiSelect);

        /// <summary>
        ///     Native open file dialog async
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="directory">Root directory</param>
        /// <param name="extension">Allowed extension</param>
        /// <param name="multiSelect">Allow multiple file selection</param>
        /// <param name="cb">Callback")</param>
        public static void OpenFilePanelAsync(string title, string directory, string extension, bool multiSelect, Action<string[]> cb)
        {
            var extensions = string.IsNullOrEmpty(extension) ? null : new[] {new ExtensionFilter("", extension)};
            OpenFilePanelAsync(title, directory, extensions, multiSelect, cb);
        }

        /// <summary>
        ///     Native open file dialog async
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="directory">Root directory</param>
        /// <param name="extensions">List of extension filters. Filter Example: new ExtensionFilter("Image Files", "jpg", "png")</param>
        /// <param name="multiSelect">Allow multiple file selection</param>
        /// <param name="cb">Callback")</param>
        public static void OpenFilePanelAsync(string title, string directory, ExtensionFilter[] extensions, bool multiSelect, Action<string[]> cb) =>
            PlatformWrapper.OpenFilePanelAsync(title, directory, extensions, multiSelect, cb);

        /// <summary>
        ///     Native open folder dialog
        ///     NOTE: Multiple folder selection doesn't supported on Windows
        /// </summary>
        /// <param name="title"></param>
        /// <param name="directory">Root directory</param>
        /// <param name="multiSelect"></param>
        /// <returns>Returns array of chosen paths. Zero length array when cancelled</returns>
        public static string[] OpenFolderPanel(string title, string directory, bool multiSelect) =>
            PlatformWrapper.OpenFolderPanel(title, directory, multiSelect);

        /// <summary>
        ///     Native open folder dialog async
        ///     NOTE: Multiple folder selection doesn't supported on Windows
        /// </summary>
        /// <param name="title"></param>
        /// <param name="directory">Root directory</param>
        /// <param name="multiSelect"></param>
        /// <param name="cb">Callback")</param>
        public static void OpenFolderPanelAsync(string title, string directory, bool multiSelect, Action<string[]> cb) =>
            PlatformWrapper.OpenFolderPanelAsync(title, directory, multiSelect, cb);

        /// <summary>
        ///     Native save file dialog
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="directory">Root directory</param>
        /// <param name="defaultName">Default file name</param>
        /// <param name="extension">File extension</param>
        /// <returns>Returns chosen path. Empty string when cancelled</returns>
        public static string SaveFilePanel(string title, string directory, string defaultName, string extension)
        {
            var extensions = string.IsNullOrEmpty(extension) ? null : new[] {new ExtensionFilter("", extension)};
            return SaveFilePanel(title, directory, defaultName, extensions);
        }

        /// <summary>
        ///     Native save file dialog
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="directory">Root directory</param>
        /// <param name="defaultName">Default file name</param>
        /// <param name="extensions">List of extension filters. Filter Example: new ExtensionFilter("Image Files", "jpg", "png")</param>
        /// <returns>Returns chosen path. Empty string when cancelled</returns>
        public static string SaveFilePanel(string title, string directory, string defaultName, ExtensionFilter[] extensions) =>
            PlatformWrapper.SaveFilePanel(title, directory, defaultName, extensions);

        /// <summary>
        ///     Native save file dialog async
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="directory">Root directory</param>
        /// <param name="defaultName">Default file name</param>
        /// <param name="extension">File extension</param>
        /// <param name="cb">Callback")</param>
        public static void SaveFilePanelAsync(string title, string directory, string defaultName, string extension, Action<string> cb)
        {
            var extensions = string.IsNullOrEmpty(extension) ? null : new[] {new ExtensionFilter("", extension)};
            SaveFilePanelAsync(title, directory, defaultName, extensions, cb);
        }

        /// <summary>
        ///     Native save file dialog async
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="directory">Root directory</param>
        /// <param name="defaultName">Default file name</param>
        /// <param name="extensions">List of extension filters. Filter Example: new ExtensionFilter("Image Files", "jpg", "png")</param>
        /// <param name="cb">Callback")</param>
        public static void SaveFilePanelAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb) =>
            PlatformWrapper.SaveFilePanelAsync(title, directory, defaultName, extensions, cb);
    }
}