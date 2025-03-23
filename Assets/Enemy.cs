using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player; // �÷��̾� ��ġ
    private float detectionRange = 20f; // ���� ����
    private float attackRange = 1.5f; // ���� ����
    private float attackCooldown = 2f; // ���� ��Ÿ��
    private float lastAttackTime = 0; // ������ ���� �ð�
    public int damage = 5; // ���� ������

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
            agent.SetDestination(player.position); // �÷��̾� ����
        }

        if (distancePlayer <= attackRange && Time.time - lastAttackTime > attackCooldown)
        {
            Attack();
        }
    }

    void Attack()
    {
        Hp playerHp = player.GetComponent<Hp>(); // �÷��̾��� ü��(Hp) ��������
        if (playerHp != null)
        {
            playerHp.Damage(damage); // �÷��̾� ü�� ���
            Debug.Log("���� �÷��̾ ������! ���� ü��: " + playerHp.currentHp);
        }
        lastAttackTime = Time.time;
    }
}
