using System;
using UnityEditor;
using UnityEngine;

namespace _Game.Script.OtherOpti
{
    public class AnimController : MonoBehaviour
    {
        public enum AnimType
        {
            Idle,
            Run,
            Attack,
            Die,
            Dance
        }
        public String GetAnimType(AnimType animType)
        {
            switch (animType)
            {
                case AnimType.Idle:
                    return "IsIdle";
                case AnimType.Run:
                    return "IsRun";
                case AnimType.Attack:
                    return "IsAttack";
                case AnimType.Die:
                    return "IsDead";
                case AnimType.Dance:
                    return "IsDance";
                default:
                    return "IsIdle";
            }
        }
    }
}