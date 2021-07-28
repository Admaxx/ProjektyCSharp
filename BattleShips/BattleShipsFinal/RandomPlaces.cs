using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BattleShipsFinal
{
    class RandomPlaces : AllDatas
    {
        internal List<StartModel> RandomStart(int Size)
        {
            StartElement.Clear();
            while (1 == 1)
            {
                StartElement.Add(new StartModel() 
                {
                    Name = StartValue,
                    Height = rand.Next(minSize, Size),
                    Width = rand.Next(minSize, Size) 
                });
                var Start = StartElement[0];

                if (UsedPlace.Any(item => item.Contains($"{Start.Name}{Start.Height}{Start.Width}")))
                    StartElement.Clear();
                

                else
                {
                    UsedPlace.Add($"{Start.Name}{Start.Height}{Start.Width}");
                    break;
                }

            }
            return StartElement;
        }

    }
}
