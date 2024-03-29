﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class World
    {
        ///<summary>
        ///--Jyri
        ///--Ria
        ///World Creation
        ///</summary>

        public List<Location> WorldList = new List<Location>();
        public Location WorldLocation { get; set; }
        public World() { }
        public void CreateWorlds()
        {
            #region Location
            Location Cave1 = new Location("dark cave.");
            Location Cave2 = new Location("dark cave tunnels.");
            Location Cave3 = new Location("pleasant cave room.");
            Location Cave4 = new Location("ogre cave.");

            Location Cave5 = new Location("hallway.");
            Location Cave6 = new Location("bone grave.");
            Location Cave7 = new Location("magic prison.");
            Location Cave8 = new Location("painted room.");
            Location Cave9 = new Location("tomb.");

            Location Cave10 = new Location("mist filled room.");
            Location Cave11 = new Location("room of dark magic.");
            Location Cave12 = new Location("long stairway.");
            #endregion

            #region Items
            Weapon Axe = new Weapon("Axe", 20);
            Weapon ShortSword = new Weapon("Short sword", 30);
            Potion HealPot = new Potion("Healing potion", 100);
            Item OgreQuestCompleteRequirement = new Item("Bloody ogre head");
            Item SorcererQuestCompleteRequirement = new Item("Sorcerer's wand");
            Item RustyKey = new Item("Rusty key")
            {
                EntranceDescription = "You try it on the door. The lock turns heavily and the door opens.",
                Description = "The key is old and heavy. You wonder what it might open."
            };
            Item WeirdLookingStone = new Item("weird glowing stone")
            {
                Description = "There is a faint glow eminating from the stone. Almost as if it was of celestial origin. What could it be for?",
                EntranceDescription = "You lift the stone towards the star shaped rock, which fades from existance."
            };
            #endregion

            #region Quests
            Quest OgreQuest = new Quest("Slay the ogre", "Slay the nasty ogre located north of the dark cave tunnels.", 100, OgreQuestCompleteRequirement)
            {
                CompletionMessage = "You return the " + OgreQuestCompleteRequirement.Name + " to the man. The monstrous ogre has been slain!"
            };
            OgreQuest.Reward_Items.Add(RustyKey);

            Quest SorcererQuest = new Quest("Kill the sorcerer", "Kill the sorcerer located somewhere in the dungeon and bring back its wand to me.", 150, SorcererQuestCompleteRequirement)
            {
                CompletionMessage = "You give the " + SorcererQuestCompleteRequirement.Name + " to the old man."
            };
            SorcererQuest.Reward_Items.Add(WeirdLookingStone);
            #endregion

            #region Monsters
            Monster Ogre = new Monster("Ogre", 100, OgreQuestCompleteRequirement)
            {
                Damage = 10,
                Exp = 120

            };
            Ogre.MonsterLoot.Add(HealPot);

            Monster SkeletonWarrior = new Monster("Skeleton warrior", 175)
            {
                Damage = 20,
                Exp = 150
            };

            Monster Zombie = new Monster("Zombie", 225, HealPot)
            {
                Damage = 30,
                Exp = 200
            };

            Monster Sorcerer = new Monster("Dark sorcerer", 350, SorcererQuestCompleteRequirement)
            {
                Damage = 40,
                Exp = 200
            };

            #endregion

            #region LocationSpecifics
            Cave1.LocationToNorth = Cave2;
            Cave1.LocationToEast = null;
            Cave1.LocationToSouth = null;
            Cave1.LocationToWest = null;
            Cave1.Info.Add(Cave1.Description = "The small cave you entered is very dark and moist.");
            Cave1.Info.Add(Cave1.Description2 = "The walls of the cave are filled with weird mushrooms, emitting a dim green light.");
            Cave1.Info.Add(Cave1.Description3 = "The light from the mushrooms allows you to vaguely see your nearby surroundings.");
            Cave1.Info.Add(Cave1.Description4 = "There is a passage that leads to north.");


            Cave2.LocationToNorth = Cave4;
            Cave2.LocationToEast = Cave5;
            Cave2.LocationToSouth = Cave1;
            Cave2.LocationToWest = Cave3;
            Cave2.Info.Add(Cave2.Description = "You are in a room which splits into multiple tunnels.");
            Cave2.Info.Add(Cave2.Description2 = "To the east, there is a large door, filled with ominous carvings about hellish monsters.");
            Cave2.Info.Add(Cave2.Description3 = "The tunnel to the north looks dark and uninviting.");
            Cave2.Info.Add(Cave2.Description4 = "The pathway to the west tunnel is clean and you can see a light in the distance.");
            Cave2.Info.Add(Cave2.Description5 = "To the south lies a dark, quiet passage.");

            Cave3.LocationToNorth = null;
            Cave3.LocationToEast = Cave2;
            Cave3.LocationToSouth = null;
            Cave3.LocationToWest = null;
            Cave3.Info.Add(Cave3.Description = "There is a bonfire in the middle of the room creating warmth and light around it.");
            Cave3.Info.Add(Cave3.Description = "The only passage is to the east, from where you entered the room.");
            Cave3.Info.Add(Cave3.Description2 = "A small humanoid creature sits in front of the bonfire.");

            Cave3.LocationItems.Add(HealPot);
            Cave3.LocationItems.Add(Axe);
            Cave3.LocationQuests.Add(OgreQuest);

            Cave4.LocationToNorth = null;
            Cave4.LocationToEast = null;
            Cave4.LocationToSouth = Cave2;
            Cave4.LocationToWest = null;
            Cave4.Info.Add(Cave4.Description = "An unpleasant smell welcomes you as you enter the room.");
            Cave4.Info.Add(Cave4.Description2 = "The floor is filled with bones and rusty weapons.");
            Cave4.Info.Add(Cave4.Description2 = "There is no passage out, besides the one you just walked in from.");
            Cave4.LocationMonsters.Add(Ogre);

            Cave5.LocationToNorth = null;
            Cave5.LocationToEast = Cave6;
            Cave5.LocationToSouth = null;
            Cave5.LocationToWest = Cave2;
            Cave5.Info.Add(Cave5.Description = "Torches on the wall light up the room.");
            Cave5.Info.Add(Cave5.Description2 = "You see some cages hanging from the cave roof, housing the remains of their last prisoners.");
            Cave5.Info.Add(Cave5.Description3 = "On the east end of the room, there are stairs which seem to be leading up.");
            Cave5.Info.Add(Cave5.Description4 = "To the west there is a large door.");
            Cave5.Key = RustyKey;
            Cave5.NoEntranceDescription = "The way is blocked by a large door. It is locked.";

            Cave6.LocationToNorth = Cave7;
            Cave6.LocationToEast = null;
            Cave6.LocationToSouth = null;
            Cave6.LocationToWest = Cave5;
            Cave6.Info.Add(Cave6.Description = "The temperature seems higher on this level of the cave than what it was before.");
            Cave6.Info.Add(Cave6.Description2 = "The walls of this room are warm to your touch.");
            Cave6.Info.Add(Cave6.Description3 = "You see a pathway leading to north. There are stairs going further down to the cave on the west side of the room.");
            Cave6.Info.Add(Cave6.Description4 = "There is a pile of bones on the ground.");
            Cave6.LocationMonsters.Add(SkeletonWarrior);

            Cave7.LocationToNorth = Cave8;
            Cave7.LocationToEast = null;
            Cave7.LocationToSouth = Cave6;
            Cave7.LocationToWest = null;
            Cave7.Info.Add(Cave7.Description = "You see an old man chained on the ground in the middle of this room.");
            Cave7.Info.Add(Cave7.Description2 = "The room is filled with dark symbols which seem to suck nearby light into them.");
            Cave7.Info.Add(Cave7.Description3 = "In one of its corners is a weapon rack.");
            Cave7.Info.Add(Cave7.Description4 = "There are ways leading south and north.");
            Cave7.LocationItems.Add(ShortSword);
            Cave7.LocationQuests.Add(SorcererQuest);
            Cave7.LocationItems.Add(HealPot);

            Cave8.LocationToNorth = Cave10;
            Cave8.LocationToEast = Cave9;
            Cave8.LocationToSouth = Cave7;
            Cave8.LocationToWest = null;
            Cave8.Info.Add(Cave8.Description = "The walls are covered with paintings of devils and tormented humans.");
            Cave8.Info.Add(Cave8.Description2 = "The painter seems to have loved the color red.");
            Cave8.Info.Add(Cave8.Description3 = "The east wall has a broken door leading somewhere. There is also a door leading north.");
            Cave8.Info.Add(Cave8.Description4 = "The way south seems darker than it should be.");

            Cave9.LocationToNorth = null;
            Cave9.LocationToEast = null;
            Cave9.LocationToSouth = null;
            Cave9.LocationToWest = Cave8;
            Cave9.Info.Add(Cave9.Description = "You see an stone sarcophagus in the room.");
            Cave9.Info.Add(Cave9.Description2 = "The smell of rotting flesh is overwhelming.");
            Cave9.Info.Add(Cave9.Description2 = "The room is a dead end, with no pathways besides the one you entered from.");

            Cave9.LocationMonsters.Add(Zombie);


            Cave10.LocationToNorth = null;
            Cave10.LocationToEast = null;
            Cave10.LocationToSouth = Cave8;
            Cave10.LocationToWest = Cave11;
            Cave10.Info.Add(Cave10.Description = "Room you entered is filled with thick mist, making it hard to see anything.");
            Cave10.Info.Add(Cave10.Description2 = "It pains you to keep your eyes open, but you are able to see that there are doors leading to west and south.");
            Cave10.Info.Add(Cave10.Description3 = "Not being able to see well makes you feel uneasy.");

            Cave11.LocationToNorth = null;
            Cave11.LocationToEast = Cave10;
            Cave11.LocationToSouth = null;
            Cave11.LocationToWest = Cave12;
            Cave11.Info.Add(Cave11.Description = "Wooden shelves full of different shaped and sized vials occupy the south and north walls.");
            Cave11.Info.Add(Cave11.Description2 = "You see a stone table on the south wall side. It has some bones and a chalice filled with black liquid on it.");
            Cave11.Info.Add(Cave11.Description3 = "It seems that the room is being used to perform some sort of dark magic rituals.");
            Cave11.Info.Add(Cave11.Description4 = "The path to the west is blocked by a large, star shaped stone.");
            Cave11.LocationMonsters.Add(Sorcerer);

            Cave12.LocationToNorth = null;
            Cave12.LocationToEast = null;
            Cave12.LocationToSouth = null;
            Cave12.LocationToWest = null;
            Cave12.Info.Add(Cave12.Description = "You enter to a stairwell which seem to continue endlessly upwards.");
            Cave12.Info.Add(Cave12.Description2 = "As you climb up you start to see some light.");
            Cave12.Info.Add(Cave12.Description3 = "In the distance, you can hear birds chirping.");
            Cave12.Key = WeirdLookingStone;
            Cave12.NoEntranceDescription = "The star shaped rock is too heavy for you to lift. You can't pass.";
            #endregion

            #region AddToWorld
            WorldList.Add(Cave1);
            WorldList.Add(Cave2);
            WorldList.Add(Cave3);
            WorldList.Add(Cave4);
            WorldList.Add(Cave5);
            WorldList.Add(Cave6);
            WorldList.Add(Cave7);
            WorldList.Add(Cave8);
            WorldList.Add(Cave9);
            WorldList.Add(Cave10);
            WorldList.Add(Cave11);
            WorldList.Add(Cave12);
            #endregion
        }
    }
}