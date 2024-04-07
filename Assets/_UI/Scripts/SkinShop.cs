using _Game.Script.DataSO.ItemData;
using _UI.Scripts.UI.ItemSkinShopButton;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts
{
    public class SkinShop : UICanvas
    {
        [SerializeField] private Button buyButton;
        [SerializeField] private Button equipButton;
        
        public void ExitButton()
        {
            UIManager.Ins.OpenUI<MainMenu>();
            Close(0);
        }
        
    }
}
