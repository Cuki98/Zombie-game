using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupHandler : MonoBehaviour
{
    public float pickupDuration = 30;
    public float flickeringTime = 10;
    public float pickupRange = 2.25f;
    private float currentPickUpDuration;
    protected bool pickUpFlickering = false;
    public GameObject pickupParticles;
    public GameObject flickeringObject;
    public AudioClip pickupSfx;
    public AudioClip voiceOver;
    Pickup pickup;



    private void Awake()
    {
        pickup = GetComponent<Pickup>();

        SphereCollider collider = gameObject.AddComponent<SphereCollider>();
        collider.radius = pickupRange;
        collider.isTrigger = true;
    }
    private void Update()
    {
        HandlePickup();
    }

    public void HandlePickup()
    {
        if (!pickUpFlickering && currentPickUpDuration == 0) currentPickUpDuration = pickupDuration;

        if (currentPickUpDuration <= 0)
        {
            Destroy(gameObject);
        }

        currentPickUpDuration -= Time.deltaTime;

        if (!flickeringObject) return;

        if (currentPickUpDuration <= flickeringTime && !pickUpFlickering)
        {
            pickUpFlickering = true;

            StartCoroutine("Flicker");
        }
    }

    protected IEnumerator Flicker()
    {
        flickeringObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        flickeringObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        StartCoroutine("Flicker");

    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Player"))
        {
            pickup.OnPickedUp(other.gameObject);
            
            if(pickupParticles) StaticHandler.i.StaticDestroy( Instantiate(pickupParticles , transform.position , pickupParticles.transform.rotation) , 3);
            if(pickupSfx) StaticHandler.i.PlayOneShot(pickupSfx);
            if (voiceOver) StaticHandler.i.PlayOneShot(voiceOver);
            Destroy(gameObject);
        }
    }
}