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
    public partial class MultiplayerUtilities : Form
    { 

        public MultiplayerUtilities()
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
        #endregion

        private void MultiplayerUtilities_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("They can't guess something that isn't there...");
            }
            else {
                string storedWord = textBox3.Text;
                string hint = textBox1.Text;

                Multiplayer MP = new Multiplayer(storedWord, hint);
                MP.Show();
                Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnYes_MouseEnter(object sender, EventArgs e)
        {
            btnYes.BackColor = Color.FromArgb(195, 43, 56);
        }

        private void btnYes_MouseLeave(object sender, EventArgs e)
        {
            btnYes.BackColor = Color.FromArgb(37, 37, 38);
        }
    }
}
