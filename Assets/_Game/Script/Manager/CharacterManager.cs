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
using UnityEngine;

namespace _Game.Script.Manager
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        [SerializeField] private SpawnPointSO spawnPointSO;
        [SerializeField] private SkinSetSO skinSetSO;
        
        private List<SpawnPoint> spawnPoints;
        private List<Character> characters = new List<Character>();
        private Character[] botsOnScreen = new Character[Constances.Range.characterOnScreen - 1];
        private float timer;
        private int countBotSpawned = 0;

        private Player dancingPlayer;
        
        public Player DancingPlayer => dancingPlayer;
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
            SimplePool.CollectAll();
            characters.Clear();
        }
        public void LoadCharacter()
        {
            spawnPoints = spawnPointSO.SpawnPoints;
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
        }
        private void SpawnBotsAtFirstLoad()
        {
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                SpawnBot(i);
            }
            countBotSpawned = spawnPoints.Count;
        }
        
        private void SpawnBot(int i)
        {
            GamePlay.Character.Bot.Bot bot = SimplePool.Spawn<GamePlay.Character.Bot.Bot>(PoolType.BotV2, 
                spawnPoints[i].Position, spawnPoints[i].Rotation);
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
            Player player = SimplePool.Spawn<Player>(poolType,
                Vector3.zero, Quaternion.identity);
            player.OnInitPlayer();
            CameraManager.Ins.GetCamera.Target = player.TF;
            characters.Add(player);
        }
        
        private void RespawnBot()
        {
            if (countBotSpawned == LevelManager.Ins.NumberOfBots) return;
            if (timer < Constances.Range.DefaultWaitSpawnTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                for (int i = 0; i < botsOnScreen.Length; i++)
                {
                    if (botsOnScreen[i].IsDead)
                    {
                        SpawnBot(i);
                        countBotSpawned++;
                    }
                }
                timer = 0;
            }
        }
        
    }
}