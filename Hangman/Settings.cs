using System;
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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        // Close the application
        private void Exit_Click(object sender, EventArgs e)
        {
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

        private void btnSP_Click(object sender, EventArgs e)
        {
            label2.ForeColor = Color.LightGreen;
            label2.Text = "All new settings have been successfully saved and applied!";
            Properties.Settings.Default.diff = 11;
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(255, 191, 0);
            label2.Text = "All new settings have been successfully saved and applied!";
            Properties.Settings.Default.diff = 7;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            label2.ForeColor = Color.LightCoral;
            label2.Text = "All new settings have been successfully saved and applied!";
            Properties.Settings.Default.diff = 3;
        }

        private void btnSP_MouseEnter(object sender, EventArgs e)
        {
            pnlActiveSP.BackColor = Color.LightGreen;
            btnSP.BackColor = Color.LightGreen;
        }

        private void btnSP_MouseLeave(object sender, EventArgs e)
        {
            pnlActiveSP.BackColor = Color.FromArgb(37, 37, 38);
            btnSP.BackColor = Color.FromArgb(37, 37, 38);
        }

        private void btnMP_MouseEnter(object sender, EventArgs e)
        {
            pnlActiveMP.BackColor = Color.FromArgb(255, 191, 0);
            btnMP.BackColor = Color.FromArgb(255, 191, 0);
        }

        private void btnMP_MouseLeave(object sender, EventArgs e)
        {
            pnlActiveMP.BackColor = Color.FromArgb(37, 37, 38);
            btnMP.BackColor = Color.FromArgb(37, 37, 38);
        }

        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            pnlActiveSettings.BackColor = Color.LightCoral;
            btnSettings.BackColor = Color.LightCoral;
        }

        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            pnlActiveSettings.BackColor = Color.FromArgb(37, 37, 38);
            btnSettings.BackColor = Color.FromArgb(37, 37, 38);
        }

    }
}
