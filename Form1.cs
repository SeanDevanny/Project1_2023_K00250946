using Lab4__2023_K00250946;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project1_2023_K00250946
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //file manipulation
        internal LocalFile localFile = new LocalFile();
        internal ValidRSSfeed RSSLinks;
        private BinaryFormatter formatter = new BinaryFormatter();
        private Dictionary<string, RSSFeed> Podcasts = new Dictionary<string, RSSFeed>();
        //user input
        internal RSSFeed selectedPodcast = null;
        internal RSSItem selectedEpisode = null;
        //mediaplayer
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        //pause/unpause
        double currentposition = 0;
        RSSItem currentEpisode = null;


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                RSSLinks = ValidRSSfeed.BinaryDeserialise(localFile.filePath, formatter);
            }
            catch (Exception ex)
            {
                //will appear anytime data couldn't be parsed from the .bin file
                //this will always run upon the user's first launch of the program
                MessageBox.Show(ex.Message);
                RSSLinks = new ValidRSSfeed();
            }
            if (RSSLinks.urls.Any())
            {
                RSSFeed fed;
                foreach (string url in RSSLinks.urls)
                {
                    fed = new RSSFeed(url);
                    Podcasts.Add(url, fed);//indexing expesodes with their url
                }
                UpdatePodcastList();
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!Directory.Exists(localFile.folderPath))
            {
                Directory.CreateDirectory(localFile.folderPath);
                Console.WriteLine("Folder created successfully.");
            }
            if (RSSLinks != null) //if something goes wrong with the deserializer, don't try to serialize data
            {
                RSSLinks.BinarySerialise(localFile.filePath, formatter);
            }

            base.OnFormClosing(e);
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            if (selectedEpisode != null)
            {
                if(selectedEpisode != currentEpisode) 
                {
                    wplayer.URL = selectedEpisode.Link;
                    currentposition = 0;
                    currentEpisode = selectedEpisode;
                }
                wplayer.controls.currentPosition = currentposition;
                wplayer.controls.play();
                currentposition = 0; //so hitting play twice will restart the podcast
                episodeLabel.Text = "Now playing - " + selectedEpisode.Title;
            }
            else
            {
                MessageBox.Show("No podcast selected");
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            wplayer.controls.stop();
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            using (var popupForm = new PopupForm())
            {
                if (popupForm.ShowDialog() == DialogResult.OK)
                {
                    string url = popupForm.EnteredText;
                    // Use the entered text here

                    this.UseWaitCursor = true; //show that it's loading in feed
                    await Task.Run(() =>
                    {
                        RSSFeed fed = null;
                        try
                        {
                            fed = new RSSFeed(url);
                            Thread.Sleep(20000);
                        }
                        catch (Exception ex)
                        {

                        }
                        // Use Invoke method to update the label from a separate thread
                        Invoke((MethodInvoker)delegate
                        {
                            if (fed != null)
                            {
                                if (!RSSLinks.urls.Any(link => link.Equals(url)))
                                {
                                    Podcasts.Add(url, fed);
                                    RSSLinks.urls.Add(url);
                                }
                                else 
                                {
                                    //user probably wants an updated version of the podcast player if they've entered in the URL twice... so use the new feed
                                    Podcasts[url] = fed;
                                }
                                UpdatePodcastList();
                            }
                            else
                            {
                                MessageBox.Show("Invalid URL");
                            }
                            this.UseWaitCursor = false; //return cursor to normal
                        });
                    });
                }
            }
        }

        private void podcastsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = "";
            //this is done because selcting whitespace in listbox results in selected index being == to -1 which causes problems
            foreach (string viewItem in podcastsListBox.SelectedItems)
            {
                selected = viewItem;
            }

            if (string.IsNullOrEmpty(selected))
            {
                return;
            }

            selectedPodcast = Podcasts.Values.FirstOrDefault(p => p.Title == selected);
            UpdateEpisodeList(selectedPodcast);
            UpdateDescriptionBox(selectedPodcast.Description);
            titleLabel.Text = selectedPodcast.Title.Replace("\n", "").Replace("\r", "");
            podcastPictureBox.LoadAsync(selectedPodcast.Image);
        }

        private void episodesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = "";
            //this is done because selcting whitespace in listbox results in selected index being == to -1 which causes problems
            foreach (string viewItem in episodesListBox.SelectedItems)
            {
                selected = viewItem;
            }

            if (string.IsNullOrEmpty(selected))
            {
                MessageBox.Show("Podcast not found"); //should never occur
                return;
            }
            //selected podcast should always have a value here so no need to handle if it doesn't
            selectedEpisode = selectedPodcast.Episodes.FirstOrDefault(p => p.Title == selected);
            UpdateDescriptionBox(selectedEpisode.Description);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            wplayer.controls.pause();
            currentposition = wplayer.controls.currentPosition;
            
        }
    }
}
