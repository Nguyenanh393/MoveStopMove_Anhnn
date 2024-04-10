using _Game.Script.GamePlay.Camera;
using _Game.Script.GamePlay.Character.Character;
using _Game.Script.Manager;
using _UI.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts
{
    public class Lose : UICanvas
    {
        public Text score;

        public void MainMenuButton()
        {
            GameManager.ChangeState(GameState.MainMenu);
            CharacterManager.Ins.CollectAll();
            LevelManager.Ins.DespawnMap();
            UIManager.Ins.CloseAll();
            UIManager.Ins.OpenUI<MainMenu>();
            CharacterManager.Ins.SpawnDancingPlayer(-1);
            CameraManager.Ins.SetPosition(new Vector3(0, 10, -20));
            Close(0);
        }
        
        public void SetScore(int score)
        {
            this.score.text = score.ToString();
        }
    }
}
