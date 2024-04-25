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
            public const float DefaultAttackSpeed = 5f;
            public const int characterOnScreen = 20;
            public const float DefaultWaitSpawnTime = 6f;
            public const float BonusSizeRange = 1.05f; // 5% increase size
         }

        public class Data
        {
            public const string UserData = "UserData";
        }
    }
}