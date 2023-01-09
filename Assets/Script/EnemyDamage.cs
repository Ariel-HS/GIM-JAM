using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage; 
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerMovement.knockbackTimer = playerMovement.knockbackDuration;
<<<<<<< Updated upstream
            if(collision.transform.position.x < transform.position.x)
=======
            if(collision.transform.position.x <= transform.position.x)
>>>>>>> Stashed changes
                playerMovement.knockedFromRight = true;
            else
                playerMovement.knockedFromRight = false;
            playerHealth.TakeDamage(damage);
        }
    }
}
