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

        public string figureU = "X";

        public string figureC = "O";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StartGame_Click(object sender, EventArgs e)
        {            
            logic.Start();
            Reload(logic.GetState(), false);
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                Reload(logic.Step(Convert.ToInt32(((Button)sender).Tag), FieldState.Field_figureU), true);
                errorlabel2.Text = "";
            }
            catch (XOException ex)
            {
                errorlabel2.Text = string.Format("Ячейка {0} {1} занята", ex.row, ex.col);
            }
            catch (Exception ex)
            {
                errorlabel2.Text = ex.Message;
            }
            finally
            {
                int x;
                Int32.TryParse(label2.Text, out x);
                label2.Text = (x + 1).ToString();
            }
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
                    //label1.Text = "Игра не началась!";
                    //break;
                    throw new Exception("Игра не началась!");
                case GameState.NoWin:
                    label1.Text = "Ничья!";
                    logic.SaveStat();
                    break;
                case GameState.figureCWin:
                    label1.Text = "Вы проиграли!";
                    logic.SaveStat();
                    break;
                case GameState.figureUWin:
                    label1.Text = "Вы выиграли!";
                    logic.SaveStat();
                    break;
                case GameState.InProgress:
                    label1.Text = "Игра в процессе!";
                    logic.stepCounter++;
                    if (compStep)
                    {
                        Reload(logic.Step(CompProgress(logic.GetField()), FieldState.Field_figureC), false); 
                    }
                    break;
            }
        }

        private int CompProgress(FieldState[] fields)
        {
            if (fields[new Random().Next(0, fields.Length)] == FieldState.Empty)
            {
                fields[new Random().Next(0, fields.Length)] = FieldState.Field_figureC;
                return new Random().Next(0, fields.Length);
            }
            else
            {
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

        private void button10_Click(object sender, EventArgs e)
        {
            var data = Serializer.GetData("stats.json");

            var statsForm = new statsForm();

            statsForm.dataGridView1.DataSource = data;
            statsForm.Show();
        }       
    }
}
