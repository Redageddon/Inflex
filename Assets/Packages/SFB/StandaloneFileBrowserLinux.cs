#if UNITY_STANDALONE_LINUX
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace SFB
{
    public class StandaloneFileBrowserLinux : IStandaloneFileBrowser
    {
        private static Action<string[]> _openFileCb;
        private static Action<string[]> _openFolderCb;
        private static Action<string>   _saveFileCb;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AsyncCallback(string path);

        [DllImport("StandaloneFileBrowser")]
        private static extern void DialogInit();

        [DllImport("StandaloneFileBrowser")]
        private static extern IntPtr DialogOpenFilePanel(string title, string directory, string extension, bool multiSelect);

        [DllImport("StandaloneFileBrowser")]
        private static extern void DialogOpenFilePanelAsync(string        title,
                                                            string        directory,
                                                            string        extension,
                                                            bool          multiSelect,
                                                            AsyncCallback callback);

        [DllImport("StandaloneFileBrowser")]
        private static extern IntPtr DialogOpenFolderPanel(string title, string directory, bool multiSelect);

        [DllImport("StandaloneFileBrowser")]
        private static extern void DialogOpenFolderPanelAsync(string title, string directory, bool multiSelect, AsyncCallback callback);

        [DllImport("StandaloneFileBrowser")]
        private static extern IntPtr DialogSaveFilePanel(string title, string directory, string defaultName, string extension);

        [DllImport("StandaloneFileBrowser")]
        private static extern void DialogSaveFilePanelAsync(string        title,
                                                            string        directory,
                                                            string        defaultName,
                                                            string        extension,
                                                            AsyncCallback callback);

        public StandaloneFileBrowserLinux() => DialogInit();

        public string[] OpenFilePanel(string title, string directory, ExtensionFilter[] extensions, bool multiSelect)
        {
            string paths = Marshal.PtrToStringAnsi(DialogOpenFilePanel(
                                                       title,
                                                       directory,
                                                       GetFilterFromFileExtensionList(extensions),
                                                       multiSelect));
            return paths.Split((char)28);
        }

        public void OpenFilePanelAsync(string title, string directory, ExtensionFilter[] extensions, bool multiSelect, Action<string[]> cb)
        {
            _openFileCb = cb;
            DialogOpenFilePanelAsync(
                title,
                directory,
                GetFilterFromFileExtensionList(extensions),
                multiSelect,
                result => { _openFileCb.Invoke(result.Split((char)28)); });
        }

        public string[] OpenFolderPanel(string title, string directory, bool multiSelect)
        {
            string paths = Marshal.PtrToStringAnsi(DialogOpenFolderPanel(
                                                       title,
                                                       directory,
                                                       multiSelect));
            return paths.Split((char)28);
        }

        public void OpenFolderPanelAsync(string title, string directory, bool multiSelect, Action<string[]> cb)
        {
            _openFolderCb = cb;
            DialogOpenFolderPanelAsync(
                title,
                directory,
                multiSelect,
                result => { _openFolderCb.Invoke(result.Split((char)28)); });
        }

        public string SaveFilePanel(string title, string directory, string defaultName, ExtensionFilter[] extensions) =>
            Marshal.PtrToStringAnsi(DialogSaveFilePanel(
                                        title,
                                        directory,
                                        defaultName,
                                        GetFilterFromFileExtensionList(extensions)));

        public void SaveFilePanelAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb)
        {
            _saveFileCb = cb;
            DialogSaveFilePanelAsync(
                title,
                directory,
                defaultName,
                GetFilterFromFileExtensionList(extensions),
                result => { _saveFileCb.Invoke(result); });
        }

        private static string GetFilterFromFileExtensionList(ExtensionFilter[] extensions)
        {
            if (extensions == null)
            {
                return "";
            }

            string filterString = "";
            foreach (ExtensionFilter filter in extensions)
            {
                filterString += filter.Name + ";";

                filterString = filter.Extensions.Aggregate(filterString, (current, ext) => current + (ext + ","));

                filterString = filterString.Remove(filterString.Length - 1);
                filterString += "|";
            }

            filterString = filterString.Remove(filterString.Length - 1);
            return filterString;
        }
    }
}

#endif