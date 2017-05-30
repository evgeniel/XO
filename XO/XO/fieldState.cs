using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    //Перечисление для обозначения состояние поля
    enum FieldState
    {
        Empty, //Поле пустое
        Field_figureU, // В поле стоит фигура юзера
        Field_figureC // В поле стоит фигура компа
    }
}
