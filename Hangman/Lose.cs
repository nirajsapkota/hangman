﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Lose : Form
    {
        private string storedWord;
        private bool mp;
        private bool sp;

        public Lose(string storedWord, bool mp, bool sp)
        {
            InitializeComponent();
            this.storedWord = storedWord;
            this.mp = mp;
            this.sp = sp;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            // Take the player back to the main menu

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            // Reset the game
        }

        #region yesColour
        private void btnYes_MouseEnter(object sender, EventArgs e)
        {
            pnlYes.BackColor = Color.FromArgb(195, 43, 56);
            btnYes.BackColor = Color.FromArgb(195, 43, 56);
        }

        private void btnYes_MouseLeave(object sender, EventArgs e)
        {
            pnlYes.BackColor = Color.FromArgb(37, 37, 38);
            btnYes.BackColor = Color.FromArgb(37, 37, 38);
        }
        #endregion

        #region noColour
        private void btnNo_MouseEnter(object sender, EventArgs e)
        {
            pnlNo.BackColor = Color.FromArgb(195, 43, 56);
            btnNo.BackColor = Color.FromArgb(195, 43, 56);
        }

        private void btnNo_MouseLeave(object sender, EventArgs e)
        {
            pnlNo.BackColor = Color.FromArgb(37, 37, 38);
            btnNo.BackColor = Color.FromArgb(37, 37, 38);
        }
        #endregion

        private void Lose_Load(object sender, EventArgs e)
        {
            label3.Text = "The word was " + storedWord + ".";

            if (sp)
            {
                lblTitle.Text = "Singleplayer";
            }
            else if (mp)
            {
                lblTitle.Text = "Multiplayer";
            }
        }
    }
}
