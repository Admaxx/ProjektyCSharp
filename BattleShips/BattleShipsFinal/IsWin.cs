using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BattleShipsFinal
{
    class IsWin 
    {
        internal bool WinShip(int AmountOfShips, int ActualHitsShips)
        {
            MessageBox.Show($"{AmountOfShips}, {ActualHitsShips}");
            return AmountOfShips == ActualHitsShips;
        }

    }
}
