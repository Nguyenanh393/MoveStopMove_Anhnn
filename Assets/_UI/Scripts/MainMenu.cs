using _Game.Script.DataSO.WeaponData;
using _Game.Script.GamePlay.Character.Character;
using _Game.Script.GamePlay.Weapon;
using _Game.Script.GamePlay.Weapon.Bullet;
using _Game.Script.Level;
using _Game.Script.Manager;
using _Game.Script.RawInput;
using _UI.Scripts.UI;
using UnityEngine;

namespace _UI.Scripts
{
    public class MainMenu : UICanvas
    {
        public void PlayButton()
        {
            UIManager.Ins.OpenUI<GamePlay>();
            InputManager.Ins.FindJoystick();
            LevelManager.Ins.LoadMap();
            CharacterManager.Ins.LoadCharacter();
            GameManager.ChangeState(GameState.GamePlay);
            Close(0);
        }
        
        // public void SkinShopButton()
        // {
        //     UIManager.Ins.OpenUI<SkinShop>();
        //     Close(0);
        // }
        
        public void WeaponShopButton()
        {
            UIManager.Ins.OpenUI<WeaponShop>();
            UIManager.Ins.GetUI<WeaponShop>().SpawnWeapon();
            Close(0);
        }
    }
}
