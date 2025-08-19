using UnityEngine;

// 敵キャラの移動とプレイヤーへの攻撃処理を管理するクラス
public class EnemyMove : MonoBehaviour
{
    // 敵の移動速度（Inspectorで調整可能）
    [SerializeField] private float moveSpeed = 2f;

    // 移動範囲の左端と右端（空のGameObjectを使って位置を指定）
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    // 現在右方向に移動しているかどうかのフラグ
    [SerializeField] private bool movingRight = true;

    // Rigidbody2D：物理挙動を制御するためのコンポーネント
    private Rigidbody2D rb;

    // SpriteRenderer：見た目（スプライト）を反転させるために使用
    private SpriteRenderer sprite;

    // 初期化処理（ゲーム開始時に1度だけ呼ばれる）
    private void Start()
    {
        // Rigidbody2DとSpriteRendererを取得しておく
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // 毎フレーム呼ばれる処理（移動処理を呼び出す）
    private void Update()
    {
        Patrol();
    }

    // 敵の左右パトロール移動処理
    private void Patrol()
    {
        // 移動方向に応じて速度を設定（右なら+1、左なら-1）
        float direction = movingRight ? 1f : -1f;

        // Rigidbody2DのlinearVelocityを使って移動（x方向のみ変更）
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        // 右端に到達したら左に反転
        if (movingRight && transform.position.x >= rightPoint.position.x)
        {
            movingRight = false;
            sprite.flipX = true; // スプライトを反転して向きを変える
        }
        // 左端に到達したら右に反転
        else if (!movingRight && transform.position.x <= leftPoint.position.x)
        {
            movingRight = true;
            sprite.flipX = false;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突相手がプレイヤーかどうかをタグで判定
        if (collision.gameObject.CompareTag("Player"))
        {
            // EnemyAttackコンポーネントを取得して攻撃処理を呼び出す
            EnemyAttack attack = GetComponent<EnemyAttack>();
            if (attack != null)
            {
                attack.TryAttack(collision.gameObject);
            }
        }
    }
}