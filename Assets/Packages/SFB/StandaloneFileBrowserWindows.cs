#if UNITY_STANDALONE_WIN

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Ookii.Dialogs;

namespace SFB
{
    // For fullscreen support
    // - WindowWrapper class and GetActiveWindow() are required for modal file dialog.
    // - "PlayerSettings/Visible In Background" should be enabled, otherwise when file dialog opened app window minimizes automatically.

    public class WindowWrapper : IWin32Window
    {
        public WindowWrapper(IntPtr handle) => this.Handle = handle;
        public IntPtr Handle { get; }
    }

    public class StandaloneFileBrowserWindows : IStandaloneFileBrowser
    {
        public string[] OpenFilePanel(string title, string directory, ExtensionFilter[] extensions, bool multiSelect)
        {
            VistaOpenFileDialog fd = new VistaOpenFileDialog {Title = title};
            if (extensions != null)
            {
                fd.Filter      = GetFilterFromFileExtensionList(extensions);
                fd.FilterIndex = 1;
            }
            else
            {
                fd.Filter = string.Empty;
            }

            fd.Multiselect = multiSelect;
            if (!string.IsNullOrEmpty(directory))
            {
                fd.FileName = GetDirectoryPath(directory);
            }

            DialogResult res       = fd.ShowDialog(new WindowWrapper(GetActiveWindow()));
            var          filenames = res == DialogResult.OK ? fd.FileNames : new string[0];
            fd.Dispose();
            return filenames;
        }

        public void OpenFilePanelAsync(string title, string directory, ExtensionFilter[] extensions, bool multiSelect, Action<string[]> cb) =>
            cb.Invoke(this.OpenFilePanel(title, directory, extensions, multiSelect));

        public string[] OpenFolderPanel(string title, string directory, bool multiSelect)
        {
            VistaFolderBrowserDialog fd = new VistaFolderBrowserDialog {Description = title};
            if (!string.IsNullOrEmpty(directory))
            {
                fd.SelectedPath = GetDirectoryPath(directory);
            }

            DialogResult res       = fd.ShowDialog(new WindowWrapper(GetActiveWindow()));
            var          filenames = res == DialogResult.OK ? new[] {fd.SelectedPath} : new string[0];
            fd.Dispose();
            return filenames;
        }

        public void OpenFolderPanelAsync(string title, string directory, bool multiSelect, Action<string[]> cb) =>
            cb.Invoke(this.OpenFolderPanel(title, directory, multiSelect));

        public string SaveFilePanel(string title, string directory, string defaultName, ExtensionFilter[] extensions)
        {
            VistaSaveFileDialog fd = new VistaSaveFileDialog {Title = title};

            string finalFilename = "";

            if (!string.IsNullOrEmpty(directory))
            {
                finalFilename = GetDirectoryPath(directory);
            }

            if (!string.IsNullOrEmpty(defaultName))
            {
                finalFilename += defaultName;
            }

            fd.FileName = finalFilename;
            if (extensions != null)
            {
                fd.Filter       = GetFilterFromFileExtensionList(extensions);
                fd.FilterIndex  = 1;
                fd.DefaultExt   = extensions[0].Extensions[0];
                fd.AddExtension = true;
            }
            else
            {
                fd.DefaultExt   = string.Empty;
                fd.Filter       = string.Empty;
                fd.AddExtension = false;
            }

            DialogResult res      = fd.ShowDialog(new WindowWrapper(GetActiveWindow()));
            string       filename = res == DialogResult.OK ? fd.FileName : "";
            fd.Dispose();
            return filename;
        }

        public void SaveFilePanelAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb) =>
            cb.Invoke(this.SaveFilePanel(title, directory, defaultName, extensions));

        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();

        // .NET Framework FileDialog Filter format
        // https://msdn.microsoft.com/en-us/library/microsoft.win32.filedialog.filter
        private static string GetFilterFromFileExtensionList(IEnumerable<ExtensionFilter> extensions)
        {
            string filterString = "";
            foreach (ExtensionFilter filter in extensions)
            {
                filterString += filter.Name + "(";

                filterString = filter.Extensions.Aggregate(filterString, (current, ext) => current + "*." + ext + ",");

                filterString =  filterString.Remove(filterString.Length - 1);
                filterString += ") |";

                filterString = filter.Extensions.Aggregate(filterString, (current, ext) => current + "*." + ext + "; ");

                filterString += "|";
            }

            filterString = filterString.Remove(filterString.Length - 1);
            return filterString;
        }

        private static string GetDirectoryPath(string directory)
        {
            string directoryPath = Path.GetFullPath(directory);
            if (!directoryPath.EndsWith("\\"))
            {
                directoryPath += "\\";
            }

            if (Path.GetPathRoot(directoryPath) == directoryPath)
            {
                return directory;
            }

            return Path.GetDirectoryName(directoryPath) + Path.DirectorySeparatorChar;
        }
    }
}

#endif