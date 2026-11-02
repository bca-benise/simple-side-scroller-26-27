using UnityEngine;
using UnityEngine.Rendering;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private float firstGeneratedX = 13f;
    [SerializeField] private float platformSpacing = 6f;
    [SerializeField] private float minY = -1.75f;
    [SerializeField] private float maxY = 1.75f;

    private float _nextX;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _nextX = firstGeneratedX;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Spawn"))
        {
            return;
        }

        float nextY = Random.Range(minY, maxY);
        Vector3 nextPosition = new Vector3(_nextX, nextY, 0f);

        Instantiate(platformPrefab, nextPosition, Quaternion.identity);
        _nextX += platformSpacing;

        // This trigger has done its job. Don't let it spawn twice.
        other.enabled = false;
    }
}
