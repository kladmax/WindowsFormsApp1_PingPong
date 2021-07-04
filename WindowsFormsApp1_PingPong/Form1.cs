using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1_PingPong
{
    public partial class Form1 : Form
    {

        private int speed_vertical = 1;
        private int speed_hor = 1;
        private int score = 0;

        public Form1()
        {
            InitializeComponent();

            timer.Enabled = true;

            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            this.Bounds = Screen.PrimaryScreen.Bounds;

            gamePanel.Top = background.Bottom - (background.Bottom / 10);


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gamePanel.Left = Cursor.Position.X - (gamePanel.Width / 2);

            gameBall.Left += speed_hor;
            gameBall.Top += speed_vertical;

            if (gameBall.Left <= background.Left)
                speed_hor *= -1;

            if (gameBall.Right >= background.Right)
                speed_hor *= -1;

            if (gameBall.Top <= background.Top)
                speed_vertical *= -1;

            if (gameBall.Bottom >= background.Bottom)
                timer.Enabled = false;

            if (gameBall.Bottom >= gamePanel.Top && gameBall.Bottom <= gamePanel.Bottom
                && gameBall.Left >= gamePanel.Left && gameBall.Right <= gamePanel.Right)
            {
                speed_hor += 1;
                speed_vertical += 1;
                speed_vertical *= -1;
                score += 1;
            }
        }
    }
}
 