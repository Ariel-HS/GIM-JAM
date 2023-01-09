using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    LevelManager levelManager;
    public int maxHealth = 10; 
    public int health;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] bool isPlayer;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage; 
        healthText.text = "Health: " + health;
        
        if(health <= 0)
        {
            Die();
        }
    }

    public void WeakPoint(int damage)
    {
        health += damage;
        healthText.text = "Health: " + health;
    }
    public void Die()
    {
        if(isPlayer)
        {
            levelManager.LoadMainMenu();
        }
        Destroy(gameObject);
    }
}