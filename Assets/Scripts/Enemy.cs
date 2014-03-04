using UnityEngine;
using System.Collections;
using Fungus;


	public class Enemy
	{
		public string Name { get; set; }
		public int Health { get; set; }
		public int Engine { get; set; }
		public int Lazerdam { get; set; }
		public int Acc { get; set; }
		
	}
/*
    public class Enemy
    {
        public virtual string Name { get; set; }
        public virtual int Health { get; set; }
        public virtual int Engine { get; set; }
        public virtual int Lazerdam { get; set; }
        public virtual int Acc { get; set; }

    }

    public class Weakling : Enemy //placeholdername
    {
        public override string Name { get { return "weakling"; } }
        public override int Health { get { return 10; } }
        public override int Engine { get { return 1; } }
        public override int Lazerdam { get { return 5; } }
        public override int Acc { get { return 75; } }

    }

    public class Stomper : Enemy //placeholdername
    {
        public override string Name { get { return "Stomper"; } }
        public override int Health { get { return 15; } }
        public override int Engine { get { return 2; } }
        public override int Lazerdam { get { return 7; } }
        public override int Acc { get { return 80; } }

    }

    public class SpaceOrca : Enemy //placeholdername
    {
        public override string Name { get { return "SpaceOrca"; } }
        public override int Health { get { return 100; } }
        public override int Engine { get { return 5; } }
        public override int Lazerdam { get { return 10; } }
        public override int Acc { get { return 60; } }

    }
*/