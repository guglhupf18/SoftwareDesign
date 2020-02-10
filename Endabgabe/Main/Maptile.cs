using System;
using System.Collections.Generic;

namespace TextAdventure
{

    public class Maptile
    {
        public Vector2 position;
        public List<Character> characters;
        public List<Item> items;
        public string description;
        public bool accesible;

        public Maptile()
        {
            this.position = new Vector2(0, 0);
            this.characters = new List<Character>();
            this.items = new List<Item>();
            this.description = "";

        }
        public Maptile(Vector2 _position, string _descpription, bool _accesible)
        {
            this.position = _position;
            this.characters = new List<Character>();
            this.items = new List<Item>();
            this.description = _descpription;
            this.accesible = _accesible;
        }
        public Vector2 GetPosition()
        {
            return this.position;
        }

        public List<Character> GetCharacters()
        {
            return this.characters;
        }

        public List<Item> GetItems()
        {
            return this.items;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public bool IsAccesible()
        {
            return this.accesible;
        }
    }
}