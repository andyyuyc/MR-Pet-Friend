using UnityEngine;

public class FillGroundWithPrefabs : MonoBehaviour
{
    public GameObject prefabToFill; // 想要填充的Prefab
    public Vector2Int gridDimensions; // 网格维度
    public Vector3 spacing; // Prefab之间的间距

    void Start()
    {
        FillGround();
    }

    void FillGround()
    {
        for (int x = 0; x < gridDimensions.x; x++)
        {
            for (int z = 0; z < gridDimensions.y; z++)
            {
                Vector3 spawnPosition = new Vector3(x * spacing.x, 0f, z * spacing.z);
                Instantiate(prefabToFill, spawnPosition, Quaternion.identity, transform);
            }
        }
    }
}
