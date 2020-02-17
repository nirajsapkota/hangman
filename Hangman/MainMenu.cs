using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        #region draggableHeader
        //Global variables;
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

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

        private void btnSP_MouseHover(object sender, EventArgs e)
        {
            pnlActiveSP.BackColor = Color.FromArgb(195, 43, 56);
            btnSP.BackColor = Color.FromArgb(195, 43, 56);
        }
        #endregion

        #region SPColour
        private void btnSP_MouseEnter(object sender, EventArgs e)
        {
            pnlActiveSP.BackColor = Color.FromArgb(195, 43, 56);
            btnSP.BackColor = Color.FromArgb(195, 43, 56);
        }

        private void btnSP_MouseLeave(object sender, EventArgs e)
        {
            pnlActiveSP.BackColor = Color.FromArgb(37, 37, 38);
            btnSP.BackColor = Color.FromArgb(37, 37, 38);
        }
        #endregion

        #region MPColour
        private void btnMP_MouseEnter(object sender, EventArgs e)
        {
            pnlActiveMP.BackColor = Color.FromArgb(195, 43, 56);
            btnMP.BackColor = Color.FromArgb(195, 43, 56);
        }

        private void btnMP_MouseLeave(object sender, EventArgs e)
        {
            pnlActiveMP.BackColor = Color.FromArgb(37, 37, 38);
            btnMP.BackColor = Color.FromArgb(37, 37, 38);
        }
        #endregion

        #region SettingsColour
        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            pnlActiveSettings.BackColor = Color.FromArgb(195, 43, 56);
            btnSettings.BackColor = Color.FromArgb(195, 43, 56);
        }

        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            pnlActiveSettings.BackColor = Color.FromArgb(37, 37, 38);
            btnSettings.BackColor = Color.FromArgb(37, 37, 38);
        }
        #endregion

        #region ExitColor
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            pnlActiveExit.BackColor = Color.FromArgb(195, 43, 56);
            btnExit.BackColor = Color.FromArgb(195, 43, 56);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            pnlActiveExit.BackColor = Color.FromArgb(37, 37, 38);
            btnExit.BackColor = Color.FromArgb(37, 37, 38);
        }
        #endregion

        private void Exit_Click(object sender, EventArgs e)
        {
            // The user wants to exit the application. Close everything down.
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // The user wants to exit the application. Close everything down.
            Application.Exit();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }


        private void btnSP_Click(object sender, EventArgs e)
        {
                Singleplayer SP = new Hangman.Singleplayer();
                SP.Show();

        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            MultiplayerUtilities MU = new MultiplayerUtilities();
            MU.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();

            Hide();
        }

        private bool CheckForConnection() {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            label1.Hide();
        }
    }
}
