using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float damage;
    public float damageRadius;
    private CapsuleCollider capsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollisions();
    }

    void CheckCollisions()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, damageRadius);
        foreach (Collider hits in collisions)
        {
            if (hits == capsuleCollider)
            {
                continue;
            }
            else if (hits.gameObject.tag == "Player")
            {
                Debug.Log("Hit player");
                Health target = hits.transform.GetComponent<Health>();
                target.TakeDamage(damage);
            }
            else
            {
                continue;
            }

        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}
