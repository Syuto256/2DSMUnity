using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private TextMeshProUGUI hpText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        UpdateHPUI();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        UpdateHPUI();

        if(currentHealth <= 0)
        {
            Die();
        }

    }

    void UpdateHPUI()
    {
        hpText.text = "HP:" + currentHealth.ToString();
    }


    void Die()
    {
        SceneManager.LoadScene("GameOver");



        Destroy(gameObject);
        
    }


   
}
