using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonGame
{
    public partial class gameOverScreen : UserControl
    {
        public gameOverScreen()
        {
            InitializeComponent();
        }

        private void gameOverScreen_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.pattern.Count() + "";
            Focus();
        }

        private void gameOverScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            //close currents screen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            // Re-create newGame screen
            newGame ng = new newGame();

            // Add the User Control to the Form
            f.Controls.Add(ng);
        }
    }
}
