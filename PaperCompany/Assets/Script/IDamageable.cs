using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대미지를 받을 수 있는 존재인지 확인하는 인터페이스
public interface IDamageable
{
    void OnDamage(float damageAmount, int score);
}
