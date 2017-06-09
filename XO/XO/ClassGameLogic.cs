using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    // Класс, храняищий информацию по полю
    class ClassGameLogic
    {
        private List<FieldState> fields; //Поле

        private int size = 3; //Размерность поля

        private GameState state; // статус игры

        public int stepCounter; // количество ходов

        public ClassGameLogic() // Конструктор в котором происходит инициализация полей
        {
            state = GameState.NotStart;
            stepCounter = 0;
            fields = new List<FieldState>();
            // заплоним список пустыми ячейками, в зависимости от размерности поля, 3*3
            for (int i = 0; i < size * size; ++i)
            {
                fields.Add(FieldState.Empty);
            }
        }
        
        
        public void Start() // Начало игры все поля делаем пустыми
        {
            
            for (int i = 0; i < fields.Count; ++i)
            {
                fields[i] = FieldState.Empty;
            }
            state = GameState.InProgress;
            stepCounter = 0;
        }

        public FieldState[] GetField() // возвращение в виде массива
        {
            FieldState[] array = new FieldState[fields.Count];
            fields.CopyTo(array);
            return array;
        }

        public GameState Step(int index, FieldState field) //Ход одного из игроков
        {
            if (state != GameState.InProgress)
            {
                return state;
            }

            if (index > -1 && index < fields.Count)
            {
                if (fields[index] != FieldState.Empty)
                {
                    //throw new System.Exception("Ячейка занята!");
                    throw new XOException()
                    {
                        col = index % 3 + 1,
                        row = index / 3 + 1
                    };
                }
                fields[index] = field;
                if (!CheckGame() && !ChekEmptyButton())
                {
                    state = GameState.NoWin;
                }
            }
            return state;
        }

        public GameState GetState() //получил состояние игры
        {

            return state;
        }

        private bool CheckGame() //логика проверки полей
        {
            //первая строка
            if (fields[0] == fields[1] && fields[1] == fields[2] && fields[0] != FieldState.Empty)
            {
                state = (fields[0] == FieldState.Field_figureC) ? GameState.figureCWin : GameState.figureUWin;
                return true;
            }
            //вторая строка
            if (fields[3] == fields[4] && fields[4] == fields[5] && fields[3] != FieldState.Empty)
            {
                state = (fields[3] == FieldState.Field_figureC) ? GameState.figureCWin : GameState.figureUWin;
                return true;
            }
            //тертья строка
            if (fields[6] == fields[7] && fields[7] == fields[8] && fields[6] != FieldState.Empty)
            {
                state = (fields[6] == FieldState.Field_figureC) ? GameState.figureCWin : GameState.figureUWin;
                return true;
            }
            //первый столбец
            if (fields[0] == fields[3] && fields[3] == fields[6] && fields[0] != FieldState.Empty)
            {
                state = (fields[0] == FieldState.Field_figureC) ? GameState.figureCWin : GameState.figureUWin;
                return true;
            }
            //второй столбец
            if (fields[1] == fields[4] && fields[4] == fields[7] && fields[1] != FieldState.Empty)
            {
                state = (fields[1] == FieldState.Field_figureC) ? GameState.figureCWin : GameState.figureUWin;
                return true;
            }
            //третий столбец
            if (fields[2] == fields[5] && fields[5] == fields[8] && fields[2] != FieldState.Empty)
            {
                state = (fields[2] == FieldState.Field_figureC) ? GameState.figureCWin : GameState.figureUWin;
                return true;
            }
            //первая диагональ
            if (fields[2] == fields[4] && fields[4] == fields[6] && fields[2] != FieldState.Empty)
            {
                state = (fields[2] == FieldState.Field_figureC) ? GameState.figureCWin : GameState.figureUWin;
                return true;
            }
            //вторая диагональ
            if (fields[0] == fields[4] && fields[4] == fields[8] && fields[0] != FieldState.Empty)
            {
                state = (fields[0] == FieldState.Field_figureC) ? GameState.figureCWin : GameState.figureUWin;
                return true;
            }
            return false;
        }

        private bool ChekEmptyButton() //проверка на пустые поля
        {
            for (int i = 0; i < fields.Count; ++i)
            {
                if (fields[i] == FieldState.Empty)
                {
                    return true;
                }
            }
            return false;
        }

        public void SaveStat() //сохранение статистики
        {
            try
            {
                var data = new List<Statistcs>();
                string filePath = "stats.json";

                data = Serializer.GetData(filePath);

                data.Add(new Statistcs()
                {
                    Date = DateTime.Now,
                    Result = state,
                    StepCounter = stepCounter,
                    UserFirst = true
                });

                
                Serializer.SetData(filePath, data);
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
