using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour, IDamageable
{
    public float hp = 100;  // ���ʹ� ü��
    public GameObject GM;

    public void OnDamage(float damageAmount, int score)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            GM.GetComponent<GameManager>().GetScore(score);
        }
    }
}
