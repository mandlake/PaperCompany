using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour, IDamageable
{
    public float hp = 100;  // 에너미 체력
    public int enemyScore;   // 에너미 점수

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
