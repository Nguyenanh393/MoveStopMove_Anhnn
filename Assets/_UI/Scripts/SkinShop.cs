using _Game.Script.DataSO.ItemData;
using _Game.Script.UserData;
using _UI.Scripts.UI.ItemSkinShopButton;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _UI.Scripts
{
    public class SkinShop : UICanvas
    {
        [SerializeField] private Button buyButton;
        [SerializeField] private Button equipButton;
        
        private UnityAction onClickEquipButton;
        
        public void ExitButton()
        {
            UIManager.Ins.OpenUI<MainMenu>();
            Close(0);
        }
        
        public void OnClickBuyButton()
        {
            ItemButtonUI itemButtonUI = ItemSelectionUIManager.Ins.CurrentButton;
            DataManager.Ins.SetUserDataCoin(DataManager.Ins.GetUserDataCoin() - itemButtonUI.ItemPrice);
            DataManager.Ins.SetUserDataItemState(itemButtonUI.ItemType, itemButtonUI.ItemIds, 1);
            buyButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(true);
        }
        
        public void OnClickEquipButton()
        {
            ItemButtonUI itemButtonUI = ItemSelectionUIManager.Ins.CurrentButton;
            int? itemEquipped = DataManager.Ins.GetItemEquipped(itemButtonUI.ItemType);
            if (itemEquipped != null)
            {
                DataManager.Ins.SetUserDataItemState(itemButtonUI.ItemType, (int)itemEquipped, 1);
            }
            DataManager.Ins.SetUserDataItemState(itemButtonUI.ItemType, itemButtonUI.ItemIds, 2);
            for (int i = 0; i < ItemSelectionUIManager.Ins.GetItemButtonList(itemButtonUI.ItemType).Count; i++)
            {
                ItemSelectionUIManager.Ins.GetItemButtonList(itemButtonUI.ItemType)[i].gameObject.SetActive(true);
            }
            equipButton.gameObject.SetActive(false);
        }
    }
}
