using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Fire : MonoBehaviour
{
    public ParticleSystem bullet;
    //public Transform barrel;    // �Ѿ� �߻� ����
    //public float bulletSpeed;   // �Ѿ� �ӵ�
    public int damage;  // �����
    public Animator Ani;  // �ִϸ��̼�
    public float ReloadTime = 2.0f; // ������ �ð�
    public float MaxAmmo = 100.0f;  // �ִ� ��(źâ) ��
    public float FireDistance;  // �����Ÿ�

    private enum State {Ready, Empty, Reloading};   // �߻� ����, źâ ����, ������
    private State CurrentState = State.Empty; // ���� ���� ����
    private float CurrentAmmo = 0.0f;  // ���� ���� ��(źâ) ��

    /*
    public AudioClip //
    public AudioSource  //
    */

    void Start()
    {
        CurrentAmmo = 100;  // źâ 100���� ����
        CurrentState = State.Ready; // �߻� ����

        UpdateUI(); // UI�� ����
    }

    // �߻� ó���� �õ��ϴ� �Լ�
    public void FireBullet()
    {
        if (CurrentState == State.Ready)
        {
            ShotBullet();
            UpdateUI();
        }
    }

    // ���� �߻� ó�� �Լ�
    private void ShotBullet()
    {
        bullet.Play();
        
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        // �Ѿ��� �߻��ϴ� �������� ����
        Vector3 bulletDirection = transform.forward;
        // �Ѿ� �߻� �� ���� �ð��� ������ ��ƼŬ �ý����� ��Ȱ��ȭ
        StartCoroutine(StopParticleAfterDelay());

        /*
        RaycastHit Hit; // �浹 ���� �����̳�
        
        // �Ѿ��� ���� ��(ó�������� �ѱ� ��ġ + �ѱ� ��ġ�� ���� ���� * �����Ÿ�)
        Vector3 HitPosition = barrel.position + barrel.forward * FireDistance;
        if (Physics.Raycast(barrel.position, barrel.forward, out Hit, FireDistance))
        {
            // ������ IDamagable�� ����������,
            // ������ OnDamage �Լ��� ������Ѽ� ������� ����ش�.
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
        yield return new WaitForSeconds(1f); // ��ƼŬ �ý����� ����� �ð� (��)

        // ��ƼŬ �ý����� ��Ȱ��ȭ��ŵ�ϴ�.
        bullet.Stop();
    }

    private void UpdateUI()
    {
        
    }

    // �������� �õ�
    public void Reload()
    {
        if (CurrentState != State.Reloading)
        {
            StartCoroutine(ReloadRoutine());
        }
    }

    // ���� ������ ó��
    private IEnumerator ReloadRoutine()
    {
        CurrentState = State.Reloading;

        // ������ ���� �߰�

        UpdateUI();

        yield return new WaitForSeconds(ReloadTime);    // ������ �ð���ŭ ó���� ����

        CurrentAmmo = MaxAmmo;
        CurrentState = State.Ready;
        UpdateUI();
    }
}
