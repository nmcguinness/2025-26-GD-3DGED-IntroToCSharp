
using System.Numerics;

namespace Exercises
{
    public class Player
    {
        //Fields
        private string name;
        private int health;
        private Vector3 position;

        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }
        public Vector3 Position { get => position; set => position = value; }


        //Constructors
        public Player(string name, int health)
            : this(name, health, Vector3.Zero)
        {
           
        }
        public Player(string name, int health, Vector3 position)
        {
            this.name = name;
            this.health = health;
            this.position = position;
        }

        //ToString
    }
}
