using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player; // 플레이어 위치
    private float detectionRange = 20f; // 감지 범위
    private float attackRange = 1.5f; // 공격 범위
    private float attackCooldown = 2f; // 공격 쿨타임
    private float lastAttackTime = 0; // 마지막 공격 시간
    public int damage = 5; // 공격 데미지

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distancePlayer = Vector3.Distance(transform.position, player.position);

        if (distancePlayer < detectionRange)
        {
            agent.SetDestination(player.position); // 플레이어 추적
        }

        if (distancePlayer <= attackRange && Time.time - lastAttackTime > attackCooldown)
        {
            Attack();
        }
    }

    void Attack()
    {
        Hp playerHp = player.GetComponent<Hp>(); // 플레이어의 체력(Hp) 가져오기
        if (playerHp != null)
        {
            playerHp.Damage(damage); // 플레이어 체력 깎기
            Debug.Log("적이 플레이어를 공격함! 현재 체력: " + playerHp.currentHp);
        }
        lastAttackTime = Time.time;
    }
}
