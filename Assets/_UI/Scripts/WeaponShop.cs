using _Game.Script.DataSO.WeaponData;
using UnityEngine;

namespace _UI.Scripts
{
    public class WeaponShop : UICanvas
    {
        public void ExitButton()
        {
            UIManager.Ins.OpenUI<MainMenu>();
            Close(0);
        }
    }
}
