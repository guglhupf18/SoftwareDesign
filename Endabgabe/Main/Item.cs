using System;

namespace TextAdventure
{
    public enum ItemType
    {
        consumable,
        weapon
    }
    public class Item
    {
        public string name;
        public int value;
        public ItemType type;
        public string description;

        public void Use()
        {
            if (this.type == ItemType.consumable)
                Game.player.GainHealth(this);
            else if (this.type == ItemType.weapon)
                Game.player.activeItem = this;
            else
                Console.Write("Item can not be used");
        }
    }
}