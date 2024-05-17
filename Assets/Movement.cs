using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float frequency = 1.0f;
    public float magnitude = 1.0f;

    private float randomOffsetX;
    private float randomOffsetZ;

    private void Start()
    {
        randomOffsetX = Random.Range(0.0f, 100.0f);
        randomOffsetZ = Random.Range(0.0f, 100.0f);
    }

    private void Update()
    {
        float x = Mathf.PerlinNoise(Time.time * frequency + randomOffsetX, 0) * 2 - 1;
        float z = Mathf.PerlinNoise(0, Time.time * frequency + randomOffsetZ) * 2 - 1;
        Vector3 direction = new Vector3(x, 0, z).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
