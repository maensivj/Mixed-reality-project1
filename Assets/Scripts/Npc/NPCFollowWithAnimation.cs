using UnityEngine;

namespace Npc
{
    public class NPCFollowWithAnimation: MonoBehaviour
    {
        public Transform player;  // The player's Transform
        private UnityEngine.AI.NavMeshAgent agent;  // NavMeshAgent component
        private Animator animator;  // Animator component

        void Start()
        {
            // Get the required components
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
           
            if (player != null)
            {
                agent.SetDestination(player.position);
            }

            
            float speed = agent.velocity.magnitude;
            animator.SetFloat("Speed", speed);
        }
    }
}