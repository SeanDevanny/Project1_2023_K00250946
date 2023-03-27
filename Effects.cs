using Lab4__2023_K00250946;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_2023_K00250946
{
    public partial class Form1 : Form
    {
        public void UpdatePodcastList() 
        {
            podcastsListBox.Items.Clear();

            if (!Podcasts.Keys.Any())
            {
                return;
            }

            foreach (string url in Podcasts.Keys) 
            {
                podcastsListBox.Items.Add(Podcasts[url].Title);
            }
        }

        public void UpdateEpisodeList(RSSFeed podcast) 
        {
            episodesListBox.Items.Clear();

            if (!podcast.Episodes.Any())
            {
                return;
            }

            foreach (RSSItem episode in podcast.Episodes) 
            {
                episodesListBox.Items.Add(episode.Title);
            }
        }

        public void UpdateDescriptionBox(string input) 
        {
            int index = input.IndexOf("<br");

            if (index != -1)
            {
                input = input.Substring(0, index);
            }

            descriptionTextBox.Text = input;
        }
    }
}
