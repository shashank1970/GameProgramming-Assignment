
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem muzzleflash;
    public AudioSource audioSource;
    public GameObject impactEffect;
    public float fireRate = 15f;
    public float impactForce = 30f;
    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            shoot();
        }
    }



    void shoot()
    {
        audioSource.Play();
        muzzleflash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            hit.transform.GetComponent<Target>();
            
            Target target = hit.transform.GetComponent<Target>();
           

            if (target != null)
            {
                target.TakeDamage(damage);

            }

           


            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
           GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        
        
        }
    }
}
