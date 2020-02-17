using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Hangman
{
    public partial class Singleplayer : Form
    {
        public Singleplayer()
        {
            InitializeComponent();
        }

        // Global Variables
        List<Label> labels = new List<Label>();
        int wordLength = 0;
        int guesses = Properties.Settings.Default.diff;
        public string storedWord = string.Empty;
        int keys = 0;
        int z;
        private bool sp = true;
        private bool mp = false;
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        #region draggableHeader
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
        #endregion

        // Close the application
        private void Exit_Click(object sender, EventArgs e)
        {
            // The user wants to exit the application. Close everything down.
            Application.Exit();
        }

        // Minimize the application
        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Return to the main menu
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();

            Hide();
        }

        // Load event for program
        private void Singleplayer_Load(object sender, EventArgs e)
        {
            // Set the stored word variable
            storedWord = GetRandomWord();
            wordLength = storedWord.Length;

            // Call createLabels;
            createLabels();

            // lblremguess
            lblremguess.Text = Convert.ToString(Properties.Settings.Default.diff);
        }

        // Get a random word from an online txt file
        string GetRandomWord() {
            WebClient wc = new WebClient();
            if (wc.Proxy != null)
                wc.Proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            string wordList = wc.DownloadString("https://raw.githubusercontent.com/Tom25/Hangman/master/wordlist.txt");
            string[] words = wordList.Split('\n');
            Random rng = new Random();
            return words[rng.Next(0, words.Length - 1)];
        }
        
        // Detect for the keypresses
        private void Singleplayer_KeyDown(object sender, KeyEventArgs e)
        {
            // Store the current key pressed
            string ch = ((Char)e.KeyCode).ToString();

            string[] pressedKey = new string[100];
            pressedKey[keys] = ch;
            keys++;

            foreach (var item in pressedKey)
            {
                lblGuessed.Text += item;
            }

            if (storedWord.Contains(ch.ToLower()))
            {
                // Replace the label with the character if correctly guessed
                char[] LS = storedWord.ToLower().ToCharArray();
                for (int i = 0; i < storedWord.Length; i++)
                {
                    if (LS[i] == Convert.ToChar(ch.ToLower()))
                    {
                        labels[i].Text = ch.ToString();
                    }

                }

                foreach (Label l in labels)
                    if (l.Text == "_") return;

                    Win myNewMessageBoxInstance = new Win(mp, sp);
                    DialogResult result = myNewMessageBoxInstance.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        // Create a new instance of the game
                        Singleplayer newGame = new Singleplayer();
                        newGame.Show();
                        Close();
                    }
                    else if (result == DialogResult.No) {
                        // send back to main screen
                        MainMenu menu = new Hangman.MainMenu();
                        menu.Show();
                        Close();
                    }
            }

            else if(!storedWord.Contains(ch.ToLower())) {
                guesses--;
                lblremguess.Text = Convert.ToString(guesses);

                // Change Image
                switch (guesses)
                {
                    case 6:
                        pictureBox2.Image = Properties.Resources._6;
                        break;
                    case 5:
                        pictureBox2.Image = Properties.Resources._5;
                        break;
                    case 4:
                        pictureBox2.Image = Properties.Resources._4;
                        break;
                    case 3:
                        pictureBox2.Image = Properties.Resources._3;
                        break;
                    case 2:
                        pictureBox2.Image = Properties.Resources._2;
                        break;
                    case 1:
                        pictureBox2.Image = Properties.Resources._1;
                        break;
                    case 0:
                        pictureBox2.Image = Properties.Resources._0;

                        Lose myNewMessageBoxInstance =  new Lose(storedWord, mp, sp);
                        DialogResult result = myNewMessageBoxInstance.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            // Create a new instance of the game
                            Singleplayer newGame = new Singleplayer();
                            newGame.Show();
                            Close();
                        }
                        else if (result == DialogResult.No)
                        {
                            // send back to main screen
                            MainMenu menu = new Hangman.MainMenu();
                            menu.Show();
                            Close();
                        }

                        break;
                }

            }
  
        }

        // Dynamically create the labels depending on the word length
        private void createLabels() {
            // Clear the panel
            flowLayoutPanel1.Controls.Clear();

            flowLayoutPanel1.AutoSize = true;

            // For each letter in the word create a label
            for (z = 0; z < storedWord.Length; z++) {
                labels.Add(new Label());
                labels[z].Name = z.ToString();
                labels[z].Parent = flowLayoutPanel1;
                labels[z].Text = "_";
                labels[z].ForeColor = Color.White;
                labels[z].AutoSize = true;
                labels[z].BringToFront();
                labels[z].CreateControl();

                flowLayoutPanel1.Controls.Add(labels[z]);
            }

        }
    }
}
