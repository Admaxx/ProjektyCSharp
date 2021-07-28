using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
namespace BattleShipsFinal
{
    class BattleBegin : PlayerChoose
    {
        internal string begin(List<string> ShipCoords)
        {
            string IsStrike = Choose();
            //MessageBox.Show(ShipCoords.Count().ToString());
            if (ShipCoords.Any(item => item.Contains(IsStrike)))
                if (!Strikes.Any(item => item.Contains(IsStrike)))
                {
                    Strikes.Add(IsStrike);
                    ShipCoords.Remove(IsStrike);
                    return IsStrike;
                }

            return string.Empty;
        }

    }
}
