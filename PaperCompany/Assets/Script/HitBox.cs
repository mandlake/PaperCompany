using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour, IDamageable
{
    public float hp = 100;  // ���ʹ� ü��
    public int enemyScore;   // ���ʹ� ����

    public void OnDamage(float damageAmount, int score)
    {
        hp -= damageAmount;
        enemyScore += score;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
