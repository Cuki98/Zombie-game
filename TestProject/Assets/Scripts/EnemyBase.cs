using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //Components
    public HealthComponent health;
    public GameObject hitParticles;
    CloseRangeAttackManager attackManager;
    private GameObject target;
    private Animator anim;

    private void Awake()
    {
        health.OnHealthRunOut += OnDie;
        health.OnTakeDamage += OnDamageTaken;
        target = FindObjectOfType<BuildManager>().gameObject;
        attackManager = GetComponent<CloseRangeAttackManager>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        attackManager.TryPerformAttack(anim , target.transform);
    }
    protected virtual void OnDamageTaken(object sender, HealthComponent.DamageTakenArgs e)
    {
       GameObject hParticles = Instantiate(hitParticles , transform.position , Quaternion.identity);
       Destroy(hParticles , 2);

    }

    protected virtual void OnDie(object sender, EventArgs e)
    {
        //Destroy(gameObject);
        // GetComponent<EnemyPathFinding>().Disable();
        // GetComponent<EnemyPathFinding>().enabled = false;
        // LeanTween.moveY(gameObject , transform.position.y - 10 , .5f).setOnComplete(()=> { Destroy(gameObject); });
    }
}

