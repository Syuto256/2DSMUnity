using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 左右の入力方向を取得
        float horizontalInput = Input.GetAxis("Horizontal");

        // 左右の移動アニメーションを制御
        bool isMoving = Mathf.Abs(horizontalInput) > 0.01f;
        animator.SetBool("IsMoving", isMoving);

        // キャラクターの向きを左右の入力に応じて変更
        if (horizontalInput > 0)
        {
            // 右を向く
            transform.localScale = new Vector3(6, 6, 1);
        }
        else if (horizontalInput < 0)
        {
            // 左を向く（X軸のスケールを反転）
            transform.localScale = new Vector3(-6, 6, 1);
        }

        // ジャンプ中かどうかを判定
        bool isJumping = Mathf.Abs(rb.linearVelocity.y) > 0.5f;
        animator.SetBool("IsJumping", isJumping);

        // 落下中かどうかを判定
        bool isFalling = rb.linearVelocity.y < -0.5f;
        animator.SetBool("IsFalling", isFalling);
    }
}