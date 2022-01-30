using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Gun Values")]
    public float damage = 10f;
    public float headShotDamage = 15f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    private float nextTimeToFire = 0f;


    [Header("Camera & Effects")]
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    






    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        
        
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);


            // Check if the thing we hit has health
            Health target = hit.transform.GetComponent<Health>();
           
            // Or check if it is a child
            if (target == null)
            {
                if (hit.transform.parent != null)
                {
                    target = hit.transform.parent.GetComponent<Health>();
                }
                
            }
            
/*            
            if (target.gameObject.tag == "HeadShot")
            {
                if (target != null)
                {
                    target.TakeDamage(headShotDamage);
                }*/
/*            } else*/
            //{
                if (target != null)
                {
                    if (hit.transform.name == "Head")
                    {
                        Debug.Log("Headshot");
                        target.TakeDamage(damage, true);
                }
                    else
                    {
                        target.TakeDamage(damage);
                    }
                }
            //}
            
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
