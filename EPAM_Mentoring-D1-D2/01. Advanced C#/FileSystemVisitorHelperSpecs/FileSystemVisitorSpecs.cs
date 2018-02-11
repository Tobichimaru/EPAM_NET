using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using FileSystemVisitorHelper;
using Machine.Fakes;
using Machine.Specifications;

namespace FileSystemVisitorHelperSpecs
{
    [Subject(typeof(FileSystemVisitor))]
    public class FileSystemVisitorSpecs
    {
        private static string initialDirectory;
        private static IEnumerable<string> findedFiles;
        private static int _fileFindedCount = 0;
        private static int _filteredFileFindedCount = 0;
        private static int _dirFindedCount = 0;
        private static int _filteredDirFindedCount = 0;

        public class FileSystemVisitorContext : WithSubject<FileSystemVisitor>
        {
            private Establish context = () =>
            {
                Subject = new FileSystemVisitor((str) => Regex.IsMatch(str, ".*\\.txt"));
                initialDirectory = "D:\\Test";
                if (!Directory.Exists(initialDirectory))
                    Directory.CreateDirectory(initialDirectory);
                if (!Directory.Exists("D:\\Test\\Test"))
                    Directory.CreateDirectory("D:\\Test\\Test");

                var filePaths = new List<string>
                {
                    "D:\\Test\\file1.txt",
                    "D:\\Test\\file2.txt",
                    "D:\\Test\\file1.png",
                    "D:\\Test\\file2.png",
                    "D:\\Test\\file3.txt",
                    "D:\\Test\\Test\\file1.txt",
                    "D:\\Test\\Test\\file2.txt"
                };
                foreach (var path in filePaths)
                {
                    if (File.Exists(path)) continue;
                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(path);
                        fs.Write(info, 0, info.Length);
                    }
                }
                
                Subject.FileFinded += () => _fileFindedCount++;
                Subject.FilteredFileFinded += () => _filteredFileFindedCount++;
                Subject.DirectoryFinded += () => _dirFindedCount++;
                Subject.FilteredDirectoryFinded += () => _filteredDirFindedCount++;
            };
        }
        
        public class events_hit_and_handled : FileSystemVisitorContext
        {
            private Because of = () =>
            {
                findedFiles = Subject.EnumerateFiles(initialDirectory);
                FileSystemVisitorEvents.InvokeFinish();
            };

            private It should_hit_file_finded_event = () => { _fileFindedCount.ShouldEqual(7); };

            private It should_hit_filtered_file_finded_event = () => { _filteredFileFindedCount.ShouldEqual(5); };

            private It should_hit_dir_finded_event = () => { _dirFindedCount.ShouldEqual(1); };

            private It should_hit_filtered_dir_finded_event = () => { _filteredDirFindedCount.ShouldEqual(0); };
        }
    }
}
