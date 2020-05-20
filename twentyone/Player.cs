using System;
using System.Collections.Generic;

namespace examination_3
{
    class Player : Hand
    {
        public string Name { get; private set; }
        public int Limit { get; private set; }

        public Player(string name, int limit)
        : base()
        {
            Name = name;
            Limit = limit;
        }


    }
}