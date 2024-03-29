﻿using System;
using System.Collections.Generic;
using Engine;

namespace Miniprojekti_1
{
    public class Program
    {
        public static World Cave = new World();
        public static string name;
        static void Main()
        {
            ///<summary>
            ///--Jesse--Ria--
            /// Main UI and it's components
            ///</summary>
            Player p = new Player();

            Window.CreateOpeningScreen();
            CreatePlayer(p);
            Console.SetCursorPosition(0, 29);
            Window.CreateMainScreen(p);
            Window.InsertOpeningTexts();
            //PlayerActions.PlayerInputHelp();
            //Create the world
            Cave.CreateWorlds();
            PlayTheGame(p);
        }
        public static void PlayTheGame(Player p) //--Ria
        {
            //set the player in start position
            var startlocation = LocationByName("dark cave.");
            p.CurrentLocation = startlocation;
            Window.EmptyStringData();
            do
            {
                p.Input = Console.ReadLine().ToLower();
                if (!string.IsNullOrEmpty(p.Input))
                {
                    PlayerActions.ReadInput(p);
                }
                else
                {
                    Window.EmptyGameTextFromScreen();
                    Window.EmptyStringData();
                    Window.line1 = "You are standing in the " + p.CurrentLocation.Name;
                    Window.InsertGameTextToScreen();
                }
            } while (p.Cur_Health > 0);

        }
        public static Location LocationByName(string name)
        {
            foreach (Location location in Cave.WorldList)
            {
                if (location.Name == name)
                {
                    return location;
                }
            }
            return null;
        }
        public static void CreatePlayer(Player p)
        {
            Console.SetCursorPosition(65, 25);
            Window.Print("Enter your name.", 70);
            Console.SetCursorPosition(0, 29);
            Console.WriteLine("                                                                                 ");
            Console.SetCursorPosition(0, 29);
            string input = Console.ReadLine();
            CheckInput(input);
            p.Name = name;
            p.Max_Health = 500;
            p.Cur_Health = 500;
            p.Level = 1;
            Weapon Fists = new Weapon("Rock", 10); // --Jyri
            p.EquippedWeapon = Fists;
            p.Inventory.Add(Fists);
        }
        public static string CheckInput(string input)
        {
            if (input.Length < 26)
            {
                name = input;
                return name;
            }
            else
            {
                name = "";
                Console.SetCursorPosition(60, 26);
                Console.Write("Please enter a shorter name!");
                Console.SetCursorPosition(0, 29);
                Console.Write("                                                                                                                        ");
                Console.SetCursorPosition(0, 29);
                string temp = Console.ReadLine();
                CheckInput(temp);
                return name;
            }
        }
    }
}


