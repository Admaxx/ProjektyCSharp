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
        private bool ItsFits;

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
            //MessageBox.Show(ShipModels.Counter.ToString());

            //MessageBox.Show($"{ShipStart[0].Name}{ShipStart[0].Height}{ShipStart[0].Width}");
            //MessageBox.Show($"{ShipModels.Name}{ShipModels.Length}{ShipModels.Counter}");
            Ship = new IsShipPlacedCorr(BoardSize, ShipModels, ShipStart, UsedSpace, ShipPlaces);

            //MessageBox.Show($"{ShipStart[0].Width + ShipModels.Length},{ShipStart[0].Width},{ShipModels.Length},{BoardSize - 1}");
            //MessageBox.Show(UsedSpace.Count.ToString() + "e");
            //MessageBox.Show($"{"Start: "+ShipStart[0].Height},{"Dlugosc: " + ShipModels.Length},{"Koniec: "} {BoardSize - 1}" +
            //    $"{ShipStart[0].Height + ShipModels.Length <= BoardSize - 1},{"j"}");
            //MessageBox.Show(UsedSpace.Count.ToString() + "du");
            
            if (ShipStart[0].Height
                + ShipModels.Length
                <= BoardSize - 1) 
            {

                //MessageBox.Show($"{ShipStart[0].Height},{ShipModels.Length},{ShipStart[0].Height + ShipModels.Length}{"h"}");
                //MessageBox.Show("True");
                return Ship.IsCorr(ShipStart[0].Height, ShipStart[0].Height
                + ShipModels.Length, ShipStart[0].Width);
            
            }
            else
                return false;

            //return Ship.IsCorr();
            //corr = new IsShipPlacedCorr(startPlace, shipLength, stopPlace, UsedPlace);



        }
    }
}
