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
using System.Media;


namespace SimonGame
{
    public partial class mainGame : UserControl
    {
        public mainGame()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            compPlay = true;
        }
        //variable to count player clicks 
        int j;

        //computer turn variable
        bool compPlay;

        //different sounds
        SoundPlayer yellow = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer red = new SoundPlayer(Properties.Resources.red);
        SoundPlayer green = new SoundPlayer(Properties.Resources.green);
        SoundPlayer blue = new SoundPlayer(Properties.Resources.blue);

        private void mainGame_Load(object sender, EventArgs e)
        {
            //adds one random number to the list
            Form1.pattern.Add(Form1.rand.Next(1, 5));
            if (compPlay == true)
            {
                //plays computer turn method
                new Thread(computerTurn).Start();
            }
            //sets player choice count to 0
            j = 0;
            this.Focus();
        }

        public void computerTurn()
        {
            Thread.Sleep(600);

            if (compPlay == true)
            {
                //checks list items one by one
                for (int i = 0; i < Form1.pattern.Count; i++)
                {
                    //changes bacground for correct color choice and plays corresponding sound
                    if (Form1.pattern[i] == 1) { colors(Properties.Resources.buttOn1, yellow); }
                    if (Form1.pattern[i] == 2) { colors(Properties.Resources.buttOn2, red); }
                    if (Form1.pattern[i] == 3) { colors(Properties.Resources.buttOn3, green); }
                    if (Form1.pattern[i] == 4) { colors(Properties.Resources.buttOn4, blue); }
                    Thread.Sleep(250);

                    //changes background to all buttons off
                    this.BackgroundImage = Properties.Resources.buttOffAll;
                    Thread.Sleep(250);
                }
            }
            //computer turn is done
            compPlay = false;
        }

        //plays approprite sound and changes background to corresponding image
        public void colors(System.Drawing.Image x, SoundPlayer y)
        {
            this.BackgroundImage = x;
            y.Play();
        }

        public void playerTurn(int choice)
        {
            //if choice is correct then go to the next list item
            if (choice == Form1.pattern[j]) { j++; }

            //if it is incorrect
            else
            {
                Form f = this.FindForm();
                f.Controls.Remove(this);

                gameOverScreen gg = new gameOverScreen();

                // Add the User Control to the Form
                f.Controls.Add(gg);
            }

            //if you have completed the entire list choices correctly
            if (j == Form1.pattern.Count)
            {
                compPlay = true;

                //add another item to the list pattern
                Form1.pattern.Add(Form1.rand.Next(1, 5));
                label1.Text = Form1.pattern.Count().ToString("00") + "";

                new Thread(computerTurn).Start();
                j = 0;
            }

        }

        private void mainGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (compPlay == false)
            {
                //turns approprite light on when corresponding button is clicked
                if (e.KeyCode == Keys.Up)
                {
                    colors(Properties.Resources.buttOn1, yellow);
                    playerTurn(1);
                }
                if (e.KeyCode == Keys.Down)
                {
                    colors(Properties.Resources.buttOn3, green);
                    playerTurn(3);
                }
                if (e.KeyCode == Keys.Left)
                {
                    colors(Properties.Resources.buttOn4, blue);
                    playerTurn(4);
                }
                if (e.KeyCode == Keys.Right)
                {
                    colors(Properties.Resources.buttOn2, red);
                    playerTurn(2);
                }
            }
        }

        private void mainGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { Application.Exit(); }

            //once button is released all lights turn off
            this.BackgroundImage = Properties.Resources.buttOffAll;
        }
    }
}

