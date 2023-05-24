using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour, IDamageable
{
    public float hp;  // ���ʹ� ü��

    public void OnDamage(float damageAmount)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
