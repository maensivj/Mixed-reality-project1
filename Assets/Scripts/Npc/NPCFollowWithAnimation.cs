using UnityEngine;

namespace Npc
{
    public class NPCFollowWithAnimation : MonoBehaviour
    {
        public Transform player;  // The player's Transform
        private UnityEngine.AI.NavMeshAgent agent;  // NavMeshAgent component
        private Animator animator;  // Animator component

        public float rotationSpeed = 5f; // Speed of turning to face the player
        public float rotationThreshold = 1f; // Minimum angle difference (in degrees) to trigger rotation

        void Start()
        {
            // Get the required components
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            animator = GetComponent<Animator>();

            // Disable NavMeshAgent auto-rotation
            agent.updateRotation = false;
        }

        void Update()
        {
            if (player != null)
            {
                // Set the destination for the NavMeshAgent
                agent.SetDestination(player.position);

                // Handle rotation independently of NavMeshAgent
                RotateTowardsPlayer();

                // Update the animator's "Speed" parameter based on the agent's velocity
                float speed = agent.velocity.magnitude;
                animator.SetFloat("Speed", speed);
            }
        }

        private void RotateTowardsPlayer()
        {
            // Calculate direction to the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Ensure rotation only happens if the player is not directly in front
            if (directionToPlayer.magnitude > 0.1f)
            {
                // Calculate the target rotation
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

                // Calculate the angle difference
                float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);

                // Only rotate if the angle difference is above the threshold
                if (angleDifference > rotationThreshold)
                {
                    // Smoothly rotate towards the target rotation
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                }
            }
        }
    }
}
