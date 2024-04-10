using System.Collections.Generic;
using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.ItemData.SkinSetData;
using _Game.Script.GamePlay.Camera;
using _Game.Script.GamePlay.Character.Character;
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

        private void Start()
        {
            SpawnDancingPlayer();
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

        public void SpawnDancingPlayer()
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
            GamePlay.Character.Player.Player player = SimplePool.Spawn<GamePlay.Character.Player.Player>(poolType,
                Vector3.zero, Quaternion.identity);
            player.TF.localScale = new Vector3(3f, 3f, 3f);
            player.SetAnim(AnimController.AnimType.Dance);
            player.OnInitItem();
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
            GamePlay.Character.Player.Player player = SimplePool.Spawn<GamePlay.Character.Player.Player>(PoolType.Player,
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