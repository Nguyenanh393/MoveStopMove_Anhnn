using _Game.Script.DataSO;
using _Game.Script.DataSO.ItemData;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts.UI.SkinShopButton
{
    public class TopBarButtonUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private ItemDataSOList.ItemTypeEnum itemType;

        public DataSO<T> GetDataSO<T>()
        {
            return ItemDataSOList.Ins.GetDataSO<T>(itemType);
        }
        
        public void SetData(Sprite icon, ItemDataSOList.ItemTypeEnum itemType)
        {
            iconImage.sprite = icon;
            this.itemType = itemType;
        }
    }
}