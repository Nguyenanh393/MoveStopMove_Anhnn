using _Game.Script.DataSO.ItemData.HatData;
using _Game.Script.DataSO.ItemData.PantData;
using _Game.Script.DataSO.ItemData.ShiedData;
using _Game.Script.DataSO.WeaponData;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Character
{
    public class CharacterItem : MonoBehaviour
    {
        [SerializeField] private Transform hatParent;
        [SerializeField] private Transform pantParent;
        [SerializeField] private Transform shieldParent;
        [SerializeField] private Transform WeaponParent;
        
        [SerializeField] private HatSO hatData;
        [SerializeField] private PantSO pantData;
        [SerializeField] private ShieldSO shieldData;
        [SerializeField] private WeaponSO weaponData;
        
        private Weapon.Weapon currentWeapon;
        private Hat currentHat;
        private Material currentPant;
        private Shield currentShield;

        public Weapon.Weapon CurrentWeapon => currentWeapon;
        public Hat CurrentHat => currentHat;
        public Material CurrentPant => currentPant;
        public Shield CurrentShield => currentShield;
        protected void OnInit()
        {
            DespawnAllItem();
        }

        public void ChangeWeapon(int weaponIndex)
        {
            currentWeapon = SimplePool.Spawn<Weapon.Weapon>(weaponData.DataList[weaponIndex].GetType.poolType, WeaponParent);
//            Debug.Log(currentWeapon);
        }

        protected void ChangeHat(int hatIndex)
        {
            currentHat = SimplePool.Spawn<Hat>(hatData.DataList[hatIndex].GetType, hatParent);
        }

        protected void ChangePant(int pantIndex)
        {
            currentPant = pantData.DataList[pantIndex].GetType;
            pantParent.gameObject.GetComponent<Renderer>().material = currentPant;
            if (pantParent.gameObject.activeSelf == false)
            {
                pantParent.gameObject.SetActive(true);
            }
        }

        protected void ChangeShield(int shieldIndex)
        {
            currentShield = SimplePool.Spawn<Shield>(shieldData.DataList[shieldIndex].GetType.poolType, shieldParent);
        }

        protected void DespawnHat()
        {
            if (currentHat is null)
            {
                return;
            }
            SimplePool.Despawn(currentHat);
        }

        protected void DespawnPant()
        {
            if (currentPant is null)
            {
                return;
            }
            currentPant = null;
            pantParent.gameObject.SetActive(false);
        }

        protected void DespawnShield()
        {
            if (currentShield is null)
            {
                return;
            }
            SimplePool.Despawn(currentShield);
        }
        
        private void DespawnWeapon()
        {
            if (currentWeapon is null)
            {
                return;
            }
            SimplePool.Despawn(currentWeapon);
        }
        
        private void DespawnAllItem()
        {
            DespawnHat();
            DespawnPant();
            DespawnShield();
            DespawnWeapon();
            SetAllNull();
        }

        private void SetAllNull()
        {
            currentHat = null;
            currentPant = null;
            currentShield = null;
            currentWeapon = null;
        }
    }
}