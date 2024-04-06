using System;
using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.WeaponData;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts
{
    public class WeaponShop : UICanvas
    {
        [SerializeField] private ItemDataSOList itemDataSOList;
        
        [SerializeField] private Image weaponIcon;
        
        [SerializeField] private Text weaponName; 
        [SerializeField] private Text weaponInfomation;
        [SerializeField] private Text ButtonText;
        
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
            weaponSO = itemDataSOList.WeaponSO;
            WeaponData weaponData = weaponSO.DataList[currentWeaponIndex];
            weaponIcon.sprite = weaponData.GetTypeIcon;
            weaponName.text = weaponData.WeaponName;
            weaponInfomation.text = weaponData.WeaponInfo();
            // if (PlayerPrefs.GetInt(weaponData.GetType.ToString(), 0) == 1)
            // {
            //     SetVisible(EquipButton, true);
            //     SetVisible(BuyButton, false);
            // } else
            // {
            //     SetVisible(EquipButton, false);
            //     SetVisible(BuyButton, true);
            //     ButtonText.text = "BUY " + weaponData.Price;
            // }
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
        
        public void SetVisible(Button button, bool visible)
        {
            button.gameObject.SetActive(visible);
        }
    }
}
