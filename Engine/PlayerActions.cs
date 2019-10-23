﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{

    public class PlayerActions
    {
        //Player input
        //move to --> try to move to location, update player location
        //look around, search --> show description of possible event triggers
        // search EVENT TRIGGER --> give item, spawn monster, do nothing
        // fighting --> hit, use potion, run away

        public static void ReadInput(Player p) //deal with movement input, decide location to go to
        {
            switch (p.Input)
            {
                case "go north":
                case "n":
                    p.M_Direction = Player.MovementDirection.North;
                    MoveToLocation(p, p.CurrentLocation.LocationToNorth);
                    break;
                case "go south":
                case "s":
                    p.M_Direction = Player.MovementDirection.South;
                    MoveToLocation(p, p.CurrentLocation.LocationToSouth);
                    break;
                case "go east":
                case "e":
                    p.M_Direction = Player.MovementDirection.East;
                    MoveToLocation(p, p.CurrentLocation.LocationToEast);
                    break;
                case "go west":
                case "w":
                    p.M_Direction = Player.MovementDirection.West;
                    MoveToLocation(p, p.CurrentLocation.LocationToWest);
                    break;
                case "look around":
                case "search":
                    p.Act = Player.Action.LookAround;
                    break;
                default:
                    Console.WriteLine("You can hear the wind rustling as you stare emptily ahead and wonder what your place in the world is. Were you about to do something? ((hint: given input was not appropriate))");
                    break;
            }
        }
        public static void MoveToLocation(Player p, Location newLocation)
        {
            if (newLocation != null)
            {
                p.CurrentLocation = p.CurrentLocation.LocationToNorth;
                EnterNewLocation(p);
            }
            else
            {
                Console.WriteLine("You cannot go that way."); //generate additional answers here? maybe location based?
                //and go back to asking for input
            }
        }
        public static void EnterNewLocation(Player p)
        {
            var loc = p.CurrentLocation;
            //Display location name and description
            Console.WriteLine($"You have entered {loc.Name}");
            Console.WriteLine(loc.Description);

            //check if the location has a quest to offer
            if (loc.LocationQuests != null) // location has a quest
            {
                foreach (var lquest in loc.LocationQuests)
                {
                    //does the player already have the quest?
                    if (p.QuestList.Contains(lquest)) //player has the quest
                    {
                        if (lquest.QuestCompleted == true) //player has the quest and it is completed
                        {
                            // do nothing
                        }
                        else //player has quest and it is not marked as complete
                        {
                            if (p.Inventory.Contains(lquest.CompletionRequirement)) //does player inventory contain the required completion item?
                            {
                                //set quest completion status as complete and remove quest inventory item
                                lquest.QuestCompleted = true;
                                p.Inventory.Remove(lquest.CompletionRequirement);
                                //display completion message and give rewards
                                Console.WriteLine(lquest.CompletionMessage);
                                foreach (var item in lquest.Reward_Items)
                                {
                                    p.Inventory.Add(item);
                                    Console.WriteLine($"Added {item.Name} to inventory");
                                }
                                p.Exp = p.Exp + lquest.RewardXP;
                                p.UpdatePlayerLevel(p);
                                // update player level?
                            }
                            else
                            {
                                //display message that player doesn't have required items to complete quest?
                            }
                        }
                    }
                    else //player does not have the quest
                    {
                        //give the player the quest
                        p.QuestList.Add(lquest);
                        //Display message
                        Console.WriteLine(lquest.Description);
                    }
                }
            }
            //check if the location has a monster to fight
            if (loc.LocationMonsters != null) //here there be monsters
            {
                foreach (var mon in loc.LocationMonsters) //fight all monsters in turn, maybe random generate this to pick one?
                {
                    //displaymessage
                    //fightmonster'
                    FightMonster(p, mon);
                }
            }
            else
            {
                // Do nothing and end the loop
            }

        }
        private static void FightMonster(Player p, Monster mon)
        {
            int php = p.Cur_Health;
            int mhp = mon.Cur_Health;
            var p_weapon = p.EquippedWeapon;
            do
            {
                // player hits monster
                Console.WriteLine($"You slash the {mon.Name} with your {p_weapon.Name}, doing {p_weapon.Damage} damage.");
                mhp -= p_weapon.Damage;
                //monster hits player
                Console.WriteLine($"The {mon.Name} hits you, doing {mon.Damage} damage.");
                php -= mon.Damage;
                Window.UpdateHp(p);
            }
            while (php > 0 || mhp > 0);
            // check who died
            if (php <= 0)
            {
                Console.WriteLine("You died. Game over.");
            }
            else
            {
                Console.WriteLine($"You killed the mean {mon.Name}. Yippee!");
                Console.WriteLine($"You collect the mon.RewardItem");
                //player.Inventory.Add(mon.RewardItem);
            }
        }
        public static void Search(Player p, Location cur_location)
        {
            // search for items in location
            foreach (var item in cur_location.LocationItems)
            {
                // show message with items
                Console.WriteLine($"You find a {item.Name} and add stash it in your bag.");
                p.Inventory.Add(item);
            }
            // add items to player inventory
        }
    }
}
