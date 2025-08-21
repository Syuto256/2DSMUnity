using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private TextMeshProUGUI hpText;
    public float invincibleDuration = 3f; // 無敵時間（秒）
    private bool isInvincible = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        UpdateHPUI();

    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;

            UpdateHPUI();
            StartCoroutine(BecomeInvincible());
        }

        if (currentHealth <= 0)
            {
                Die();
            }

           
    }

    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;

        // ここでプレイヤーの見た目を点滅させるなどの演出を追加
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f); // 半透明にする例

        // 指定された時間待機
        yield return new WaitForSeconds(invincibleDuration);

        isInvincible = false;

        // ここでプレイヤーの見た目を元に戻す
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f); // 不透明に戻す例
    }


    void UpdateHPUI()
    {
        hpText.text = "HP:" + currentHealth.ToString() + "/100";
    }


    void Die()
    {
        SceneManager.LoadScene("GameOver");



        Destroy(gameObject);
        
    }


   
}
