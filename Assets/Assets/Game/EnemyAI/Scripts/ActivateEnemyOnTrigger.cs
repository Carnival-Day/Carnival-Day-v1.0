using UnityEngine;

public class ActivateEnemyOnTrigger : MonoBehaviour
{
    public EnemyController enemyController; // Reference to the EnemyController script
    public AudioSource musicSource; // Reference to the AudioSource component playing the music

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the "Player" tag
        {
            enemyController.ActivateEnemy(); // Activate the enemy

            // Stop the music playback
            if (musicSource != null)
            {
                musicSource.Stop();
            }
        }
    }
}
