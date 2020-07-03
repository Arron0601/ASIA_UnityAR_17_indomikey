using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon : MonoBehaviour
{
    [Header("速度"), Range(0, 10)]
    public float speed = 1.5f;
    [Header("追蹤龍")]
    public string targetName = "龍";
    [Header("爆炸特效")]
    public GameObject explosion;
    [Header("停止距離")]
    public float stopDistance = 3;

    private Transform target;
    private NavMeshAgent nma;
    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        nma.speed = speed;
        target = GameObject.Find(targetName).transform;
        nma.SetDestination(target.position);
        nma.stoppingDistance = stopDistance;
    }
    private void CreatEffect()
    {
        GameObject expl = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(expl, 0.5f);
        Destroy(gameObject);
    }

    private void Track()
    {
        nma.SetDestination(target.position);
        if (nma.remainingDistance <= stopDistance)
        {
            CreatEffect();
        }
    }

    private void ClickAndDead()
    {
        CreatEffect();
    }
    private void OnMouseDown()
    {
        ClickAndDead();
    }
    private void Update()
    {
        Track();
    }
}
