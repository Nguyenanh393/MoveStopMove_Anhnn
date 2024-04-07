using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.WeaponData;
using _Game.Script.UserData;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts
{
    public class WeaponShop : UICanvas
    {
        //[SerializeField] private ItemDataSOList itemDataSOList;
        
        [SerializeField] private Image weaponIcon;
        
        [SerializeField] private Text weaponName; 
        [SerializeField] private Text weaponInfomation;
        [SerializeField] private Text buyButtonText;
        [SerializeField] private Text equipButtonText;
        
        [SerializeField] private Button equipButton;
        [SerializeField] private Button buyButton;
        
        private int currentWeaponIndex = 0;
        //private int currentEquipWeaponIndex = 0;
        private WeaponSO weaponSO;

        private void OnEnable()
        {
            SpawnWeapon();
        }

        public void ExitButton()
        {
            UIManager.Ins.OpenUI<MainMenu>();
            Close(0);
        }

        private void SpawnWeapon()
        {
            weaponSO = ItemDataSOManager.Ins.WeaponSO;
            WeaponData weaponData = weaponSO.DataList[currentWeaponIndex];
            
            weaponIcon.sprite = weaponData.GetTypeIcon;
            weaponName.text = weaponData.WeaponName;
            weaponInfomation.text = weaponData.WeaponInfo();
            
            UpdateButtonState();
        }
        private void UpdateButtonState()
        {
            WeaponData weaponData = weaponSO.DataList[currentWeaponIndex];
            int weaponState = GetUserDataWeaponState(currentWeaponIndex);
            if (weaponState != 0)
            {
                if (weaponState == 2)
                {
                    // currentEquipWeaponIndex = currentWeaponIndex;
                    SetVisible(equipButton, true);
                    SetVisible(buyButton, false);
                    equipButtonText.text = "EQUIPPED";
                }
                if (weaponState == 1)
                {
                    SetVisible(equipButton, true);
                    SetVisible(buyButton, false);
                    equipButtonText.text = "EQUIP";
                }
            } else
            {
                SetVisible(equipButton, false);
                SetVisible(buyButton, true);
                buyButtonText.text = "BUY " + weaponData.Price;
            }
        }
        
        public void NextButton()
        {
            currentWeaponIndex++;
            if (currentWeaponIndex >= weaponSO.DataList.Count)
            {
                currentWeaponIndex = 0;
            }
            SpawnWeapon();
        }
        
        public void PreviousButton()
        {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weaponSO.DataList.Count - 1;
            }
            SpawnWeapon();
        }

        private void SetVisible(Button button, bool visible)
        {
            button.gameObject.SetActive(visible);
        }
        
        public void OnClickBuyButton()
        {
            WeaponData weaponData = weaponSO.DataList[currentWeaponIndex];
            int price = weaponData.Price;
            int coin = DataManager.Ins.GetUserDataCoin();
            if (coin >= price)
            {
                DataManager.Ins.SetUserDataCoin(coin - price);
                SetUserDataWeaponState(currentWeaponIndex, 1);
                UpdateButtonState();
            }
        }
        
        public void OnClickEquipButton()
        {
            SetUserDataWeaponState(currentWeaponIndex, 2);
            for (int i = 0; i < weaponSO.DataList.Count; i++)
            {
                if (i != currentWeaponIndex)
                {
                    if (GetUserDataWeaponState(i) == 2)
                    {
                        SetUserDataWeaponState(i, 1);
                    }
                }
            }
            UIManager.Ins.OpenUI<MainMenu>();
            Close(0);
        }
        
        private void SetUserDataWeaponState(int valueIndex, int value)
        {
            DataManager.Ins.SetUserDataItemState(ItemDataSOManager.ItemTypeEnum.Weapon, valueIndex, value);
        }
        
        private int GetUserDataWeaponState(int valueIndex)
        {
            return DataManager.Ins.GetItemState(ItemDataSOManager.ItemTypeEnum.Weapon, valueIndex);
        }
    }
}
