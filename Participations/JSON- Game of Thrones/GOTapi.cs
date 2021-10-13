using System;
using System.Collections.Generic;
using System.Text;

namespace JSON__Game_of_Thrones
{
    class GOTapi
    {
        public string quote { get; set; }
        public string character {get;set;}

        public override string ToString()
        {
            return $"{quote} - {character}";
        }
    }
}
