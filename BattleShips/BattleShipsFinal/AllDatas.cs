using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsFinal
{
    class AllDatas
    {
        internal readonly int maxSize = 10;
        internal readonly int minSize = 0;
        internal List<string> PlayerBehavior = new List<string>()
        {
            "Wygrał gracz nr ",
            "Wykonuje ruch",
            "Czeka na swoją kolei",
            "Pudło!",
            "Trafienie!"
        };
        internal int AllShipCounts;
        internal List<string> Ex = new List<string>();
        internal List<string> RcWidthList = new List<string>();
        internal List<int> RcHeightList = new List<int>();
        internal Dictionary<int, List<string>> Board = new Dictionary<int, List<string>>();
        internal List<ShipModels> ShipModel;
        internal List<StartModel> StartElement = new List<StartModel>();
        internal readonly string StartValue = "Rect";
        internal List<string> UsedPlace = new List<string>();
        internal List<string> CurrPlace = new List<string>();
        internal Random rand = new Random();
        internal List<string> Strikes = new List<string>();
        internal List<string> ShipPlaces = new List<string>();
        internal Dictionary<int, int> ShipsData = new Dictionary<int, int>();

    }
}
