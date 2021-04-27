using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGameWithOOP
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3
    }

    class Player : Creature
    {
        protected PlayerType type = PlayerType.None; //m_type 내에서만 사용하는 멤버 변수라는 뜻
       

        // Main 에서 바로 시작시 Player로 시작될 수 있기 떄문에 player type을 가지고 시작하도록 변경
        protected Player(PlayerType type) : base(CreatureType.Player)
        {
            this.type = type;
        }
       
    }

    class Knight : Player
    {
        public Knight() :base(PlayerType.Knight) //부모의 생성자를 가져오는 방식으로 변경
        {
            SetInfo(100, 10);
        }
    }

    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo(75, 12);
        }

    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo(50, 15);
        }

    }
}
