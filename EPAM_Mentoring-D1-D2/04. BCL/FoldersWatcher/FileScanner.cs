using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading;
using FoldersWatcher.Config.Elements;
using FoldersWatcher.Config.Section;
using FoldersWatcher.Resources;
using NLog;

namespace FoldersWatcher
{
    public static class FileScanner
    {
        private static readonly List<FileSystemWatcher> FileSystemWatchers = new List<FileSystemWatcher>();
        private static readonly Dictionary<string, string> TargetFolders = new Dictionary<string, string>();
        private static readonly string DefaultFolderPath = "test/Default";
        private static CultureInfo CultureInformation;
        private static readonly Logger _logger = LogManager.GetLogger(typeof(FileScanner).Name);

        public static void Initialize()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var section = (FileSystemWatcherConfigSection)config.Sections["FileSystemWatcher"];
            foreach (var folder in section.Folders)
            {
                FileSystemWatchers.Add(new FileSystemWatcher(((FolderElement)folder).Path));
            }
            foreach (var rule in section.Rules)
            {
                RuleElement ruleElement = (RuleElement)rule;
                TargetFolders.Add(ruleElement.TargetFolder, ruleElement.Filter);
            }
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(section.Culture.Name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(section.Culture.Name);
        }

        public static void StartListening()
        {
            foreach (var watcher in FileSystemWatchers)
            {
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.EnableRaisingEvents = true;
                _logger.Info(Messages.StartListening);
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            _logger.Info(Messages.FolderOrFileChanged);
            FileAttributes attr = File.GetAttributes(e.FullPath);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                string[] files = Directory.GetFiles(e.FullPath);
                foreach (var file in files)
                {
                    MoveFileWithRule(file);
                }
            }
            else
            {
                MoveFileWithRule(e.FullPath);
            }
        }

        private static void MoveFileWithRule(string file)
        {
            var matched = false;
            foreach (var folder in TargetFolders)
            {
                if (!Regex.IsMatch(file, folder.Value)) continue;
                _logger.Info(Messages.RuleMatched);
                File.Move(file, folder.Key + "\\" + file.Split('\\').LastOrDefault());
                matched = true;
            }
            if (!matched)
            {
                _logger.Info(Messages.NoRuleMatched);
                File.Move(file, DefaultFolderPath + "\\" + file.Split('\\').LastOrDefault());
            }
        }
    }
}
