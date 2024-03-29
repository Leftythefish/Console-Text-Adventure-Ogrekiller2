﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Location
    {
        ///<summary>
        ///--Ria--
        /// All data related to locations
        /// ID
        /// Name 
        /// Description
        /// Items available
        /// Quests available
        /// Position : Location to North
        /// Position : Location to East
        /// Position : Location to South
        /// Position : Location to West
        /// Monsters living here
        /// Event starters
        ///</summary>

        public List<Quest> LocationQuests = new List<Quest>();
        public List<Item> LocationItems = new List<Item>();
        public List<Monster> LocationMonsters = new List<Monster>();
        public List<string> Info = new List<string>();
        private readonly int id;
        private static int nextId = 10000;
        public int ID { get { return id; } }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public string Description5 { get; set; }
        public string Description6 { get; set; }
        public Item Key { get; set; } //Requirement to enter
        public string NoEntranceDescription { get; set; }
        public Location LocationToNorth;
        public Location LocationToEast;
        public Location LocationToWest;
        public Location LocationToSouth;
        //Constructors
        public Location(string name)
        {
            id = ++nextId;
            this.Name = name;
        }
        public Location(string name, string description)
        {
            id = ++nextId;
            this.Name = name;
            this.Description = description;
        }
        public Location(string name, string description, Location locationToNorth, Location locationToEast, Location locationToWest, Location locationToSouth)
        {
            id = ++nextId;
            this.Name = name;
            this.Description = description;
            this.LocationToNorth = locationToNorth;
            this.LocationToEast = locationToEast;
            this.LocationToSouth = locationToSouth;
            this.LocationToWest = locationToWest;
        }
    }
}


