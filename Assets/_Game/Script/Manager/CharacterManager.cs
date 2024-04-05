using System;
using System.Collections.Generic;
using _Game.Script.GamePlay.Camera;
using _Game.Script.GamePlay.Map;
using _Game.Script.Level;
using _Game.Script.Manager;
using _Game.Script.OtherOpti;
using _UI.Scripts.UI;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Character
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        [SerializeField] private SpawnPointSO spawnPointSO;
        
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
            Player.Player player = SimplePool.Spawn<Player.Player>(PoolType.Player,
                Vector3.zero, Quaternion.identity);
            player.TF.localScale = new Vector3(3f, 3f, 3f);
            player.SetAnim(AnimController.AnimType.Dance);
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
            Bot.Bot bot = SimplePool.Spawn<Bot.Bot>(PoolType.BotV2, 
                spawnPoints[i].Position, spawnPoints[i].Rotation);
            bot.OnInitBot();
            characters.Add(bot);
            botsOnScreen[i] = bot;
        }

        private void SpawnPlayer()
        {
            Player.Player player = SimplePool.Spawn<Player.Player>(PoolType.Player,
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