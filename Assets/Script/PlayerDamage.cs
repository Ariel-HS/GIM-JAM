using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage; 
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
<<<<<<< Updated upstream
        else if(collision.collider.gameObject.tag == "WeakPoint") 
=======
        else if(collision.collider.gameObject.transform.tag == "WeakPoint")
>>>>>>> Stashed changes
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage*2);
        }
    }
}
