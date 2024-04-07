using _Game.Script.DataSO;
using _Game.Script.DataSO.ItemData;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts.UI.ItemSkinShopButton
{
    public class ItemButtonUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private Image buttonSelectionImage;
        
        public void SetIcon(Sprite icon)
        {
            iconImage.sprite = icon;
        }
        
        public void OnClick()
        {
            buttonSelectionImage.gameObject.SetActive(true);
        }
    }
}