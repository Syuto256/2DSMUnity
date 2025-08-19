using UnityEngine;

// プレイヤーが取得できるコインの処理を管理するクラス
public class Coin : MonoBehaviour
{
    // このコインが加算するスコアの値（Inspectorで調整可能）
    [SerializeField] private int coinValue = 10;

    // 他のオブジェクトがこのコインのトリガーに入ったときに呼ばれる関数
    // ※このオブジェクトのColliderは「Is Trigger」に設定されている必要がある
    void OnTriggerEnter2D(Collider2D other)
    {
        // 接触したオブジェクトがプレイヤーかどうかをタグで判定
        // タグはInspectorで設定できる識別ラベル。CompareTag()は高速で安全な判定方法
        if (other.CompareTag("Player"))
        {
            // スコア管理クラスのインスタンスを通じてスコアを加算
            // シングルトンパターンにより、どこからでもScoreManager.Instanceにアクセス可能
            ScoreManager.Instance.AddScore(coinValue);

            // コインを取得したら、ゲーム画面から消す（破棄する）
            Destroy(gameObject);
        }
    }
}