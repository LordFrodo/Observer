using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyController : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private GameObject player;
    public bool stop, lose;
    private float original_speed, time;
    public static event Action lose_event;
    [SerializeField] private float animation_duration;
    [SerializeField]GameManager ingame;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updatePosition = true;
        original_speed = navMeshAgent.speed;
    }

    void Update()
    {
        if (ingame.ingame)
        {
            time += Time.deltaTime;
            if (player != null && stop == false) navMeshAgent.SetDestination(player.transform.position);
            if (time > 1)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    //time += Time.deltaTime;
                    if (lose == false)
                    {

                        ingame.ingame = false;
                        lose_event?.Invoke();
                        lose = true;

                    }
                }

            }
            
        }
        Debug.Log(navMeshAgent.remainingDistance);
    }
    public void StopEnemy()
    {
        navMeshAgent.speed = 0f;
        stop = true;
    }
    public void Move()
    {
        navMeshAgent.speed = original_speed;
        stop = false;
    }
  

}
