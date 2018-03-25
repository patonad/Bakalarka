﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReklamnyModul
{
    public partial class Ovladac : Form
    {
        Zobrazovac z;

        int pocetVidei = 0;
        public Ovladac()
        {


            InitializeComponent();
            vyberSubor();

        }

        private void Ovladac_Load(object sender, EventArgs e)
        {

        }

        private void Ovladac_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (z != null)
            {
                z.Close();
            }
        }

        private void StartVideo_Click(object sender, EventArgs e)
        {
            if (jeZakliknuetVideo())
            {
                z = new Zobrazovac();
                AxWMPLib.AxWindowsMediaPlayer prehravac = z.wMP();
                WMPLib.IWMPPlaylist playlist = prehravac.playlistCollection.newPlaylist("myplaylist");
                WMPLib.IWMPMedia media;
                for (int i = 0; i < pocetVidei; i++)
                {
                    if (cLBZoznamReklam.GetItemCheckState(i) == CheckState.Checked)
                    {
                        string s = "..\\..\\Reklamy\\" + cLBZoznamReklam.Items[i].ToString();
                        //media = prehravac.newMedia(s);
                        media = prehravac.newMedia(cLBZoznamReklam.Items[i].ToString());
                        playlist.appendItem(media);
                    }
                }

                z.Show();
                prehravac.currentPlaylist = playlist;
                prehravac.Ctlcontrols.play();
                prehravac.stretchToFit = true;
            }
            else
            {
                MessageBox.Show("Nevybral si žiadne video");
            }


        }



        private bool jeZakliknuetVideo()
        {
            for (int i = 0; i < pocetVidei; i++)
            {
                if (cLBZoznamReklam.GetItemCheckState(i) == CheckState.Checked)
                {
                    return true;
                }
            }
            return false;
        }
        private void vyberSubor()
        {
            DirectoryInfo d = new DirectoryInfo("..\\..\\Reklamy");
            string[] extensions = new[] { ".avi", ".mp4" };
            FileInfo[] files =
                d.GetFiles()
                     .Where(f => extensions.Contains(f.Extension.ToLower()))
                     .ToArray(); ;

            int poc = 0;
            foreach (FileInfo subor in files)
            {
                cLBZoznamReklam.Items.Add(subor.FullName, true);


                poc++;
            }
            pocetVidei = poc;

        }

        private void StopVideo_Click(object sender, EventArgs e)
        {
            if (z != null)
            {
                z.wMP().Ctlcontrols.stop();
                z.Close();
                this.Close();
            }
        }

        private void pauseVideo_Click(object sender, EventArgs e)
        {
            if (z != null)
            {
                AxWMPLib.AxWindowsMediaPlayer prehravac = z.wMP();

                if (prehravac.playState == WMPLib.WMPPlayState.wmppsPaused)
                {
                    prehravac.Ctlcontrols.play();
                    pauseVideo.Text = "Pause";
                }
                else
                {
                    prehravac.Ctlcontrols.pause();
                    pauseVideo.Text = "Play";
                }


            }
        }
    }

}
