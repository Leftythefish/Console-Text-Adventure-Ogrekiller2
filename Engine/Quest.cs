﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Quest
    {
        ///<summary>
        ///--Ria--
        ///--Jyri--
        /// All data related to quests
        /// ID
        /// Name (+name plural)
        /// Description
        /// Reward XP
        /// Reward items
        ///</summary>
        ///
        private readonly int id;
        private static int nextId = 10000;
        public int ID { get { return id; } }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string description;
        public string Description
        {
            get { return description; }   
            set { description = value; }
        }

        private int rewardXP;
        public int RewardXP
        {
            get { return rewardXP; }
            set { rewardXP = value; }
        }

        public List<Item> Reward_Items = new List<Item>();

        public Quest(string name, string description, int XP, List<Item> rewards)
        {
            id = ++nextId;
            this.Name = name;
            this.Description = description;
            this.RewardXP = XP;
            // For each item in rewards list add to rewards?
        }
    }
}