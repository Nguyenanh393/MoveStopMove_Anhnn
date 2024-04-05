using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace _Game.Script.GamePlay.Character.Bot
{
    public class BotMove : GameUnit
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private float speed;
        [SerializeField] private Bot bot;
        
        private List<Character.Character> targets = new List<Character.Character>();
        private Vector3 currentTarget;
        
        public bool IsDestination => Vector3.Distance(TF.position, _destination + (TF.position.y - _destination.y) * Vector3.up) < 0.1f;
        private Vector3 _destination;
        
        public void OnInit()
        {
            navMeshAgent.speed = speed;
            _destination = TF.position;
        }
        
        public void Move()
        {
            Vector3 randomDirection = Random.insideUnitSphere * 10f;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 10f, 1);
            Vector3 finalPosition = hit.position;
            MoveToPosition(finalPosition);
        }

        private void MoveToPosition(Vector3 position)
        {
            _destination = position;
            navMeshAgent.enabled = true;
            navMeshAgent.SetDestination(_destination);
        }
        
        public void StopMove()
        {
            navMeshAgent.enabled = false;
        }
        
        public void EnableNavMeshAgent()
        {
            navMeshAgent.enabled = true;
        }
        
    }
    
}