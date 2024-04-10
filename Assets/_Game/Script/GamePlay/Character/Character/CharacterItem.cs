using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.ItemData.HatData;
using _Game.Script.DataSO.ItemData.PantData;
using _Game.Script.DataSO.ItemData.ShiedData;
using _Game.Script.DataSO.ItemData.ShieldData;
using _Game.Script.DataSO.ItemData.SkinSetData;
using _Game.Script.DataSO.WeaponData;
using _Game.Script.OtherOpti;
using _Game.Script.UserData;
using Unity.VisualScripting;
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

        protected void OnInit()
        {
            DespawnAllItem();
        }

        public void ChangeWeapon(int weaponIndex)
        {
            currentWeapon = Instantiate(weaponData.DataList[weaponIndex].GetType, WeaponParent);
            currentWeapon.gameObject.SetActive(true);
        }

        protected void ChangeHat(int hatIndex)
        {
            currentHat = Instantiate(hatData.DataList[hatIndex].GetType, hatParent);
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
            currentShield = Instantiate(shieldData.DataList[shieldIndex].GetType, shieldParent);
        }

        protected void DespawnHat()
        {
            if (currentHat is null)
            {
                return;
            }
            Destroy(currentHat.gameObject);
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
            Destroy(currentShield.gameObject);
        }
        
        private void DespawnWeapon()
        {
            if (currentWeapon is null)
            {
                return;
            }
            Destroy(currentWeapon.gameObject);
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