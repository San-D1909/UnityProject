using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    [SerializeField] private float range = 15f;
    public string enemyTag = "Enemy";
    [SerializeField] private Transform baseTurret;
      
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }
    private void Updatetarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if ( distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }   
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void Update()
    {
        if (target = null)
        {
            return;
        }
            

        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 turretrotation = lookrotation.eulerAngles;
        baseTurret.rotation = Quaternion.Euler(0f, turretrotation.y, 0f);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
        
    }

}
