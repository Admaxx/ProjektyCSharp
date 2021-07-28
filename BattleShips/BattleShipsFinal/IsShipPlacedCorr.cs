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
            for (int component = startedlength; component <= stoppedlength-1; component++)
            {
                if (!UsedSpace.Any(item 
                    => item.Contains($"{ShipStart[0].Name}{component + 1}{heigth}")))
                {
                    TemporaryPlaces.Add($"{ShipStart[0].Name}{component}{heigth}");
                }
                else
                {
                    TemporaryPlaces.Clear();
                    return false;
                }
            }
            foreach (var Model in TemporaryPlaces)
            {
                UsedSpace.Add($"{Model}");
                ShipPlaces.Add($"{Model}");
            }
            TemporaryPlaces.Clear();
            return true;

        }

    }
}
