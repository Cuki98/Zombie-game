using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //Components
    public HealthComponent health;
    public GAtribute speed; 
    public GameObject hitParticles;


    EnemyPathFinding enemyMovement;
    CloseRangeAttackManager attackManager;
    private GameObject target;
    private Animator anim;

    private void Awake()
    {
        speed = GAtribute.SetUpAttribute(gameObject , AttributeName.speed);
        enemyMovement = GetComponent<EnemyPathFinding>();
        target = FindObjectOfType<BuildManager>().gameObject;
        attackManager = GetComponent<CloseRangeAttackManager>();
        anim = GetComponent<Animator>();


        health.OnHealthRunOut += OnDie;
        health.OnTakeDamage += OnDamageTaken;
        speed.OnAttributeChange += OnSpeedChange;

    }
    private void Start()
    {
        Debug.Log(speed.Value);
        enemyMovement.SetSpeed(speed.Value);
    }
    private void OnSpeedChange(object sender, GAtribute.AttributeCarrier e)
    {
        enemyMovement.SetSpeed(speed.Value);
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
    

    }
}

