using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;

namespace BattleShipsFinal
{
    class IsShipPlacedCorr : CreateShips
    {
        
        internal int BoardSize { get; }
        public List<StartModel> ShipStart { get; }
        public ShipModels ShipModels { get; }
        public List<string> UsedSpace { get; }
        public List<string> ShipPlaces { get; }
        public List<string> TemporaryPlaces = new List<string>();
        public IsShipPlacedCorr(int size, ShipModels Models, List<StartModel> Start, List<string> Used, List<string> Ship)
        {
            BoardSize = size;
            ShipStart = Start;
            ShipModels = Models;
            UsedSpace = Used;
            ShipPlaces = Ship;
        }
        public bool IsCorr(int startedlength, int stoppedlength, int heigth)
        {
            //Trzeba dorobić metodę, która sprawdza, czy pole nie są zajęte
            //ShipStart[0].Height + ShipModels.Length
            //MessageBox.Show($"{ShipStart[0].Height}, {ShipModels.Length}{ShipStart[0].Height + ShipModels.Length}");
            //for (int j = startedlength;
            //        j <= stoppedlength;
            //        j++)
            //{
            //    MessageBox.Show($"{startedlength+j},{stoppedlength},{"nje"}");
            //    //MessageBox.Show($"{ShipStart[0].Name}{startedlength + j}{stoppedlength}");
            //    ShipPlaces.Add($"{ShipStart[0].Name}{startedlength + j}{stoppedlength}");

            //}
            
            for (int component = startedlength; component <= stoppedlength-1; component++)
            {
                //MessageBox.Show($"{ShipStart[0].Name}{component}{heigth}");
                //MessageBox.Show($"{startedlength},{item},{heigth},{"g"}");
                if (!UsedSpace.Any(item 
                    => item.Contains($"{ShipStart[0].Name}{component + 1}{heigth}")))
                {
                    TemporaryPlaces.Add($"{ShipStart[0].Name}{component}{heigth}");
                }
                else
                {
                    //MessageBox.Show(UsedSpace.Count.ToString() + "pa");
                    TemporaryPlaces.Clear();
                    return false;
                }
            }

            //MessageBox.Show($"{"Start: " + startedlength},{"Koniec: " + stoppedlength}{"g"}");
            //MessageBox.Show(ShipPlaces.Count().ToString() + "długość");
            //MessageBox.Show($"{ShipStart[0].Height},{ShipModels.Length}");
            //Enumerable.Range(1, 2).ToList().ForEach(item =>
            //{
            //    MessageBox.Show($"{ShipStart[0].Height + item},{ShipModels.Length}");
            //});
            //foreach (var Model in ShipStart)
            //{
            //    UsedPlace.Add($"{Model.Name}{Model.Height}{Model.Width}");
            //    ShipPlaces.Add($"{Model.Name}{Model.Height}{Model.Width}");
            //    MessageBox.Show($"{Model.Name}{Model.Height}{Model.Width}{"Ship"}");
            //}
            foreach (var Model in TemporaryPlaces)
            {
                UsedSpace.Add($"{Model}");
                ShipPlaces.Add($"{Model}");
            }
            TemporaryPlaces.Clear();
            //MessageBox.Show(UsedSpace.Count.ToString() + "pa");
            return true;

        }

    }
}
