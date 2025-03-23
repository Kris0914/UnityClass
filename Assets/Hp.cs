using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public int maxHp = 100; // �ִ� ü��
    public int currentHp; // ���� ü��

    void Start()
    {
        currentHp = maxHp; // ������ �� ü���� �ִ� ü������ ����
    }

    public void Damage(int damage)
    {
        currentHp -= damage; // ü�� ����
        Debug.Log(gameObject.name + " ü��: " + currentHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " ����!");
        gameObject.SetActive(false); // ����ϸ� ������Ʈ ��Ȱ��ȭ
    }
}
