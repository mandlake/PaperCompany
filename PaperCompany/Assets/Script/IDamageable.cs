using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� ���� �� �ִ� �������� Ȯ���ϴ� �������̽�
public interface IDamageable
{
    void OnDamage(float damageAmount, int score);
}
