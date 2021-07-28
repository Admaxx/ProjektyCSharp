using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsFinal
{
    class AllDatas
    {
        internal Random rand = new Random();

        internal readonly int maxSize = 10;
        internal readonly int minSize = 0;
        internal readonly string StartValue = "Rect";
        internal int AllShipCounts;
        
        internal Dictionary<int, List<string>> Board = new Dictionary<int, List<string>>();
        internal Dictionary<int, int> ShipsData = new Dictionary<int, int>();

        internal List<ShipModels> ShipModel;
        internal List<StartModel> StartElement = new List<StartModel>();

        internal List<int> RcHeightList = new List<int>();

        internal List<string> Strikes = new List<string>();
        internal List<string> ShipPlaces = new List<string>();
        internal List<string> UsedPlace = new List<string>();
        internal List<string> CurrPlace = new List<string>();
        internal List<string> Ex = new List<string>();
        internal List<string> RcWidthList = new List<string>();
        internal List<string> PlayerBehavior = new List<string>()
        {
            "Wygrał gracz nr ",
            "Wykonuje ruch",
            "Czeka na swoją kolej",
            "Pudło!",
            "Trafienie!"
        };

    }
}
