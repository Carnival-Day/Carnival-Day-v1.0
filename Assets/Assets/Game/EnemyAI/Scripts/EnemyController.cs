using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; // Import SceneManager

// Done by: Vanessa Ramirez
public class EnemyController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float playerDistance; // Distance between enemy and player
    public float awareAI = 20f; // Increased distance at which the enemy becomes aware of the player
    public float audioDistance = 10f; // Distance at which audio is audible
    public float AIMoveSpeed; // Speed at which the enemy moves
    public float damping = 6.0f; // Rate at which the enemy rotates towards the player
    public float nearPlayerDistance = 2f; // Distance at which player is considered near the enemy

    public Transform[] navPoints; // Array of patrol points
    public NavMeshAgent agent; // Reference to the NavMeshAgent component
    public int destPoint = 0; // Index of the current destination point

    private bool activated = false; // Flag to track if the enemy is activated

    public AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get reference to NavMeshAgent component attached to the enemy
        agent = GetComponent<NavMeshAgent>();

        // Get reference to AudioSource component attached to the enemy
        audioSource = GetComponent<AudioSource>();

        // Deactivate the enemy at the start
        gameObject.SetActive(false);
    }

    void Update()
    {
        // If the enemy is not activated, return
        if (!activated)
            return;

        // Calculate the distance between enemy and player
        playerDistance = Vector3.Distance(player.position, transform.position);

        // If player is within awareness range, look at player
        if (playerDistance < awareAI)
        {
            LookAtPlayer();
            Debug.Log("Seen");

            // Start playing the audio when the player is within audio range
            if (!audioSource.isPlaying && playerDistance <= audioDistance)
            {
                audioSource.Play();
            }
            // Stop playing the audio when the player is outside audio range
            else if (audioSource.isPlaying && playerDistance > audioDistance)
            {
                audioSource.Stop();
            }

            // Check if the player is near the enemy
            if (playerDistance < nearPlayerDistance)
            {
                // Load a new scene (change "SceneToLoad" to the name of your scene)
                SceneManager.LoadScene("SceneToLoad");
            }
        }

        // If player is within awareness range
        if (playerDistance < awareAI)
        {
            // If player is far away, chase the player
            if (playerDistance > 2f)
            {
                Chase();
            }
            else // If player is close, continue patrolling
            {
                GotoNextPoint();
            }
        }

        // Check if the AI has reached the destination point
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

    // Function to make the enemy look at the player
    void LookAtPlayer()
    {
        transform.LookAt(player);
    }

    // Function to make the enemy move to the next patrol point
    void GotoNextPoint()
    {
        // If no patrol points are defined, return
        if (navPoints.Length == 0)
        {
            return;
        }
        else // Otherwise, move to the next patrol point
        {
            agent.destination = navPoints[destPoint].position;
            destPoint = (destPoint + 1) % navPoints.Length;
        }
    }

    // Function to make the enemy chase the player
    void Chase()
    {
        agent.SetDestination(player.position);
    }

    // Function to activate the enemy
    public void ActivateEnemy()
    {
        activated = true;
        gameObject.SetActive(true);
    }
}
