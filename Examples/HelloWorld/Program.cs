﻿using FlecsSharp;

namespace HelloWorld
{
    class Program
    {

        public struct Position
        {
            public float X { get; set; }
            public float Y { get; set; }
        }

        public struct Speed
        {
            public int SpeedValue { get; set; }
        }

        static void MoveSystem(EntitySet rows, Set<Position> position, Set<Speed> speed)
        {
            for(uint i = 0; i < rows.Count; i++)
            {
                EntityId id = rows[i];
                position[i].X += speed[i].SpeedValue * rows.DeltaTime;
                position[i].Y += speed[i].SpeedValue * rows.DeltaTime;
            }
        }

        static void Main(string[] args)
        {
            using (var world = World.Create())
            {
                world.AddSystem<Position, Speed>(MoveSystem, SystemKind.OnUpdate);

                var myEntity = world.NewEntity("MyEntity", new Position { X = 1, Y = 2 }, new Speed { SpeedValue = 5 });

                while (world.Progress(1))
                {

                }
            }
        }

    }
}