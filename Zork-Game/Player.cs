﻿using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Zork
{
    public class Player
    {
        public World World { get; }

        [JsonIgnore]
        public Room Location { get; private set; }

        [JsonIgnore]
        public string LocationName
        {
            get
            {
                return Location?.Name;
            }
            set
            {
                Location = World?.RoomsByName.GetValueOrDefault(value); //error happens here
            }
        }
        public Player(World world, string startingLocation)
        {
            World = world;
            LocationName = startingLocation;
        }
        public int Moves { get; set; }
        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Room destination);
            if (isValidMove)
            {
                Location = destination;
            }
            return isValidMove;
        }
    }
}