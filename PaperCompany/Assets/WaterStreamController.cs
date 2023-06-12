using UnityEngine;
using System.Collections;

public class WaterStreamController : MonoBehaviour
{
    public float force;
    private WaterGunController squirt;
    int score;

    void Start()
    {
        squirt = GetComponentInParent<WaterGunController>();
    }

    // Update is called once per frame
    void Update()
    {
        force = (squirt.pressure / 20);
    }

    void OnParticleCollision(GameObject hitObj)
    {
        IDamageable target = hitObj.GetComponent<IDamageable>();
        if (target != null)
        {
            if (hitObj.gameObject.layer == 10)  // 적이 토끼일 때
            {
                score = 10;
            }
            target.OnDamage(10, score);
        }
    }
}