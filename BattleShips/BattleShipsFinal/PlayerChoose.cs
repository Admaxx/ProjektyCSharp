using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsFinal
{
    class PlayerChoose : RandomPlace
    {
        internal string Choose() => $"{StartValue}{RandomVal()}{RandomVal()}";
    }
}
