using System;
using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.WeaponData;
using _Game.Script.UserData;
using UnityEditor;
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
        
        [SerializeField] private Button EquipButton;
        [SerializeField] private Button BuyButton;
        
        private int currentWeaponIndex = 0;
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
        
        public void SpawnWeapon()
        {
            // sau sẽ lấy dữ liệu của playerprefs để hiển thị ra màn hình
            weaponSO = ItemDataSOManager.Ins.WeaponSO;
            WeaponData weaponData = weaponSO.DataList[currentWeaponIndex];
            weaponIcon.sprite = weaponData.GetTypeIcon;
            weaponName.text = weaponData.WeaponName;
            weaponInfomation.text = weaponData.WeaponInfo();
            int weaponState = DataManager.Ins.GetItemState(ItemDataSOManager.ItemTypeEnum.Weapon, currentWeaponIndex);
            if (weaponState != 0)
            {
                if (weaponState == 2)
                {
                    SetVisible(EquipButton, true);
                    SetVisible(BuyButton, false);
                    equipButtonText.text = "EQUIPPED";
                }
                if (weaponState == 1)
                {
                    SetVisible(EquipButton, true);
                    SetVisible(BuyButton, false);
                    equipButtonText.text = "EQUIP";
                }
            } else
            {
                SetVisible(EquipButton, false);
                SetVisible(BuyButton, true);
                buyButtonText.text = "BUY " + weaponData.Price;
            }
        }
        private void UpdateButtonState()
        {
            WeaponData weaponData = weaponSO.DataList[currentWeaponIndex];
            int weaponState = DataManager.Ins.GetItemState(ItemDataSOManager.ItemTypeEnum.Weapon, currentWeaponIndex);
            if (weaponState != 0)
            {
                if (weaponState == 2)
                {
                    SetVisible(EquipButton, true);
                    SetVisible(BuyButton, false);
                    equipButtonText.text = "EQUIPPED";
                }
                if (weaponState == 1)
                {
                    SetVisible(EquipButton, true);
                    SetVisible(BuyButton, false);
                    equipButtonText.text = "EQUIP";
                }
            } else
            {
                SetVisible(EquipButton, false);
                SetVisible(BuyButton, true);
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
            UpdateButtonState();
        }
        
        public void PreviousButton()
        {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weaponSO.DataList.Count - 1;
            }
            UpdateButtonState();
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
                DataManager.Ins.SetUserDataItemState(ItemDataSOManager.ItemTypeEnum.Weapon, currentWeaponIndex, 1);
                UpdateButtonState();
            }
        }
        
        public void OnClickEquipButton()
        {
            DataManager.Ins.SetUserDataItemState(ItemDataSOManager.ItemTypeEnum.Weapon, currentWeaponIndex, 2);
            for (int i = 0; i < weaponSO.DataList.Count; i++)
            {
            }
            UpdateButtonState();
        }
    }
}
