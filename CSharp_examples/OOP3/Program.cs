using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{

    interface IVisible
    {
        void Draw();
    }

    class Invisible : IVisible
    {
        public void Draw()
        {
            Console.WriteLine("I won't appear.");
        }
    }

    class Visible : IVisible
    {
        public void Draw()
        {
            Console.WriteLine("I'm showing myself.");
        }
    }

    interface ICollidable
    {
        void Collide();
    }

    class Solid : ICollidable
    {
        public void Collide()
        {
            Console.WriteLine("Bang!");
        }
    }

    class NotSolid : ICollidable
    {
        public void Collide()
        {
            Console.WriteLine("Splash!");
        }
    }

    interface IUpdatable
    {
        void Update();
    }

    class Movable : IUpdatable
    {
        public void Update()
        {
            Console.WriteLine("Moving forward.");
        }
    }

    class NotMovable : IUpdatable
    {
        public void Update()
        {
            Console.WriteLine("I'm staying put.");
        }
    }

    class GameObject : IVisible, IUpdatable, ICollidable
    {
        private readonly IVisible _visible;
        private readonly IUpdatable _updatable;
        private readonly ICollidable _collidable;

        public GameObject(IVisible visible, IUpdatable updatable, ICollidable collidable)
        {
            _visible = visible;
            _updatable = updatable;
            _collidable = collidable;
        }

        public void Update()
        {
            _updatable.Update();
        }

        public void Draw()
        {
            _visible.Draw();
        }

        public void Collide()
        {
            _collidable.Collide();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nplayer");
            Console.ForegroundColor = originalColor;
            var player = new GameObject(new Visible(), new Movable(), new Solid());
            player.Update(); player.Collide(); player.Draw();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\ncloud");
            Console.ForegroundColor = originalColor;
            var cloud = new GameObject(new Visible(), new Movable(), new NotSolid());
            cloud.Update(); cloud.Collide(); cloud.Draw();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nbuilding");
            Console.ForegroundColor = originalColor;
            var building = new GameObject(new Visible(), new NotMovable(), new Solid());
            building.Update(); building.Collide(); building.Draw();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\ntrap");
            Console.ForegroundColor = originalColor;
            var trap = new GameObject(new Invisible(), new NotMovable(), new Solid());
            trap.Update(); trap.Collide(); trap.Draw();



            Console.WriteLine("\nProgram vége!");
            Console.ReadLine();
        }
    }

    
}
