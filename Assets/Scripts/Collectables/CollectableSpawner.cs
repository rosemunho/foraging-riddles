using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public Vector2Int amounts = Vector2Int.zero;
    public GameObject parent;
    public GameObject collectablePrefab;
    public float areaLength;

    void Start()
    {
        int amount = Random.Range(amounts.x, amounts.y);
        for(int i = 0; i < amount; i++)
        {
            Vector2 offset = GenerateRandomPositionOffset();
            Vector3 position = gameObject.transform.position + new Vector3(offset.x, 0, offset.y);
            GameObject collectable = Instantiate(collectablePrefab, position, Quaternion.identity, parent.transform);
        }
    }

    public Vector2 GenerateRandomPositionOffset()
    {
        Vector2 position = new Vector2();
        position.x = Random.Range(-areaLength/2, areaLength/2);
        position.y = Random.Range(-areaLength/2, areaLength/2);
        return position;
    }
}
