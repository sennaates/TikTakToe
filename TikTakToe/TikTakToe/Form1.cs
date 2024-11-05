using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TikTakToe
{
    public partial class Form1 : Form
    {

        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int CPUWinCount = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void CPUmove(object sender, EventArgs e)
        {

            List<Button> buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            if (buttons.Count > 0)
            {
                int index;
                while (true)
                {
                    index = random.Next(buttons.Count);
                    if (String.IsNullOrEmpty(buttons[index].Text))
                    {
                        break;
                    }
                }

                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.Honeydew;
                buttons.RemoveAt(index);
                CheckGame();
                CPUTimer.Stop();

            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;

            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.PaleVioletRed;

            CheckGame();
            CPUTimer.Start();

        }

        private void CheckGame()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
               )
            {
                CPUTimer.Stop();
                MessageBox.Show("Kazandın!", "Kazanan");
                playerWinCount++;
                RestartGame();
            }


            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                             || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                             || button7.Text == "O" && button9.Text == "O" && button8.Text == "0"
                             || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                             || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                             || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                             || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                             || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                            )
            {
                CPUTimer.Stop();
                MessageBox.Show("Bilgisayar kazandı", "Kazanan");
                playerWinCount++;
                RestartGame();
            }


            void RestartGame()
            {
                List<Button> buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

                foreach (Button x in buttons)
                {
                    x.Enabled = true;
                    x.Text = "";
                    x.BackColor = DefaultBackColor;
                }
            }
        }
    }
}
