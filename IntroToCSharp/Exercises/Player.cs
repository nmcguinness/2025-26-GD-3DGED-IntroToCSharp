using GDEngine.Maths;

namespace Exercises
{
    public class Player
    {
        //Fields
        private Guid iD;
        private string name;
        private int health;
        private Vector3 position;
        private bool isActive;

        public Guid ID { get => iD;}
        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }
        public Vector3 Position { get => position; set => position = value; }
        public bool IsActive { get => isActive; set => isActive = value; }


        //Constructors
        public Player(string name, int health)
            : this(name, health, Vector3.Zero, true)
        {
           
        }

        public Player(string name, bool isActive)
            : this(name, 100, Vector3.Zero, true)
        {

        }

        public Player(string name, int health, Vector3 position, bool isActive)
        {
            this.iD = Guid.NewGuid();
            this.name = name;
            this.health = health;
            this.position = position;
            this.isActive = isActive;
        }

        public override string? ToString()
        {
            return $"Player({iD}, {name}, {health}, {position}, {isActive})";
        }

        //ToString

    }
}
