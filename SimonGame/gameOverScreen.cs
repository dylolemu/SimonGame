using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SimonGame
{
    public partial class gameOverScreen : UserControl
    {
        public gameOverScreen()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            gameOver = true;
        }

        bool gameOver;
        private void gameOverScreen_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.pattern.Count().ToString("00") + "";
            Focus();
        }

        private void gameOverScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.Space)
            {
                //close currents screen
                Form f = this.FindForm();
                f.Controls.Remove(this);

                // Re-create newGame screen
                newGame ng = new newGame();

                // Add the User Control to the Form
                f.Controls.Add(ng);

                ng.Location = new Point((f.Width - ng.Width) / 2, (f.Height - ng.Height) / 2);

                gameOver = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameOver == true)
            {
                //green button blinks on and off
                this.BackgroundImage = Properties.Resources.gameOver1;
                Refresh();
                Thread.Sleep(200);
                this.BackgroundImage = Properties.Resources.gameOver2;
                Refresh();
                Thread.Sleep(200);
            }
        }
    }
}
