using UnityEngine;

public class AttractionField : MonoBehaviour
{
    [Header("引き寄せ設定")]
    [Tooltip("吸引力の強さ")] 
    [SerializeField] private float attractionForce = 10f;   // 吸引の強さ
    [Tooltip("プレイヤーの移動速度の強度(倍)")]
    [SerializeField] private float slowMultiplier = 0.4f;   // 移動速度を何倍にするか
    [Tooltip("範囲")]
    [SerializeField] private float fieldRadius = 5f;        // 有効範囲

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.attachedRigidbody;
            if (rb == null) return;

            // --- 中心へ向かうベクトルを計算 ---
            Vector3 direction = (transform.position - other.transform.position).normalized;

            // --- 引き寄せ力を加える ---
            rb.AddForce(direction * attractionForce, ForceMode.Acceleration);

            // --- プレイヤーの速度を遅くする ---
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetSpeedMultiplier(slowMultiplier);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // フィールドを抜けたら元の速度に戻す
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetSpeedMultiplier(1f);
            }
        }
    }

    // --- Scene上で範囲を視覚的に確認する ---
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.5f, 0.2f, 1f, 0.3f);
        Gizmos.DrawSphere(transform.position, fieldRadius);
    }
}
