using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private TextMeshProUGUI hpText;
    public float invincibleDuration = 3f; // ���G���ԁi�b�j
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

        // �����Ńv���C���[�̌����ڂ�_�ł�����Ȃǂ̉��o��ǉ�
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f); // �������ɂ����

        // �w�肳�ꂽ���ԑҋ@
        yield return new WaitForSeconds(invincibleDuration);

        isInvincible = false;

        // �����Ńv���C���[�̌����ڂ����ɖ߂�
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f); // �s�����ɖ߂���
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
