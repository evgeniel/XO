using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    //Возможные состояние игры
    public enum GameState
    {
        NotStart, // Игра не началась
        InProgress, // В процессе
        figureUWin, // Юзер выйграл
        figureCWin, // Комп выиграл
        NoWin // Ничья
    }
}
