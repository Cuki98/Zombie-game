using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public GameObject explosionParticles;
    private Rigidbody rig;
    public LayerMask layer;
    public GameObject trail;
    public GameObject drop;
    private Vector3 velocity = Vector3.up;

    private PickupHandler pickup;

    bool landed;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();

        rig.useGravity = false;
        rig.isKinematic = true;

        velocity *= Random.Range(25f, 30f);
        velocity += new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
    }

    private void Update()
    {

        if (landed) return;
        rig.position += velocity * Time.deltaTime;

        if (velocity.y < -15)
            velocity.y = -15;
        else
            velocity -= Vector3.up * 50 * Time.deltaTime;      
    }
    public void SetUp(GameObject drop)
    {
        this.drop = drop;
        pickup = Instantiate(drop, transform.position, Quaternion.identity).GetComponent<PickupHandler>();
        pickup.transform.SetParent(transform);
        pickup.DeativatePickUp();

    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(trail);
        if (Tools.IsInLayerMask(other.gameObject, layer))
        {
            rig.isKinematic = false;
            rig.velocity = Vector3.zero;
            rig.constraints = RigidbodyConstraints.FreezeAll;
            landed = true;
            pickup.GetComponent<PickupHandler>().ActivatePickup();
            Destroy(rig);
        }
    }
}
