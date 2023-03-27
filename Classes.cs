using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace Lab4__2023_K00250946
{
    internal class LocalFile
    {
        public string fileName { get; }
        public string folderName { get; }
        public string filePath { get; }
        public string folderPath { get; }
        public string Downloads { get; }
        internal LocalFile(string fileName = "data.bin", string folderName = "Podcast_Player_Application")
        {
            this.fileName = fileName;
            this.folderName = folderName;
            folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), folderName);
            filePath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), folderName), fileName);
            Downloads = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        }
    }

    [Serializable]
    public class ValidRSSfeed
    {
        public List<string> urls { get; set; }

        public ValidRSSfeed()
        {
            urls = new List<string>();
        }

        internal void BinarySerialise(string path, BinaryFormatter formatter)
        {
            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(outputStream, this);
            }
        }

        public static ValidRSSfeed BinaryDeserialise(string path, BinaryFormatter formatter)
        {
            using (FileStream inputStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return (ValidRSSfeed)formatter.Deserialize(inputStream);
            }
        }
    }

    public class RSSFeed
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<RSSItem> Episodes { get; set; }

        public RSSFeed(string url) 
        {
            Episodes = new List<RSSItem>();

            XDocument rssXml = XDocument.Load(url);
            XElement channel = rssXml.Element("rss").Element("channel");

            Title = channel.Element("title").Value;
            Link = channel.Element("link").Value;
            Description = channel.Element("description").Value;
            Image = channel.Element("image").Element("url").Value;

            foreach (XElement item in channel.Elements("item"))
            {
                var rssItem = new RSSItem();
                rssItem.Title = item.Element("title").Value;
                rssItem.Link = item.Element("enclosure").Attribute("url").Value;
                rssItem.Description = item.Element("description").Value;
                rssItem.PubDate = item.Element("pubDate").Value;
                Episodes.Add(rssItem);
            }
        }
    }

    public class RSSItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string PubDate { get; set; }
    }
}
