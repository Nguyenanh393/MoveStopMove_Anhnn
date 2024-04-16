using _Game.Script.Manager;
using _Game.Script.Manager.RawInput;
using _Game.Script.UserData;
using _UI.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts
{
    public class MainMenu : UICanvas
    {
        
        [SerializeField] private Text coinText;

        private void Start()
        {
            SetCoinText();
        }

        private void OnEnable()
        {
            SetCoinText();
        }

        public void PlayButton()
        {
            UIManager.Ins.OpenUI<GamePlay>();
            InputManager.Ins.FindJoystick();
            LevelManager.Ins.LoadMap();
            CharacterManager.Ins.LoadCharacter();
            GameManager.ChangeState(GameState.GamePlay);
            Close(0);
        }
        
        public void SkinShopButton()
        {
            UIManager.Ins.OpenUI<SkinShop>();
            Close(0);
        }
        
        public void WeaponShopButton()
        {
            UIManager.Ins.OpenUI<WeaponShop>();
            Close(0);
        }
        
        private void SetCoinText()
        {
            coinText.text = DataManager.Ins.GetUserDataCoin().ToString();
        }
        
        
    }
}
