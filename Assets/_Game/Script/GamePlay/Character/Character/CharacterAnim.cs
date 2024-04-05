using System;
using _Game.Script.OtherOpti;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Character
{
    public class CharacterAnim : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private Transform animTransform;
        
        [SerializeField] private AnimController animController;
        private AnimController.AnimType currentAnimType;
        
        public void SetAnim(AnimController.AnimType animType)
        {
            if (currentAnimType == animType)
            {
                return;
            } 
            anim.SetBool(animController.GetAnimType(currentAnimType), false);
            anim.SetBool(animController.GetAnimType(animType), true);
            currentAnimType = animType;
        }
    }
}