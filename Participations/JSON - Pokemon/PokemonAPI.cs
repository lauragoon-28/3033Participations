using System;
using System.Collections.Generic;
using System.Text;

namespace JSON___Pokemon
{
    public class PokemonAPI
    {
        public List<Result> results { get; set; }

    }

    public class PokeAPI
    {
        public int height { get; set; }
        public int weight { get; set; }
        public sprites sprite { get; set; }
    }
    public class sprites
    {
        public string front_default { get; set; }
        public string back_default { get; set; }
    }

    public class Result
    {
        public string name { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}
