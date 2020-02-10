using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TextAdventure
{
    public class Game
    {
        private Map map;
        private bool gameIsRunning = true;
        private Maptile currentTile;
        public static Character player;


        public Game()
        {
            while (gameIsRunning)
            {
                Console.Write("-------------------------------------------------------------------------------" + "\n");
                Console.Write("Welcome! Please choose on of the following options with the according number." + "\n");
                Console.Write("1. Play Game" + "\n");
                Console.Write("2. Quit" + "\n");

                int input = GetIntFromPlayerInput();

                if (input == 1)
                    this.SetupGame();
                else if (input == 2)
                {
                    Console.Write("Application closed.");
                    this.gameIsRunning = false;
                }
                else
                    Console.Write("no valid input");
            }
        }
        private void SetupGame()
        {

            if (!ParseJsonFile())
            {
                Console.Write("Could not find a suitable .json file in the project folder" + "\n");
            }
            else
            {
                // TODOS: SetUpMapValues with json elements
                // Initialize Player

                StartGame();
            }
        }

        private void StartGame()
        {
            Console.Write("-----------------------------------------------------------------------" + "\n");

            Console.Write("Welcome to tortuga. Have fun!" + "\n");

            Console.Write("-----------------------------------------------------------------------");
            CreateWeapon("Stoneaxe", 30, "A stone axe");

            currentTile = new Maptile();
            DescribeEnvironment();
            AskForPlayerInput();
        }

        private Item CreateWeapon(string _name, int _value, string _descpription)
        {
            Item weapon = new Item();
            weapon.name = _name;
            weapon.value = _value;
            weapon.description = _descpription;
            weapon.type = ItemType.weapon;
            player.inventory.Add(weapon);
            player.activeItem = weapon;
            return weapon;
        }
        public void DescribeEnvironment()
        {

            Vector2 playerPos = player.GetPosition();

            for (int i = 0; i < map.maptiles.Length; i++)
            {

                if (map.maptiles[i].position.x == playerPos.x && map.maptiles[i].position.y == playerPos.y)
                {
                    currentTile = map.maptiles[i];
                }
            }
            Console.Write("\n" + currentTile.description);
            Console.Write("\n" + "You can also see:");
            ShowItems(currentTile.items);
            ShowCharacters(currentTile.characters);
        }

        public void ShowItems(List<Item> items)
        {
            Console.Write("\n" + "Items:" + "\n");
            if (items.Count == 0)
            {
                Console.Write("There are no items" + "\n");
            }
            for (int i = 0; i <= items.Count - 1; i++)
            {
                Item itemToShow = new Item();
                itemToShow = items[i];
                Console.Write(itemToShow.name + "\n");
            }

            Console.Write("----------------------" + "\n");
        }
        public JArray mapElements;
        public bool ParseJsonFile()
        {
            ParseMapJson();
            ParseCharJson(this.map);
            return true;
        }

        public void ParseMapJson()
        {
            string mapPath = "map.json";

            this.map = new Map();

            using (StreamReader r = new StreamReader(mapPath))
            {
                var json = r.ReadToEnd();
                mapElements = JArray.Parse(json);


                for (int i = 0; i <= mapElements.Count - 1; i++)
                {
                    Maptile tile = new Maptile();

                    tile.position.x = Int32.Parse(mapElements[i]["PositionX"].ToString());
                    tile.position.y = Int32.Parse(mapElements[i]["PositionY"].ToString());
                    tile.description = mapElements[i]["Description"].ToString();
                    int accesible;
                    accesible = Int32.Parse(mapElements[i]["Accesible"].ToString());
                    if (accesible == 0)
                        tile.accesible = false;
                    else if (accesible == 1)
                        tile.accesible = true;

                    this.map.maptiles[i] = tile;
                }

            }
        }

        public JArray charElements;
        public void ParseCharJson(Map _map)
        {
            string charPath = "char.json";


            using (StreamReader r = new StreamReader(charPath))
            {
                var json = r.ReadToEnd();
                charElements = JArray.Parse(json);


                for (int i = 0; i <= charElements.Count - 1; i++)
                {

                    Character characterToPlace = new Character();
                    characterToPlace.name = charElements[i]["Name"].ToString();

                    characterToPlace.position.x = Int32.Parse(charElements[i]["PositionX"].ToString());
                    characterToPlace.position.y = Int32.Parse(charElements[i]["PositionY"].ToString());

                    characterToPlace.description = charElements[i]["Description"].ToString();
                    characterToPlace.health = Int32.Parse(charElements[i]["Health"].ToString());



                    string text = charElements[i]["Text"].ToString();

                    characterToPlace.text = text;

                    string type = charElements[i]["Type"].ToString();
                    if (type == "player")
                        characterToPlace.type = CharacterType.player;
                    else if (type == "nonplayer")
                        characterToPlace.type = CharacterType.nonplayer;


                    for (int j = 0; j < this.map.maptiles.Length; j++)
                    {
                        if (this.map.maptiles[j].position.x == characterToPlace.position.x && this.map.maptiles[j].position.y == characterToPlace.position.y)
                            this.map.maptiles[j].characters.Add(characterToPlace);
                    }

                    if (characterToPlace.GetCharacterType() == CharacterType.player)
                        Game.player = characterToPlace;


                }

            }
        }
        private int GetIntFromPlayerInput()
        {
            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        private string GetStringFromPlayerInput()
        {
            return Console.ReadLine();
        }

        public void AskForPlayerInput()
        {
            Console.Write("\n" + "Please enter your command. To show all commands (c) press (c)" + "\n");
            switch (GetStringFromPlayerInput())
            {
                case ("c"):
                    ShowCommands();
                    break;
                case ("o"):
                    OpenInventory();
                    break;
                case ("l"):
                    DescribeEnvironment();
                    break;
                case ("t"):
                    TakeItem();
                    break;
                case ("m"):
                    Move();
                    break;
                case ("i"):
                    Interact();
                    break;
                case ("q"):
                    QuitGame();
                    break;
                default:
                    Console.Write("invalid input");
                    break;
            }
            AskForPlayerInput();
        }

        private void ShowCommands()
        {
            Console.Write("Commands:" + "\n");
            Console.Write("commands (c)" + "\n");
            Console.Write("open inventory (o)" + "\n");
            Console.Write("look around (l)" + "\n");
            Console.Write("take item (t)" + "\n");
            Console.Write("move (m)" + "\n");
            Console.Write("interact (i)" + "\n");
            Console.Write("quit game (q)" + "\n");
        }

        public void OpenInventory()
        {
            Console.Write("You open your inventory and see:");
            ShowItems(player.GetInventory());
            DisplayInventoryOptions();

            switch (GetStringFromPlayerInput())
            {
                case ("d"):
                    DropItem();
                    break;
                case ("u"):
                    UseItem();
                    break;
                case ("c"):
                    AskForPlayerInput();
                    break;
                default:
                    Console.Write("invalid input");

                    OpenInventory();
                    break;
            }
        }

        private void DisplayInventoryOptions()
        {
            Console.Write("-------------" + "\n");
            Console.Write("drop item (d)" + "\n");
            Console.Write("use item (u)" + "\n");
            Console.Write("close (c)" + "\n");

        }

        private void DropItem()
        {
            Console.Write("Which item would you like to drop?" + "\n");
            ShowItems(player.GetInventory());

            string input = GetStringFromPlayerInput();
            Item itemToDrop = new Item();

            for (int i = 1; i < player.inventory.Count; i++)
            {
                if (player.inventory[i].name == input)
                {
                    itemToDrop = player.inventory[i];
                    currentTile.items.Add(itemToDrop);
                    player.inventory.Remove(itemToDrop);

                    Console.Write("You dropped" + " " + itemToDrop.name);
                }
            }
        }

        private void UseItem()
        {
            Console.Write("Which item would you like to use?" + "\n");
            ShowItems(player.GetInventory());

            string input = GetStringFromPlayerInput();
            Item itemToUse = new Item();

            for (int i = 1; i < player.inventory.Count; i++)
            {
                if (player.inventory[i].name == input)

                    itemToUse = player.inventory[i];

            }
            itemToUse.Use();
            player.inventory.Remove(itemToUse);
        }

        private void TakeItem()
        {
            Console.Write("Which item would you like to take?" + "\n");
            ShowItems(currentTile.items);

            string input = GetStringFromPlayerInput();
            Item itemToTake = new Item();

            for (int i = 1; i <= currentTile.items.Count; i++)
            {
                if (currentTile.items[i].name == input)
                    itemToTake = currentTile.items[i];
            }

            player.inventory.Add(itemToTake);
            currentTile.items.Remove(itemToTake);
        }

        private void Move()
        {
            Console.Write("Where do you want to go?" + "\n");
            Console.Write("north (n)" + "\n");
            Console.Write("east (e)" + "\n");
            Console.Write("south (s)" + "\n");
            Console.Write("west (w)" + "\n");

            string input = GetStringFromPlayerInput();

            if (CheckValidMove(input))
            {

                player.Move(TransformDirectionIntoVector(input));

            }
            else
                Console.Write("\n" + "Can not go there" + "\n");

            Console.Write("----------------------" + "\n");

            DescribeEnvironment();
        }

        private bool CheckValidMove(string _direction)
        {
            bool isValid = false;
            Maptile targetTile = currentTile;

            switch (_direction)
            {
                case ("n"):
                    if (player.GetPosition().y < 3)
                    {
                        targetTile.position.y += 1;
                        Console.Write("walking north");
                        isValid = true;
                    }
                    break;
                case ("e"):
                    if (player.GetPosition().x < 3)
                    {
                        targetTile.position.x += 1;
                        Console.Write("walking east");
                        isValid = true;
                    }
                    break;
                case ("s"):
                    if (player.GetPosition().y > 0)
                    {
                        targetTile.position.y -= 1;
                        Console.Write("walking south");
                        isValid = true;
                    }
                    break;
                case ("w"):
                    if (player.GetPosition().x > 0)
                    {
                        targetTile.position.x -= 1;
                        Console.Write("walking west");
                        isValid = true;
                    }
                    break;
                default:
                    Console.Write("Invalid input");
                   // isValid = false;
                    break;
            }
            Console.Write("\n");

            if (CheckValidTile(targetTile))
            {

                currentTile = targetTile;
                Console.Write(currentTile.position.x);

                Console.Write(currentTile.position.y);
                Console.Write(currentTile.description);

            }

            return isValid;
        }
        public bool CheckValidTile(Maptile _targetTile)
        {
            for (int i = 0; i < map.maptiles.Length; i++)
            {

                if (map.maptiles[i].position.x == _targetTile.position.x && map.maptiles[i].position.y == _targetTile.position.y)
                {
                    _targetTile = map.maptiles[i];
                }
            }
            return _targetTile.accesible;
        }
        private Vector2 TransformDirectionIntoVector(string _direction)
        {
            Vector2 targetDirection = new Vector2(0, 0);
            switch (_direction)
            {
                case ("n"):
                    targetDirection = new Vector2(0, 1);
                    break;
                case ("e"):
                    targetDirection = new Vector2(1, 0);
                    break;
                case ("s"):
                    targetDirection = new Vector2(0, -1);
                    break;
                case ("w"):
                    targetDirection = new Vector2(-1, 0);
                    break;
                default:
                    Console.Write("Invalid input");
                    break;
            }

            return targetDirection;
        }

        private void Interact()
        {
            Console.Write("Who would you like to interact with?");

            ShowCharacters(currentTile.characters);

            string input = GetStringFromPlayerInput();
            Character target = new Character();
            for (int i = 0; i < currentTile.characters.Count; i++)
            {
                if (currentTile.characters[i].GetName() == input)
                    target = currentTile.characters[i];
            }

            Console.Write("What would you like to do with " + target.name + "?" + "\n");
            DisplayInteractionOptions();

            input = GetStringFromPlayerInput();

            switch (input)
            {
                case ("t"):
                    Talk(target);
                    break;
                case ("a"):
                    Attack(target);
                    break;
                case ("c"):
                    AskForPlayerInput();
                    break;
                default:
                    Console.Write("no valid input");
                    break;
            }
        }
        public void ShowCharacters(List<Character> _chars)
        {
            Console.Write("Characters:" + "\n");
            if (_chars.Count <= 0)
            {
                Console.Write("Here are no characters but you" + "\n");
            }
            for (int i = 0; i <= _chars.Count - 1; i++)
            {
                if (_chars[i].type == CharacterType.nonplayer)
                    Console.Write(_chars[i].GetName() + "\n");
            }

            Console.Write("----------------------" + "\n");
        }

        public void DisplayInteractionOptions()
        {
            Console.Write("talk (t)" + "\n");
            Console.Write("attack (a)" + "\n");
            Console.Write("close (c)" + "\n");
        }

        public void Talk(Character _target)
        {

            _target.Talk();

        }
        public void Attack(Character _target)
        {
            if (player.activeItem != null)
            {
                if (player.activeItem.type == ItemType.weapon)
                {
                    _target.TakeDamage(player.activeItem.value);

                    if (_target.GetHealth() > 0)
                    {
                        Console.Write("You hit" + " " + _target.name + " with " + player.activeItem.name + "\n");

                        Console.Write("Want to attack again? (y) / (n)" + "\n");
                        string input = GetStringFromPlayerInput();

                        if (input == "y")
                        {
                            Attack(_target);
                        }
                        else if (input == "n")
                        {
                            AskForPlayerInput();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.map.maptiles.Length; i++)
                        {
                            if (this.map.maptiles[i].position.x == _target.position.x && this.map.maptiles[i].position.y == _target.position.y)
                                this.map.maptiles[i].characters.Remove(_target);
                        }
                        AskForPlayerInput();
                    }
                }
                else
                    Console.Write("No weapon equipped");
            }
            else
                Console.Write("Can not attack without active item" + "\n");
        }

        public void QuitGame()
        {
            Console.Write("Do you really want to quit? (y) / (n)");
            string input = GetStringFromPlayerInput();
            if (input == "n")
                AskForPlayerInput();
            else if (input == "y")
            {
                Console.Write("Quitting game");
                Environment.Exit(0);
            }

        }
    }

}