using UnityEngine;
using UnityEngine.AI;

namespace Npc
{
    public class NPCFollowWithAnimation : MonoBehaviour
    {
        public Transform player;  // The player's Transform
        private NavMeshAgent agent;  // NavMeshAgent component
        private Animator animator;  // Animator component

        public float rotationSpeed = 5f; // Speed of turning
        public float rotationThreshold = 1f; // Minimum angle difference to trigger rotation
        public float stoppingDistance = 1.5f; // Distance where NPC stops moving

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

            // Disable automatic rotation from NavMeshAgent
            agent.updateRotation = false;
            agent.stoppingDistance = stoppingDistance; // Ensure NPC stops near the player
            
            agent.isStopped = false; // ✅ Make sure it's not stopped
            agent.speed = 3.5f; // ✅ Set a reasonable speed
            agent.acceleration = 8f;
        }

        void Update()
        {
            if (player != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);

                // Move only if outside the stopping distance
                if (agent.remainingDistance > agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.remainingDistance < 0.5f) // Update only when necessary
                    {
                        agent.SetDestination(player.position);
                    }
                }
                else
                {
                    // Stop movement when close enough
                    agent.velocity = Vector3.zero; 
                    agent.ResetPath(); // Fully stop movement
                }

                // Rotate smoothly towards the player
                RotateTowardsPlayer();

                // Update animation speed
                animator.SetFloat("Speed", agent.velocity.magnitude);
            }
        }

        private void RotateTowardsPlayer()
        {
            if (player != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);

                if (agent.remainingDistance > agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.remainingDistance < 0.5f)
                    {
                        Debug.Log("Setting destination: " + player.position);
                        agent.SetDestination(player.position);
                    }
                }
                else
                {
                    Debug.Log("Stopping movement.");
                    agent.velocity = Vector3.zero; 
                    agent.ResetPath();
                }
            }

        }
    }
}
