using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float time=1f;
    public float timeAttack=1f;
    public float damage = 1f;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            timeAttack -= Time.deltaTime;
            if (timeAttack <= 0) {
               other.gameObject.GetComponent<PBehaviourExample>().TakeDamage(damage);
                timeAttack = time;
            }
            
        }
    }
}
