using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BattleShipsFinal
{
    class GameBegin : AllDatas
    {
        internal void Game(bool player1, bool player2)
        {
            if (player1 == true)
            {
                GameSettings.GameOver = true;
                MessageBox.Show(PlayerBehavior[0] + $" 2");
            }
            else if(player2 == true)
            {
                GameSettings.GameOver = true;
                MessageBox.Show(PlayerBehavior[0] + $" 1");
            }
        }
    }
}
