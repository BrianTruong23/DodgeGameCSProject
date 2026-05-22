using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] float spawnPadding = 0.35f;

    float timer = 0f;
    SafeAreaController safeArea;

    void Awake()
    {
        safeArea = FindFirstObjectByType<SafeAreaController>();
    }

    void SpawnFallingObject()
    {
        float xPos = safeArea != null
            ? safeArea.GetSpawnX(spawnPadding)
            : Random.Range(-8f, 8f);

        Vector3 spawnPos = new Vector3(xPos, transform.position.y, 0f);
        Instantiate(fallingObjectPrefab, spawnPos, Quaternion.identity);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnFallingObject();
            timer = 0f;
        }
    }
}
