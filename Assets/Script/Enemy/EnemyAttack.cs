using UnityEngine;

// 敵がプレイヤーにダメージを与える処理を管理するクラス
public class EnemyAttack : MonoBehaviour
{
    // プレイヤーに与えるダメージ量（Inspectorで調整可能）
    [SerializeField] private int damage = 10;

    // プレイヤーを攻撃しようとする処理
    // 引数として攻撃対象（プレイヤーのGameObject）を受け取る
    public void TryAttack(GameObject target)
    {
        // プレイヤーのHealth管理スクリプトを取得
        // GetComponentは、指定された型のコンポーネントをGameObjectから探すUnityの基本的な関数
        //target.GetComponent<PlayerHealth>は攻撃対象からPlayerHealthというスクリプトを探す
        //PlayerHealthという型にplayerHealthという変数が入っている
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();

        // プレイヤーがPlayerHealthコンポーネントを持っている場合のみダメージ処理を実行
        // nullチェックは、エラー防止のための重要なステップ
        if (playerHealth != null)
        {
            // プレイヤーのTakeDamage関数を呼び出してダメージを与える
            playerHealth.TakeDamage(damage);//PlayerHealthスクリプトのTakeDamageメソッドを呼ぶ。damageは引数でTakeDamageに数値を教える
        }
    }
}