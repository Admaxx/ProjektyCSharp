using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BattleShipsFinal
{
    class ShipLayout
    {
        internal int BoardSize { get; }
        public List<StartModel> ShipStart { get; }
        public ShipModels ShipModels { get; }
        public List<string> UsedSpace { get; }
        public List<string> ShipPlaces { get; }

        IsEnoughSpace space;
        public ShipLayout(int size, ShipModels Models, List<StartModel> Start, List<string> Used, List<string> Ship)
        {
            BoardSize = size;
            ShipStart = Start;
            ShipModels = Models;
            UsedSpace = Used;
            ShipPlaces = Ship;
        }

        

        internal bool Horizontally()
        {
            space = new IsEnoughSpace(BoardSize, ShipModels, ShipStart, UsedSpace, ShipPlaces);
            //MessageBox.Show($"{BoardSize}, {ShipStart[0].Name}{ShipStart[0].Height}{ShipStart[0].Width}");
            //MessageBox.Show(UsedSpace.Count.ToString() + "s");
            return space.Check();

        }
        

    }
}
