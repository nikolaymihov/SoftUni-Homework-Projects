﻿using System.Collections.Generic;

namespace P01_PrototypePattern
{
    public class SandwichMenu
    {
        private readonly Dictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            this.sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name]
        {
            get { return this.sandwiches[name]; }

            set { this.sandwiches.Add(name, value); }
        }
    }
}
