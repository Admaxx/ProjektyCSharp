using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;

namespace BattleShipsFinal
{
    class GameBoard : AllDatas, IBoard
    {
        public List<string> CreatingWidth()
        {
            Enumerable.Range(0, 10).ToList().ForEach(item =>
               RcWidthList.Add($"Kw" + item));

            return RcWidthList;
        }
        public Dictionary<int, List<string>> CreatingBoard()
        {
            var Width = CreatingWidth();
            for (int i = 0; i <= Width.Count - 1; i++)
                Board.Add(i, new List<string>(Width));

            return Board;
        }

        public void GetValues()
        {
            var board = CreatingBoard();

            foreach 
                (
                KeyValuePair<int, List<string>> Rect in board
                )
            {
                Enumerable.Range(0, board.Count).ToList().ForEach(item => 
                { 
                    MessageBox.Show($"{Rect.Key}, {Rect.Value[item]}"
                ); 
                });
                
            }
        }

       
    }
}
