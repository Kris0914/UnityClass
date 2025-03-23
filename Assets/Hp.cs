using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public int maxHp = 100; // 최대 체력
    public int currentHp; // 현재 체력

    void Start()
    {
        currentHp = maxHp; // 시작할 때 체력을 최대 체력으로 설정
    }

    public void Damage(int damage)
    {
        currentHp -= damage; // 체력 깎임
        Debug.Log(gameObject.name + " 체력: " + currentHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " 죽음!");
        gameObject.SetActive(false); // 사망하면 오브젝트 비활성화
    }
}
