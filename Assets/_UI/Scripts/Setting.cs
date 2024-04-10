using _Game.Script.GamePlay.Character.Character;
using _Game.Script.Level;
using _Game.Script.Manager;
using _UI.Scripts.UI;

namespace _UI.Scripts
{
    public class Setting : UICanvas
    {
        public void ContinueButton()
        {
            GameManager.ChangeState(GameState.GamePlay);
            Close(0);
        }
    
        public void HomeButton()
        {
            GameManager.ChangeState(GameState.MainMenu);
            CharacterManager.Ins.CollectAll();
            LevelManager.Ins.DespawnMap();
            UIManager.Ins.CloseAll();
            UIManager.Ins.OpenUI<MainMenu>();
            CharacterManager.Ins.SpawnDancingPlayer(-1);
            Close(0);
        }
    }
}
