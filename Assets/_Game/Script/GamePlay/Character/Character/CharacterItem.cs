using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.ItemData.HatData;
using _Game.Script.DataSO.ItemData.PantData;
using _Game.Script.DataSO.ItemData.ShiedData;
using _Game.Script.DataSO.ItemData.ShieldData;
using _Game.Script.DataSO.WeaponData;
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
        private void ChangeWeapon(int weaponIndex)
        {
            Destroy(currentWeapon.gameObject);
            currentWeapon = Instantiate(weaponData.DataList[weaponIndex].GetType, WeaponParent);
        }

        protected void ChangeHat(int hatIndex)
        {
            Destroy(currentHat.gameObject);
            currentHat = Instantiate(hatData.DataList[hatIndex].GetType, hatParent);
        }

        protected void ChangePant(int pantIndex)
        {
            currentPant = pantData.DataList[pantIndex].GetType;
            pantParent.gameObject.GetComponent<Renderer>().material = currentPant;
        }

        protected void ChangeShield(int shieldIndex)
        {
            Destroy(currentShield.gameObject);
            currentShield = Instantiate(shieldData.DataList[shieldIndex].GetType, shieldParent);
        }
        
        private void DespawnHat()
        {
            Destroy(currentHat.gameObject);
        }
        
        private void DespawnPant()
        {
            Destroy(currentPant);
        }
        
        private void DespawnShield()
        {
            Destroy(currentShield.gameObject);
        }
        
        private void DespawnWeapon()
        {
            Destroy(currentWeapon.gameObject);
        }
        
        private void DespawnAllItem()
        {
            DespawnHat();
            DespawnPant();
            DespawnShield();
            DespawnWeapon();
        }
    }
}