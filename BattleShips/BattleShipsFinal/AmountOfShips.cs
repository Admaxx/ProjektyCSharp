using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BattleShipsFinal
{
    class AmountOfShips : CreateShips
    {
        internal int Amount()
        {
            var Amount = 0;
            foreach (var Model in Model())
                Amount += Model.Counter;

            return Amount;
        }
    }
}
