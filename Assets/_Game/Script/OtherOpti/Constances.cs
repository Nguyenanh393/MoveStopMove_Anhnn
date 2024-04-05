using System;

namespace _Game.Script.OtherOpti
{
    public class Constances
    {
        public class ColliderTag
        {
            public const string WALL = "Wall";
            public const string CHARACTER = "Character";
            public const string BULLET = "Bullet";
            public const string ATTACK_CIRCLE = "AttackCircle";
        }
        
        public class Range
        {
            public const float DefaultAttackRange = 5f;
            public const int characterOnScreen = 11;
            public const float DefaultWaitSpawnTime = 6f;
        }
    }
}