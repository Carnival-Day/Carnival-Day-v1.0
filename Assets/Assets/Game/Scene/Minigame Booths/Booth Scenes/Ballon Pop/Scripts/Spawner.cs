using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Collider spawnArea;

    public GameObject balloonPrefab;
    public GameObject bombPrefab;
    [Range(0f, 1f)] public float bombChance = 0.05f;
    public GameObject rainbowPrefab;
    [Range(0f, 1f)] public float rainbowChance = 0.03f;

    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;
    public float maxLifetime = 5f;
    public float minFloatSpeed = 1.0f; // Minimum float speed
    public float maxFloatSpeed = 5.0f; // Maximum float speed

    public BalloonBehavior balloon;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            GameObject prefab = balloonPrefab;

            if (Random.value < bombChance) {
                prefab = bombPrefab;
            }

            if (Random.value < rainbowChance){
                prefab = rainbowPrefab;
            }

            Vector3 position = new Vector3
            {
                x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                z = 0
            };

            GameObject balloon = Instantiate(prefab, position, transform.rotation);
            Destroy(balloon, maxLifetime);

            BalloonBehavior balloonScript = balloon.AddComponent<BalloonBehavior>();
            if (prefab == bombPrefab) {
                balloonScript.points = -5; // Set points for bomb
            } else if (prefab == rainbowPrefab) {
                balloonScript.points = 5; // Set points for rainbow
            } else {
                balloonScript.points = 1; // Regular balloons, adjust as necessary
            }

            // Add an upward force to make the object float
            Rigidbody2D rb = balloon.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0; // Make sure the object doesn't fall down due to gravity
            float randomFloatSpeed = Random.Range(minFloatSpeed, maxFloatSpeed);
            rb.velocity = new Vector2(0, randomFloatSpeed); // Make it float upwards

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}
