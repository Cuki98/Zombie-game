using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRangeAttackManager : MonoBehaviour
{
    public Transform attackOrigin;
    public LayerMask mask;
    public float triggerAttackDistance = 10f;
    private float lastAttackTime;
    private float attackRate = 1;
    private bool CanAttack { get { return Time.time >= lastAttackTime + attackRate; } }

    public void TryPerformAttack(Animator animator , Transform target)
    {
        if (CheckAttack(target) && CanAttack)
        {
            int randomAttack = Random.Range(0 , 2);
            Debug.Log(randomAttack);
            if(randomAttack == 0)
            animator.Play("Zombie Attack");
            else if (randomAttack == 1)
                animator.Play("Zombie Attack 1");
            lastAttackTime = Time.time;
        }
    }
    public bool CheckAttack(Transform target) 
    {
        float distance = Vector3.Distance(transform.position, target.position);
        
        return distance <= triggerAttackDistance;
        
    }

    public void CastDamageSphere()
    {   
        Collider [] hit = Physics.OverlapSphere(attackOrigin.position, 2, mask, QueryTriggerInteraction.Collide);
        if (hit.Length == 0) return;
        if (hit[0] != null)
        {
            HealthComponent health = hit[0].gameObject.GetComponent<HealthComponent>();
            if (health)
            {
                health.TakeDamage(10, DamageType.slash);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackOrigin.position, 2);
    }
}
