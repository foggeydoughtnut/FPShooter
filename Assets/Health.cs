using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 50f;
    public float headshotMultiplier = 2.0f;
    public void TakeDamage(float amount, bool wasHeadShot = false)
    {
        if (wasHeadShot)
        {
            health -= amount * headshotMultiplier;
        }
        else
        {
            health -= amount;
        }
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("DEAD");
        if (gameObject.tag == "Player")
        {
            return;
        } else
        {
            Destroy(gameObject);
        }

    }
}
