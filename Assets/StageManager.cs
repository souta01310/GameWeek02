using UnityEngine;

public class SmageManager: MonoBehaviour
{
    [Header("吸収エフェクトのプレハブを登録")]
    [SerializeField] private GameObject absorbPrefab;  // 吸収系プレハブ

    [Header("出現設定")]
    [SerializeField] private int spawnCount = 10;       // 一度に出現させる数
    [SerializeField] private Vector3 spawnAreaSize = new Vector3(30f, 0f, 30f); // 出現範囲

    void Start()
    {
        SpawnAllAbsorbs();
    }

    private void SpawnAllAbsorbs()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomPos = transform.position + new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            Instantiate(absorbPrefab, randomPos, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.3f, 0.6f, 1f, 0.25f);
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
