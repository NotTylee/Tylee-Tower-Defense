using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header ("General")]

    public float range = 15f;

    [Header("Use Defualt Bullets")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool uselaser = false;

    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;

    [Header("USetup")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    
    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.05f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (uselaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                }
                   
            }


            return;
        }
            

        LockOnTarget();

        if (uselaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

       
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookrotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
        }
           

        lineRenderer.SetPosition(0, firepoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firepoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

       
    }
    void Shoot()
    {
       GameObject bulletGO =(GameObject) Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
       Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
