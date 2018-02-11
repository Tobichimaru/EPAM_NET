using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CsQuery.ExtensionMethods.Internal;
using HtmlAgilityPack;

namespace wget
{
    public class WebParser
    {
        private readonly string _url;
        private readonly string _localPath;
        private string _hostName;
        private Queue<Node> _linksQueue;

        public WebParser(string url, string localPath)
        {
            _url = url;
            _localPath = localPath;
            InitializeFolder();
        }

        public async Task Parse(int level = 0)
        {
            _linksQueue = new Queue<Node>(new List<Node>
            {
                new Node
                {
                    Path = _url,
                    Level = 0
                }
            });
            
            while (!_linksQueue.IsNullOrEmpty())
            {
                var node = _linksQueue.Dequeue();
                if (node.Level > level) break;
                await ParseUrl(node);
            }
        }

        private async Task ParseUrl(Node node)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_url);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine("The HTTP query received not successful response");
                return;
            }

            //write html file
            var bytes = await response.Content.ReadAsByteArrayAsync();

            //load html tags  
            HtmlDocument hap = new HtmlDocument();
            hap.LoadHtml(new string(Encoding.GetEncoding("Windows-1251").GetChars(bytes)));
            

            //get all links     
            HtmlNodeCollection links = hap.DocumentNode.SelectNodes("//a");
            foreach (HtmlNode link in links)
            {
                var address = link.GetAttributeValue("href", null);
                link.SetAttributeValue("href",  GetFileName(address) + ".html");
                if (address == null) continue;
                _linksQueue.Enqueue(new Node
                {
                    Level = node.Level + 1,
                    Path = address
                });
            }

            //Create web client
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            //get all images     
            LoadFile(hap, wc, "//img", "src");
            LoadFile(hap, wc, "//link", "href");
            LoadFile(hap, wc, "//script", "src");

            //save html document
            FileStream stream = null;
            try
            {
                stream = File.Create(_localPath + '/' + GetFileDirectories(node.Path) + '/' + GetFileName(node.Path) + ".html");
                hap.Save(stream);
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {
            }
            finally
            {
                stream?.Dispose();
            }
        }

        private void LoadFile(HtmlDocument hap, WebClient wc, string tag, string source)
        {
            HtmlNodeCollection files = hap.DocumentNode.SelectNodes(tag);
            foreach (HtmlNode file in files)
            {
                var address = file.GetAttributeValue(source, null);
                if (address == null) continue;
                var directories = GetFileDirectories(address);
                var filename = GetFileName(address);
                var localAddress = _localPath  + directories +  filename;

                try
                {
                    CreateFolder(_localPath + '\\' + directories);
                    wc.DownloadFile(address, localAddress);
                }
                catch (Exception e)
                {
                    try
                    {
                        wc.DownloadFile(_hostName + address, localAddress);
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Could not load the file: {0}", address);
                        continue;
                    }
                }

                
                file.SetAttributeValue(source, Directory.GetCurrentDirectory() +'\\' + _localPath + '\\' + directories + filename);
            }
        }

        private void InitializeFolder()
        {
            CreateFolder(_localPath);
            var index = _url.IndexOf('/', 8);
            _hostName = _url.Substring(0, index) + '/';
        }

        private void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not create a directory at the local path specified.");
                    throw;
                }
            }
        }

        private string GetFileDirectories(string address)
        {
            var startIndex = address.IndexOf("://", StringComparison.Ordinal);
            var index = address.LastIndexOf('/');
            return address.Substring(startIndex + 3, index - startIndex - 2);
        }


        private string GetFileName(string address)
        {
            var index = Math.Max(address.LastIndexOf('/'), address.LastIndexOf(':'));
            return address.Substring(index + 1, address.Length - index - 1);
        }

        private struct Node
        {
            public string Path;
            public int Level;
        }
    }
}
