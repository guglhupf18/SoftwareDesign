using System;
using System.Windows;
using System.Collections.Generic;

namespace TextAdventure
{
    public enum CharacterType
    {

        player,
        nonplayer
    }
    public class Character
    {
        public string name;
        public int health;
        public string description;
        public CharacterType type;
        public List<Item> inventory = new List<Item>();
        private int attackDamage;
        public string text;
        public Vector2 position;
        public Item activeItem;
        private bool friendly;

        public Character()
        {
            this.name = "";
            this.health = 0;
            this.description = "";
            this.inventory = new List<Item>();
            this.position = new Vector2(0, 0);
            this.text = "";
            this.activeItem = null;
            this.friendly = true;
            this.attackDamage = 0;
        }
        public Character(string _name, int _health, string _description, CharacterType _type, List<Item> _inventory,
        Vector2 _position, string _text, Item _activeItem, bool _friendly)
        {
            this.name = _name;
            this.health = _health;
            this.description = _description;
            this.type = _type;
            this.inventory = _inventory;
            this.position.x = _position.x;
            this.position.y = _position.y;
            this.text = _text;
            this.activeItem = _activeItem;
            this.friendly = _friendly;
            this.attackDamage = this.activeItem.value;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public CharacterType GetCharacterType()
        {
            return this.type;
        }

        public void TakeDamage(int _amount)
        {
            this.health -= _amount;
            if (this.health <= 0)
                this.Die();
        }

        public void Talk()
        {
            Console.Write(this.name + ":" + "\"" + this.text + "\"" + "\n");

        }
        public void Die()
        {
            Console.Write("The Character" + " " + this.name + " " + "has passed away.");
        }

        public Vector2 GetPosition()
        {
            return this.position;
        }
        public List<Item> GetInventory()
        {
            return this.inventory;
        }

        public void GainHealth(Item item)
        {
            this.health += item.value;
        }

        public void Move(Vector2 _direction)
        {
            this.position.x += _direction.x;
            this.position.y += _direction.y;
        }
    }
}