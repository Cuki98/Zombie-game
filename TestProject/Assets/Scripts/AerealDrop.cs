using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerealDrop : MonoBehaviour
{
    public Transform raypoint;
    public GameObject parachute;
    public ParticleSystem loot;
    public ParticleSystem landingParticles;
    public ParticleSystem dustParticles;
    public GameObject uiPromt;
    public Dropper dropper;
    public GameObject dropGameobject;
    private Animator anim;
    public Transform dropSpawnPosition;
    public AudioClip openingSfx;

    private bool dropped;
    private bool landed;
    private bool opened;

    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (dropped) return;

        RaycastHit hit;
        Debug.DrawRay(transform.position , Vector3.down * 20);
        if(Physics.Raycast(raypoint.position , Vector3.down * 20, out hit , 20 ))
        {
            if (hit.collider != null)
            {
                dropped = true;
                Destroy(parachute);
                rig.drag = 1;
            }
        }
    }

    private void Open()
    {
        anim.SetBool("Open", true);
        opened = true;
        
        gameObject.ReproduceLocalSound(openingSfx , new SoundManager.SoundSettings(volume:0.3f));
        loot.Play();
    }

    private void DropItems()
    {
        GameObject drop =  Instantiate(dropper.gameObject , dropSpawnPosition.position , Quaternion.identity);
        Dropper d = drop.GetComponent<Dropper>();
        d.SetUp(dropGameobject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (landed) return;
        landingParticles.Play();
        dustParticles.Play();
        landed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !opened)
        {
            Open();
        }

    }

}
