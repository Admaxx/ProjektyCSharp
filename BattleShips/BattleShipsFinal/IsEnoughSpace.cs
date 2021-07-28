using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BattleShipsFinal
{
    class IsEnoughSpace : AllDatas
    {
        internal int BoardSize { get; }
        public List<StartModel> ShipStart { get; }
        public ShipModels ShipModels { get; }
        public List<string> UsedSpace { get; }
        IsShipPlacedCorr Ship;
        public List<string> ShipPlaces { get; }

        internal List<string> UsedPlace { get; }

        public IsEnoughSpace(int size, ShipModels Models, List<StartModel> Start, List<string> Used, List<string> Ship)
        {
            BoardSize = size;
            ShipStart = Start;
            ShipModels = Models;
            UsedSpace = Used;
            ShipPlaces = Ship;
        }
        internal bool Check()
        { 
            Ship = new IsShipPlacedCorr(BoardSize, ShipModels, ShipStart, UsedSpace, ShipPlaces);
            if (ShipStart[0].Height
                + ShipModels.Length
                <= BoardSize - 1) 
            {
                return Ship.IsCorr(ShipStart[0].Height, ShipStart[0].Height
                + ShipModels.Length, ShipStart[0].Width);            }
            else
                return false;
        }
    }
}
