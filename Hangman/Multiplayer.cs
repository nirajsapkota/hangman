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
    public partial class Multiplayer : Form
    {
        // Global Variables
        List<Label> labels = new List<Label>();
        int wordLength = 0;
        int guesses = Properties.Settings.Default.diff;
        public string storedWord = string.Empty;
        public string hint = string.Empty;
        int z;
        int keys;
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        private bool mp = true;
        private bool sp = false;

        public Multiplayer(string storedWord, string hint)
        {
            InitializeComponent();
            this.storedWord = storedWord;
            this.hint = hint;
        }

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

        // Minimize the applcation
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

        // Load multiplayer capabilities
        private void Multiplayer_Load(object sender, EventArgs e)
        {
            // Define startup values
            wordLength = storedWord.Length;
            storedWord = storedWord.ToLower();

            if (hint == string.Empty) {
                label5.Text = "Not specified.";
                label5.AutoSize = true;
            }
            else {
                label5.Text = hint;
                label5.AutoSize = true;
            }

            // Set labels
            lblremguess.Text = Convert.ToString(Properties.Settings.Default.diff);


            // Create the labels
            createLabels();



        }

        // Dynamically create the labels depending on the word length
        private void createLabels()
        {
            // Clear the panel
            flowLayoutPanel1.Controls.Clear();

            flowLayoutPanel1.AutoSize = true;

            // For each letter in the word create a label
            for (z = 0; z < storedWord.Length; z++)
            {
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

        // Detect for keypresses
        private void Multiplayer_KeyDown(object sender, KeyEventArgs e)
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
                    MultiplayerUtilities newGame = new MultiplayerUtilities();
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
            }

            else if (!storedWord.Contains(ch.ToLower()))
            {
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

                        Lose myNewMessageBoxInstance = new Lose(storedWord, mp, sp);
                        DialogResult result = myNewMessageBoxInstance.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            // Create a new instance of the game
                            MultiplayerUtilities newGame = new MultiplayerUtilities();
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
    }
}
