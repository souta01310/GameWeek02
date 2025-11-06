using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float baseMoveSpeed = 5f; // 基本移動速度
    [SerializeField] private float runMultiplier = 1.8f; // Shiftで走る倍率
    [SerializeField] private float acceleration = 10f; // 移動加速のなめらかさ

    private Rigidbody rb;
    private Vector3 inputDirection;
    private Vector3 moveVelocity;
    private float speedMultiplier = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // プレイヤーが転ばないようにする
    }

    private void Update()
    {
        // --- 入力取得 ---
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // Shiftで走る
        float currentSpeed = baseMoveSpeed * (Input.GetKey(KeyCode.LeftShift) ? runMultiplier : 1f);
        currentSpeed *= speedMultiplier;

        // ターゲット速度を補間してスムーズに
        Vector3 targetVelocity = inputDirection * currentSpeed;
        moveVelocity = Vector3.Lerp(moveVelocity, targetVelocity, acceleration * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // Rigidbodyの速度を直接更新
        Vector3 velocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
        rb.linearVelocity = velocity;
    }

    // --- 外部から呼び出す速度補正（吸引などに使用） ---
    public void SetSpeedMultiplier(float value)
    {
        speedMultiplier = Mathf.Clamp(value, 0f, 2f); // 安全な範囲に制限
    }
}
