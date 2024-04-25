using _UI.Scripts.UI;
using UnityEngine.Events;

namespace _UI.Scripts
{
    public class GamePlay : UICanvas
    {
        public void SettingButton()
        {
            GameManager.ChangeState(GameState.Setting);
            UIManager.Ins.OpenUI<Setting>();
            GameManager.Ins.IsPause = true;
        }
    }
}
