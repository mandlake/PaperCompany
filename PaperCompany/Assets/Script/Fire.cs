using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Fire : MonoBehaviour
{
    public ParticleSystem bullet;
    //public Transform barrel;    // 총알 발사 지점
    //public float bulletSpeed;   // 총알 속도
    public int damage;  // 대미지
    public Animator Ani;  // 애니메이션
    public float ReloadTime = 2.0f; // 재장전 시간
    public float MaxAmmo = 100.0f;  // 최대 물(탄창) 양
    public float FireDistance;  // 사정거리

    private enum State {Ready, Empty, Reloading};   // 발사 가능, 탄창 없음, 재장전
    private State CurrentState = State.Empty; // 현재 총의 상태
    private float CurrentAmmo = 0.0f;  // 현재 남은 물(탄창) 양

    /*
    public AudioClip //
    public AudioSource  //
    */

    void Start()
    {
        CurrentAmmo = 100;  // 탄창 100에서 시작
        CurrentState = State.Ready; // 발사 가능

        UpdateUI(); // UI를 갱신
    }

    // 발사 처리를 시도하는 함수
    public void FireBullet()
    {
        if (CurrentState == State.Ready)
        {
            ShotBullet();
            UpdateUI();
        }
    }

    // 실제 발사 처리 함수
    private void ShotBullet()
    {
        bullet.Play();
        
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        // 총알을 발사하는 방향으로 설정
        Vector3 bulletDirection = transform.forward;
        // 총알 발사 후 일정 시간이 지나면 파티클 시스템을 비활성화
        StartCoroutine(StopParticleAfterDelay());

        /*
        RaycastHit Hit; // 충돌 정보 컨테이너
        
        // 총알이 맞은 곳(처음값으로 총구 위치 + 총구 위치로 앞쪽 방향 * 사정거리)
        Vector3 HitPosition = barrel.position + barrel.forward * FireDistance;
        if (Physics.Raycast(barrel.position, barrel.forward, out Hit, FireDistance))
        {
            // 상대방이 IDamagable로 가져와지면,
            // 상대방의 OnDamage 함수를 실행시켜서 대미지를 쥐어준다.
            IDamageable target = Hit.collider.GetComponent<IDamageable>();

            if (target != null)
            {
                target.OnDamage(damage);
            }
        }

        CurrentAmmo -= 0.1f;
        if (CurrentAmmo <= 0)
        {
            CurrentState = State.Empty;
        }
        */
    }
    private IEnumerator StopParticleAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 파티클 시스템이 재생될 시간 (초)

        // 파티클 시스템을 비활성화시킵니다.
        bullet.Stop();
    }

    private void UpdateUI()
    {
        
    }

    // 재장전을 시도
    public void Reload()
    {
        if (CurrentState != State.Reloading)
        {
            StartCoroutine(ReloadRoutine());
        }
    }

    // 실제 재장전 처리
    private IEnumerator ReloadRoutine()
    {
        CurrentState = State.Reloading;

        // 재장전 사운드 추가

        UpdateUI();

        yield return new WaitForSeconds(ReloadTime);    // 재장전 시간만큼 처리를 쉰다

        CurrentAmmo = MaxAmmo;
        CurrentState = State.Ready;
        UpdateUI();
    }
}
