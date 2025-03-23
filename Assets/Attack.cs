using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 5;
    private float attackRange = 10f;
    public LayerMask enemyLayer;
    public Camera cam;

    private float lastAttack = 0;
    private float attackCoolTime = 1.5f;  // ��Ÿ���� �ٿ��� �׽�Ʈ�ϱ� ���� ��

    private void AttackSystem()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // ���߾ӿ��� Ray �߻�
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
        {
            Hp enemyHp = hit.collider.GetComponent<Hp>();

            if (enemyHp != null) // Hp ������Ʈ�� �ִ��� Ȯ��
            {
                Debug.Log("���� �����߽��ϴ�!");
                enemyHp.Damage(damage);
                lastAttack = Time.time; // ������ ���� �ð� ������Ʈ
            }
            else
            {
                Debug.Log("���������� ���� HP ��ũ��Ʈ�� ã�� ����!");
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttack >= attackCoolTime)
        {
            AttackSystem();
        }
    }
}

