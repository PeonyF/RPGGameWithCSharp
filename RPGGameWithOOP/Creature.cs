using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGameWithOOP
{
    public enum CreatureType
    {
        None,
        Player = 1,
        Monster = 2
    }

    class Creature
    {
        CreatureType creatureType;

        protected int hp = 0;
        protected int attack = 0;

        protected Creature(CreatureType creatureType)
        {
            this.creatureType = creatureType;
        }

        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }


        public int GetHp()
        {
            return hp;
        }

        public int GetAttack()
        {
            return attack;
        }

        public bool IsDead()
        {
            return hp <= 0;
        }

        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
        }
    }
}
