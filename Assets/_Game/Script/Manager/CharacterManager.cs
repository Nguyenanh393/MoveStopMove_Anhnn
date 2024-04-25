using System.Collections.Generic;
using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.ItemData.SkinSetData;
using _Game.Script.GamePlay.Camera;
using _Game.Script.GamePlay.Character.Character;
using _Game.Script.GamePlay.Character.Player;
using _Game.Script.GamePlay.Map;
using _Game.Script.OtherOpti;
using _Game.Script.UserData;
using _UI.Scripts.UI;
using _UI.Scripts.UI.ItemSkinShopButton;
using UnityEngine;

namespace _Game.Script.Manager
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        [SerializeField] private SkinSetSO skinSetSO;
        
        private List<Character> characters = new List<Character>();
        private Character[] botsOnScreen;
        private float timer;
        private int countBotSpawned = 0;
        private TargetIndicator targetIndicator;
        private Character targetIndicatorHolder;
        
        private Player dancingPlayer;
        private Player player;
        public Player DancingPlayer => dancingPlayer;

        public TargetIndicator TargetIndicator
        {
            get => targetIndicator;
            set => targetIndicator = value;
        }
        
        public Character TargetIndicatorHolder
        {
            get => targetIndicatorHolder;
            set => targetIndicatorHolder = value;
        }
        private void Start()
        {
            SpawnDancingPlayer(-1);
        }

        private void Update()
        {
            if (GameManager.IsState(GameState.GamePlay))
            {
                RespawnBot();
            }
            
        }

        public List<Character> Characters
        {
            get => characters;
            set => characters = value;
        }
        
        public void CollectAll()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                SimplePool.Despawn(characters[i]);
            }
            characters.Clear();
            botsOnScreen = new Character[Constances.Range.characterOnScreen - 1];
            SimplePool.Collect(PoolType.TargetIndicator);
        }
        public void LoadCharacter()
        {
            CollectAll();
            SpawnPlayer();
            SpawnBotsAtFirstLoad();
        }

        public void SpawnDancingPlayer(int index)
        {
            // index = -1 => sinh player, index != -1 => thử skinset
            int? skinIndex;
            PoolType poolType;
            
            if (index == -1)
            {
                skinIndex = DataManager.Ins.GetItemEquipped(ItemDataSOManager.ItemTypeEnum.SkinSet);
                if (skinIndex == null)
                {
                    poolType = PoolType.Player;
                }
                else
                {
                    poolType = skinSetSO.DataList[skinIndex.Value].PoolType;
                }
            } 
            else
            {
                skinIndex = index;
                poolType = skinSetSO.DataList[skinIndex.Value].PoolType;
            }
            
            dancingPlayer = SimplePool.Spawn<Player>(poolType,
                Vector3.zero, Quaternion.identity);
            dancingPlayer.TF.localScale = new Vector3(3f, 3f, 3f);
            dancingPlayer.SetAnim(AnimController.AnimType.Dance);
            dancingPlayer.OnInitItem();
            
            CameraManager.Ins.GetCamera.TF.position = new Vector3(0, 10, -20);
        }
        
        public void RespawnDancingPlayer()
        {
            int? skinIndex = DataManager.Ins.GetItemEquipped(ItemDataSOManager.ItemTypeEnum.SkinSet);
            if (skinIndex.HasValue)
            {
                if (ItemSelectionUIManager.Ins.PlayerOnScene.poolType != skinSetSO.DataList[skinIndex.Value].PoolType)
                {
                    SimplePool.Despawn(dancingPlayer);
                    SpawnDancingPlayer(skinIndex.Value);
                    ItemSelectionUIManager.Ins.PlayerOnScene = dancingPlayer;
                    return;
                }
            } 
            else
            {
                if (ItemSelectionUIManager.Ins.PlayerOnScene.poolType != PoolType.Player)
                {
                    SimplePool.Despawn(dancingPlayer);
                    SpawnDancingPlayer(-1);
                    ItemSelectionUIManager.Ins.PlayerOnScene = dancingPlayer;
                    return;
                } 
            }
            ItemSelectionUIManager.Ins.PlayerOnScene.SetAnim(AnimController.AnimType.Dance);
            ItemSelectionUIManager.Ins.PlayerOnScene.OnInitItem();
        }
        private void SpawnBotsAtFirstLoad()
        {
            for (int i = 0; i < botsOnScreen.Length; i++)
            {
                SpawnBot(i);
            }
            countBotSpawned = botsOnScreen.Length;
        }
        
        private void SpawnBot(int i)
        {
            Vector3 position = new Vector3(Random.Range(-45f, 45f), 0, Random.Range(-30f, 30f));
            while ((position - player.TF.position).magnitude < 10)
            {
                position = new Vector3(Random.Range(-45f, 45f), 0, Random.Range(-30f, 30f));
            }
            GamePlay.Character.Bot.Bot bot = SimplePool.Spawn<GamePlay.Character.Bot.Bot>(PoolType.BotV2, 
                position, Quaternion.identity);
            characters.Add(bot);
            botsOnScreen[i] = bot;
            bot.OnInitBot();
        }

        private void SpawnPlayer()
        {
            int? skinIndex = DataManager.Ins.GetItemEquipped(ItemDataSOManager.ItemTypeEnum.SkinSet);
            PoolType poolType;
            if (skinIndex == null)
            {
                poolType = PoolType.Player;
            }
            else
            {
                poolType = skinSetSO.DataList[skinIndex.Value].PoolType;
            }
            player = SimplePool.Spawn<Player>(poolType,
                Vector3.zero, Quaternion.identity);
            CameraManager.Ins.GetCamera.Target = player.TF;
            characters.Add(player);
            player.OnInitPlayer();
        }
        
        private void RespawnBot()
        {
            if (countBotSpawned >= LevelManager.Ins.NumberOfBots) return;
            // if (timer < Constances.Range.DefaultWaitSpawnTime)
            // {
            //     timer += Time.deltaTime;
            // }
            // else
            // {
            //     for (int i = 0; i < botsOnScreen.Length; i++)
            //     {
            //         if (botsOnScreen[i].IsDead)
            //         {
            //             SpawnBot(i);
            //             countBotSpawned++;
            //         }
            //     }
            //     timer = 0;
            // }
            
            if (characters.Count >= 7) return;
            for (int i = 0; i < botsOnScreen.Length; i++)
            {
                if (botsOnScreen[i].IsDead)
                {
                    SpawnBot(i);
                    countBotSpawned++;
                }
            }
            
        }
        
    }
}