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
        ClassGameLogic logic;
        public XO()
        {
            InitializeComponent();

            button1.Tag = 0;
            button2.Tag = 1;
            button3.Tag = 2;
            button4.Tag = 3;
            button5.Tag = 4;
            button6.Tag = 5;
            button7.Tag = 6;
            button8.Tag = 7;
            button9.Tag = 8;

            logic = new ClassGameLogic();
        }

        private string figureU = "X";
        private string figureC = "O";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {/*
            figureU = "X";
            figureC = "O";
            
            radioButton2.Enabled = false;
            label1.Text = "Выбран Крестик!";*/
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {/*
            figureU = "O";
            figureC = "X";
            radioButton1.Enabled = false;
            
            label1.Text = "Выбран Нолик!";*/
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            /*if (radioButton1.Checked == true || radioButton2.Checked == true)
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
            }*/
            var field = logic.GetField();
            for (int i = 0; i < field.Length; ++i)
            {
                var button = ((Button)Controls.Find("button" + (i + 1), false)[0]);
                button.Enabled = true;
            }
            logic.Start();
            Reload(logic.GetState(), false);
        }
        
        private void Clear_Click(object sender, EventArgs e)
        {/*
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            for (int i = 0; i < buttons.Length; ++i)
            {
                buttons[i].Enabled = false;
                buttons[i].Text = "";
            }
            label1.Text = null;
            */
        }

        private void button_Click(object sender, EventArgs e)
        {
            Reload(logic.Step(Convert.ToInt32(((Button)sender).Tag), FieldState.Field_figureU), true);
        }

        private void Reload(GameState state, bool compStep)
        {
            var field = logic.GetField();
            for (int i = 0; i < field.Length; ++i)
            {
                var button = ((Button)Controls.Find("button" + (i + 1), false)[0]);
                button.Text = field[i] == FieldState.Field_figureC ? figureC : field[i] == FieldState.Field_figureU ? figureU : "";
            }

            switch (state)
            {
                case GameState.NotStart:
                    label1.Text = "Игра не началась!";
                    break;
                case GameState.NoWin:
                    label1.Text = "Ничья!";
                    break;
                case GameState.figureCWin:
                    label1.Text = "Вы проиграли!";
                    break;
                case GameState.figureUWin:
                    label1.Text = "Вы выиграли!";
                    break;
                case GameState.InProgress:
                    label1.Text = "Игра в процессе!";
                    if (compStep)
                    {
                        Reload(logic.Step(CompProgress(logic.GetField()), FieldState.Field_figureC), false); 
                    }
                    break;
            }
        }

        private int CompProgress(FieldState[] fields)
        {
            /*
            if (fields[new Random().Next(0, fields.Length)] == FieldState.Empty)
            {
                fields[new Random().Next(0, fields.Length)] = figureC;
                return i;
            }*/
            
                for (int i = 0; i < fields.Length; ++i)
                {
                    if (fields[i] == FieldState.Empty)
                    {
                        
                        return i;
                    }
                }
                return -1;
            
        }       
    }
}
