using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsFinal
{
    public interface IBoard
    {
        public List<string> CreatingWidth();
        public Dictionary<int, List<string>> CreatingBoard();
        public void GetValues();
    }
}
