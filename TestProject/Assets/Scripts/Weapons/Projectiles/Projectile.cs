using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]public DamageDistributor distributor;
    public GameObject ImpactParticles;
    public float bulletSpeed;
    public float damage = 20;
    public LayerMask mask;

    private void Awake()
    {
        Destroy(gameObject , 5);
    }
    public void SetUp(DamageDistributor distributor)
    {
        this.distributor = distributor;
    }

    private void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1 , mask))
        {
            GameObject hitParticles = Instantiate(ImpactParticles, transform.position, Quaternion.identity);
            Destroy(hitParticles, 1);

            HealthComponent health = hit.collider.gameObject.GetComponentInParent<HealthComponent>();

            if (health)
            {
                if(distributor)
                distributor.DealDamage(health , damage, DamageType.Bullet);
            }
            Destroy(gameObject);
        }
    }
}
