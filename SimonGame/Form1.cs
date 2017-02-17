using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;


namespace SimonGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<int> pattern = new List<int>();
        public static Random rand = new Random();
        public static bool gameDone;

        private void Form1_Load(object sender, EventArgs e)
        {

            // Create an instance of the MainScreen
            newGame ng = new newGame();

            // Add the User Control to the Form
            this.Controls.Add(ng);

            ng.Location = new Point((this.Width - ng.Width) / 2, (this.Height - ng.Height) / 2);

        }

    }
}
