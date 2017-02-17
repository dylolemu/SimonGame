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
    public partial class newGame : UserControl
    {
        public newGame()
        {
            InitializeComponent();
            start = false;
            Form1.pattern.Clear();
            Focus();
        }

        bool start;


        private void newGame_KeyUp(object sender, KeyEventArgs e)
        {
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (start == false)
            {
                this.BackgroundImage = Properties.Resources.gameStart2;
                Refresh();
                Thread.Sleep(200);
                this.BackgroundImage = Properties.Resources.gameStart1;
                Refresh();
                Thread.Sleep(200);
            }
        }

        private void newGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (start == false)
            {
                if (e.KeyCode == Keys.Escape) { Application.Exit(); }

                if (e.KeyCode == Keys.Down)
                {
                    Form f = this.FindForm();
                    f.Controls.Remove(this);

                    mainGame ss = new mainGame();

                    // Add the User Control to the Form
                    f.Controls.Add(ss);

                    start = true;
                }
            }
        }
    }
}
