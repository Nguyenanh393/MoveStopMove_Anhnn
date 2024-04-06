using _Game.Script.DataSO.ItemData.HatData;
using _Game.Script.DataSO.ItemData.PantData;
using _Game.Script.DataSO.ItemData.ShiedData;
using _Game.Script.DataSO.ItemData.SkinSetData;
using _Game.Script.DataSO.WeaponData;
using UnityEngine;

namespace _Game.Script.DataSO.ItemData
{
    public class ItemDataSOList : MonoBehaviour
    {
        [SerializeField] private HatSO hatSO;
        [SerializeField] private PantSO pantSO;
        [SerializeField] private ShieldSO shieldSO;
        [SerializeField] private WeaponSO weaponSO;
        [SerializeField] private SkinSetSO skinSetSO;
        
        public HatSO HatSO => hatSO;
        public PantSO PantSO => pantSO;
        public ShieldSO ShieldSO => shieldSO;
        public WeaponSO WeaponSO => weaponSO;
        public SkinSetSO SkinSetSO => skinSetSO;
    }
}