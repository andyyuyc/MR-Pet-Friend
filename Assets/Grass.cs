using UnityEngine;

public class FillGroundWithPrefabs : MonoBehaviour
{
    public GameObject prefabToFill; // ��Ҫ����Prefab
    public Vector2Int gridDimensions; // ����ά��
    public Vector3 spacing; // Prefab֮��ļ��

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
