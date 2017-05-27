using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class XO : Form
    {
        Button[] buttons;
        public XO()
        {
            InitializeComponent();

            buttons = new Button[]
            {
                button1, button2, button3, button4, button5, button6, button7, button8, button9,
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string figureU;
        private string figureC;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            figureU = "X";
            figureC = "O";
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            label1.Text = "Выбран Крестик!";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            figureU = "O";
            figureC = "X";
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            label1.Text = "Выбран Нолик!";
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            if (radioButton1.Enabled == false && radioButton2.Enabled == false)
            {
                for (int i = 0; i < buttons.Length; ++i)
                {
                    buttons[i].Enabled = true;
                    buttons[i].Text = "";
                }
                label1.Text = "Игра началась!";
            } 
            else
            {
                label1.Text = "Выберите фигуру!";
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Length; ++i)
            {
                buttons[i].Enabled = false;
                buttons[i].Text = "";
            }
            label1.Text = null;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            ((Button)sender).Text = figureU;
            if (CheckGame())
            {
                label1.Text = "Вы победили!";
                FinishGame();
                return;
            }
            if (ChekEmptyButton())
            {
                CompProgress();
                if (CheckGame())
                {
                    label1.Text = "Вы проиграли!";
                    FinishGame();
                }
                else if (!ChekEmptyButton())
                {
                    label1.Text = "Ничья!";
                    FinishGame();
                }
            }
            else
            {
                label1.Text = "Ничья!";
                FinishGame();
            }
        }

        private bool CheckGame()
        {
            if (button1.Text == figureU && button2.Text == figureU && button3.Text == figureU) { return true; }
            if (button4.Text == figureU && button5.Text == figureU && button6.Text == figureU) { return true; }
            if (button7.Text == figureU && button8.Text == figureU && button9.Text == figureU) { return true; }
            if (button1.Text == figureU && button4.Text == figureU && button7.Text == figureU) { return true; }
            if (button2.Text == figureU && button5.Text == figureU && button8.Text == figureU) { return true; }
            if (button3.Text == figureU && button6.Text == figureU && button9.Text == figureU) { return true; }
            if (button1.Text == figureU && button5.Text == figureU && button9.Text == figureU) { return true; }
            if (button3.Text == figureU && button5.Text == figureU && button7.Text == figureU) { return true; }

            if (button1.Text == figureC && button2.Text == figureC && button3.Text == figureC) { return true; }
            if (button4.Text == figureC && button5.Text == figureC && button6.Text == figureC) { return true; }
            if (button7.Text == figureC && button8.Text == figureC && button9.Text == figureC) { return true; }
            if (button1.Text == figureC && button4.Text == figureC && button7.Text == figureC) { return true; }
            if (button2.Text == figureC && button5.Text == figureC && button8.Text == figureC) { return true; }
            if (button3.Text == figureC && button6.Text == figureC && button9.Text == figureC) { return true; }
            if (button1.Text == figureC && button5.Text == figureC && button9.Text == figureC) { return true; }
            if (button3.Text == figureC && button5.Text == figureC && button7.Text == figureC) { return true; }
            return false;
        }

        private void FinishGame()
        {
            for (int i = 0; i < buttons.Length; ++i)
            {
                buttons[i].Enabled = false;
            }
        }

        private void CompProgress()
        {

            if (buttons[new Random().Next(0, buttons.Length)].Text == "")
            {
                buttons[new Random().Next(0, buttons.Length)].Text = figureC;
                return;
            }
            else
            {
                for (int i = 0; i < buttons.Length; ++i)
                {
                    if (buttons[i].Text == "")
                    {
                        buttons[i].Text = figureC;
                        return;
                    }
                }
            }
        }

        private bool ChekEmptyButton()
        {
            for (int i = 0; i < buttons.Length; ++i)
            {
                if (buttons[i].Text == "")
                {
                    return true;
                }
            }
            return false;
        }

               
        
    }
}
