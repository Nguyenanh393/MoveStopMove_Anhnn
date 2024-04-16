using _Game.Script.DataSO.ItemData;
using _Game.Script.GamePlay.Character.Character;
using _Game.Script.GamePlay.Character.StateMachine.Player;
using _Game.Script.Level;
using _Game.Script.Manager;
using _Game.Script.Manager.RawInput;
using _Game.Script.OtherOpti;
using _Game.Script.UserData;
using _UI.Scripts;
using _UI.Scripts.UI;
using _UI.Scripts.UI.ItemSkinShopButton;
using UnityEngine;
using UnityEngine.Events;

namespace _Game.Script.GamePlay.Character.Player
{
    public class Player : Character.Character
    {
        [SerializeField] private PlayerMove playerMove;
        [SerializeField] private PlayerAttack playerAttack;
        [SerializeField] private PlayerItem playerItem;
        
        private FloatingJoystick floatingJoystick;
        public bool Attacked
        {
            get => playerAttack.Attacked;
            set => playerAttack.Attacked = value;
        }
        public bool CanAttack => playerAttack.CanAttack;

        private IState<Player> currentState;

        void Update()
        {
            if (GameManager.IsState(GameState.GamePlay))
            {
                if (currentState != null)
                {
                    currentState.OnExecute(this);
                } 
            }

            if (IsDead && GameManager.IsState(GameState.GamePlay))
            {
                GameManager.ChangeState(GameState.Lose);
                UIManager.Ins.OpenUI<Lose>().SetScore(Score);
                DataManager.Ins.SetUserDataCoin(DataManager.Ins.GetUserDataCoin() + Score);
            }

            if (CharacterManager.Ins.Characters.Count == 1 && CharacterManager.Ins.Characters[0] == this)
            {
                UIManager.Ins.OpenUI<Win>();
                GameManager.ChangeState(GameState.Win);
                UIManager.Ins.GetUI<Win>().SetScore(Score);
                DataManager.Ins.SetUserDataCoin(DataManager.Ins.GetUserDataCoin() + Score);
            }
        }
        
        public void ChangeState(IState<Player> state)
        {
            if (currentState != null)
            {
                currentState.OnExit(this);
            }
        
            currentState = state;
        
            if (currentState != null)
            {
                currentState.OnEnter(this);
            }
        }

        public void OnInitPlayer()
        {
            OnInit();
            ChangeState(new PlayerIdleState());
            floatingJoystick = InputManager.Ins.GetJoystick;
            playerMove.FloatingJoystick = floatingJoystick;
            playerMove.Player = this;
            playerAttack.OnInit();
            OnInitItem();
        }
        
        
        public bool isMoving() => InputManager.Ins.HasJoystick();
        public void Move() => playerMove.Move();
        public void StopMove() => playerMove.StopMove();
        
        public void Attack() => playerAttack.Attack(); 
        
        public TargetIndicator TargetIndicator => playerAttack.TargetIndicator;
        public void TryItemInSkinShop(ItemDataSOManager.ItemTypeEnum itemType, int itemId)
        {
            playerItem.TryItemInSkinShop(itemType, itemId);
        }
        
        public void OnInitItem()
        {
            playerItem.OnInitItem();
        }
    }
}