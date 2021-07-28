using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsFinal
{
    class CreateShips : AllDatas
    {
        internal List<ShipModels> Model()
        {
            ShipModel = new List<ShipModels>()
            {
                new ShipModels(){Name = "Carrier", Length = 5, Counter = 1},
                new ShipModels(){Name = "BattleShip", Length = 4, Counter = 1},
                new ShipModels(){Name = "Destroyer", Length = 3, Counter = 1},
                new ShipModels(){Name = "Submarine", Length = 3, Counter = 1},
                new ShipModels(){Name = "Partol Boat", Length = 2, Counter = 1}

            };

            return ShipModel;
        }

    }
}
