﻿using System;

namespace one_time_pad_tool.gui
{
    public class ConsoleHelper 
    {
        // source: https://www.dreamincode.net/forums/topic/365540-Console-Menu-with-Arrowkeys/
        public static int MultipleChoice(bool canCancel, string[] menuItems, string menu_title)
        {
            // A variable to keep track of the current Item, and a simple counter.
            short curItem = 0, c;

            // The object to read in a key
            ConsoleKeyInfo key;

            do
            {
                // Clear the screen.  One could easily change the cursor position,
                // but that won't work out well with tabbing out menu items.
                Console.Clear();
                Console.WriteLine(menu_title);

                // The loop that goes through all of the menu items.
                for (c = 0; c < menuItems.Length; c++)
                {
                    // If the current item number is our variable c, tab out this option.
                    // You could easily change it to simply change the color of the text.
                    if (menuItems[c] == "Back" || menuItems[c] == "Exit")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    if (curItem == c)
                    {
                        Console.Write(">> ");
                        Console.WriteLine(menuItems[c]);
                    }
                    // Just write the current option out if the current item is not our variable c.
                    else
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;

                // Waits until the user presses a key, and puts it into our object key.
                Console.Write("\nSelect your choice with the arrow keys.");
                key = Console.ReadKey(true);

                // Simply put, if the key the user pressed is a "DownArrow", the current item will deacrease.
                // Likewise for "UpArrow", except in the opposite direction.
                // If curItem goes below 0 or above the maximum menu item, it just loops around to the other end.
                if (key.Key.ToString() == "DownArrow")
                {
                    curItem++;
                    if (curItem > menuItems.Length - 1) curItem = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    curItem--;
                    if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                }
                // Loop around until the user presses the enter go.
            } while (key.KeyChar != 13);

            return (int)curItem;
        }
    }
}
