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
    private float attackCoolTime = 1.5f;  // 쿨타임을 줄여서 테스트하기 좋게 함

    private void AttackSystem()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // 정중앙에서 Ray 발사
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
        {
            Hp enemyHp = hit.collider.GetComponent<Hp>();

            if (enemyHp != null) // Hp 컴포넌트가 있는지 확인
            {
                Debug.Log("적을 공격했습니다!");
                enemyHp.Damage(damage);
                lastAttack = Time.time; // 마지막 공격 시간 업데이트
            }
            else
            {
                Debug.Log("공격했지만 적의 HP 스크립트를 찾지 못함!");
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

