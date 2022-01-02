using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Dash")]
public class DashAbility : Ability
{
    public float DashForce;
    public GameObject DashParticles;
    public AudioClip DashSfx;

    public override void ExecuteAbility()
    {

        Debug.Log("Ayoooo");
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();

        if (playerRigidbody)
        {
            playerRigidbody.AddForce(player.transform.forward * DashForce);
            GameObject particles = Instantiate(DashParticles, player.transform.position, DashParticles.transform.rotation);
            StaticHandler.i.PlayOneShot(DashSfx);
            Destroy(particles , 3f);
        }
    }
}
