using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGameWithOOP{
    public enum MonsterType
    {
        None = 0,
        Slime = 1,
        Orc = 2,
        Skeleton = 3
    }
    class Monster : Creature
    {
        protected MonsterType monsterType = MonsterType.None;

        protected Monster(MonsterType monsterType) : base(CreatureType.Monster)
        {
            this.monsterType = monsterType;
        }

        public MonsterType GetMonsterType()
        {
            return monsterType;
        }
    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime)
        {
            SetInfo(10, 10);
        }
    }

    class Orc : Monster
    {
        public Orc() : base(MonsterType.Orc)
        {
            SetInfo(20, 20);
        }
    }

    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Orc)
        {
            SetInfo(15, 50);
        }
    }
}
