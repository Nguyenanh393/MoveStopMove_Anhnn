using System.Collections;
using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.WeaponData;
using _Game.Script.GamePlay.Character.Character;
using _Game.Script.UserData;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Player
{
    public class PlayerAttack : CharacterAttack
    {
        [SerializeField] private WeaponSO weaponSO;
        private bool attacked = false;
        public bool Attacked
        {
            get => attacked;
            set => attacked = value;
        }
        
        public void OnInit()
        {
            attacked = false;
            int weaponIndex = DataManager.Ins.GetItemEquipped(ItemDataSOManager.ItemTypeEnum.Weapon).Value;
            Weapon = weaponSO.DataList[weaponIndex].GetType;
            PoolType = weaponSO.DataList[weaponIndex].BulletPoolType;
            WeaponData = weaponSO.DataList[weaponIndex];
            base.OnInit();
        }
        public void Attack()
        {
            base.Attack();
            StartCoroutine(SetAttacked(true));
        }
        
        IEnumerator SetAttacked(bool att)
        {
            yield return new WaitForSeconds(0.8f);
            attacked = att;
        }
    }
}
