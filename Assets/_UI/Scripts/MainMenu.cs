using _Game.Script.GamePlay.Camera;
using _Game.Script.Manager;
using _Game.Script.Manager.RawInput;
using _Game.Script.UserData;
using _UI.Scripts.UI;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts
{
    public class MainMenu : UICanvas
    {
        [Header("Coin Text")]
        [SerializeField] private Text coinText;
        
        [Header("Vibrator Button")]
        [SerializeField] private Image vibratorButton;
        [SerializeField] private Sprite vibratorOn;
        [SerializeField] private Sprite vibratorOff;
        
        [Header("Sound Button")]
        [SerializeField] private Image soundButton;
        [SerializeField] private Sprite soundOn;
        [SerializeField] private Sprite soundOff;
        private void Start()
        {
            SetCoinText();
        }

        private void OnEnable()
        {
            SetCoinText();
            vibratorButton.sprite = DataManager.Ins.GetVibrator() ? vibratorOn : vibratorOff;
            soundButton.sprite = DataManager.Ins.GetSound() ? soundOn : soundOff;
        }

        public void PlayButton()
        {
            //UIManager.Ins.OpenUI<Tutorial>();
            UIManager.Ins.OpenUI<GamePlay>();
            InputManager.Ins.FindJoystick();
            LevelManager.Ins.LoadMap();
            SimplePool.Despawn(CharacterManager.Ins.DancingPlayer);
            CharacterManager.Ins.LoadCharacter();
            GameManager.ChangeState(GameState.GamePlay);
            GameManager.Ins.IsPause = false;
            //UIManager.Ins.CloseUI<Tutorial>(3);
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
        
        public void VibratorButton()
        {
            DataManager.Ins.SetVibrator(!DataManager.Ins.GetVibrator());
            vibratorButton.sprite = DataManager.Ins.GetVibrator() ? vibratorOn : vibratorOff;
        }
        
        public void SoundButton()
        {
            DataManager.Ins.SetSound(!DataManager.Ins.GetSound());
            soundButton.sprite = DataManager.Ins.GetSound() ? soundOn : soundOff;
        }

        public void OnMainScreenOn()
        {
            CharacterManager.Ins.CollectAll();
            LevelManager.Ins.DespawnMap();
            UIManager.Ins.CloseAll();
            SimplePool.CollectAll();
            
            GameManager.ChangeState(GameState.MainMenu);
            UIManager.Ins.OpenUI<MainMenu>();
            CharacterManager.Ins.SpawnDancingPlayer(-1);
            CameraManager.Ins.SetPosition(new Vector3(0, 10, -20));
        }
    }
}
