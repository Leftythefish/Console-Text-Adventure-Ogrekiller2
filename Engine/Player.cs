﻿using System;
using System.Collections.Generic;

namespace Engine
{
    public class Player : Creature
    {
        public List<Item> Inventory = new List<Item>();
        public List<Quest> QuestList = new List<Quest>();
        public int Level { get; set; }
        public int Exp { get; set; }
        public string Input { get; set; }

        private Location currentLocation;
        public Location CurrentLocation { get => currentLocation; set => currentLocation = value; }

        private Weapon equippedWeapon;
        public Weapon EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }

        public enum MovementDirection
        {
            North,
            East,
            South,
            West,
        }
        public enum Action
        {
            LookAround,
            Fight,

        }
        public MovementDirection M_Direction;
        public Action Act;

        public Player() { }
        public Player(string name, int maximum_health) : base(name, maximum_health)
        {
            this.Exp = Exp;
            this.Level = Level;
        }
        internal void UpdatePlayerLevel()
        {
            // player level calculator
            // check player experience
            if (this.Exp > 100)
            {
                this.Level = this.Level++;
                this.Exp -= 100;
                Console.WriteLine("Yay, you gained a level!");
            }
            // method to update lvl on the screen
            // if player experience is above 100, increase player level, remove 100 points from player exp            
        }
    }
}
