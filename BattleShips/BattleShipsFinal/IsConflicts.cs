using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;

namespace BattleShipsFinal
{
    class IsConflicts
    {
        private StartModel startPlace;
        private List<ShipModels> shipLength;
        private int stopPlace;
        private bool ItsFits;

        public List<string> UsedPlace { get; }

        public IsConflicts(StartModel start, List<ShipModels> ship, int stop, List<string> Used)
        {
            startPlace = start;
            shipLength = ship;
            stopPlace = stop;
            UsedPlace = Used;
        }
        //internal bool IsFitsOnMap()
        //{
            
        //}
    }
}
