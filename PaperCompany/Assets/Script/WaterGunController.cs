using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class WaterGunController : MonoBehaviour
{
    public Transform trigger;

    public InputActionProperty A;

    public Transform streamTrans;
    public ParticleSystem stream;
    public ParticleSystem.EmissionModule streamEM;

    public Transform sprayTrans;
    public ParticleSystem spray;
    public ParticleSystem.EmissionModule sprayEM;

    public Transform streamSprayTrans;
    public ParticleSystem streamSpray;
    public ParticleSystem.EmissionModule streamSprayEM;

    public Transform splash1Trans;
    public ParticleSystem splash1;
    public ParticleSystem.EmissionModule splash1EM;

    public Transform splash2Trans;
    public ParticleSystem splash2;
    public ParticleSystem.EmissionModule splash2EM;

    public Vector3 triggerPressPos;
    public Vector3 triggerPos;
    public bool squirtStatus;
    public float pressure;
    public float triggerPressSpeed;
    public float splashSize;
    public float ReloadTime = 2.0f; // 재장전 시간
    private float maxAmmo;  // 최대 탄약
    public float currentAmmo;  // 현재 탄약
    public float ammoDepletionRate;    // 탄약 감소율
    private enum State { Ready, Empty, Reloading };   // 발사 가능, 탄창 없음, 재장전
    private State currentState = State.Empty; // 현재 총의 상태

    public Slider ammoBar;

    //오디오
    AudioSource audioSrc;
    public AudioClip spraySnd;  // 발사 소리
    public AudioClip reloadSnd; // 재장전 소리

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        trigger = transform.Find("Trigger");

        streamTrans = transform.Find("Stream");
        stream = streamTrans.GetComponent<ParticleSystem>();
        streamEM = stream.emission;
        streamEM.enabled = false;

        sprayTrans = transform.Find("Spray");
        spray = sprayTrans.GetComponent<ParticleSystem>();
        sprayEM = spray.emission;
        sprayEM.enabled = false;

        streamSprayTrans = transform.Find("StreamSpray");
        streamSpray = streamSprayTrans.GetComponent<ParticleSystem>();
        streamSprayEM = streamSpray.emission;
        streamSprayEM.enabled = false;

        splash1Trans = transform.Find("Stream/Splash1");
        splash1 = splash1Trans.GetComponent<ParticleSystem>();
        splash1EM = splash1.emission;

        splash2Trans = transform.Find("Stream/Splash2");
        splash2 = splash2Trans.GetComponent<ParticleSystem>();
        splash2EM = splash2.emission;

        triggerPos = trigger.localPosition;
        triggerPressPos = triggerPos;
        triggerPressPos.z += 0.03f;
        triggerPressSpeed = 0.55f;

        pressure = 10;
        currentState = State.Ready; // 발사 가능
        maxAmmo = 100.0f;
        currentAmmo = 100.0f;
        //ammoDepletionRate = 1f;
    }
    void Update()
    {
        if (A.action.WasPressedThisFrame())
        {
            Debug.Log("Reload");
            Reload();
        }

        // 물 탱크 잔량 표시
        ammoBar.value = currentAmmo;
        if (currentState == State.Ready && squirtStatus)
        {
            currentAmmo -= ammoDepletionRate * Time.deltaTime;
            if (currentAmmo <= 0)
            {
                currentState = State.Empty;
                ParticleOff();
            }
        }
    }

    // 발사
    public void Squirt()
    {
        //파티클 재생
        if (streamEM.enabled == false)
        {
            streamEM.enabled = true;
            sprayEM.enabled = true;
            streamSprayEM.enabled = true;
        }

        squirtStatus = true;

        var streamRate = streamEM.rate;
        var sprayRate = sprayEM.rate;
        var streamSprayRate = streamSprayEM.rate;
        var streamSprayShape = streamSpray.shape;

        float streamColorAlpha = (pressure / 15);
        Vector4 streamColor = new Vector4(255, 255, 255, streamColorAlpha);

        stream.startSpeed = pressure * 2;
        stream.startSize = (pressure / 10);
        stream.startColor = streamColor;
        streamRate.constantMax = pressure * 50;

        spray.startSpeed = pressure / 8;
        spray.startSize = (pressure / 5);
        sprayRate.constantMax = pressure * 5;

        streamSpray.startSpeed = pressure * 2;
        streamSpray.startSize = (pressure / 100);
        streamSprayRate.constantMax = pressure * 10;
        streamSprayShape.angle = (pressure / 100);

        splash1.startSize = pressure / 6;
        splash1.startColor = new Vector4(splash1.startColor.r, splash1.startColor.g, splash1.startColor.b, streamColorAlpha);

        splash2.startSize = Random.Range(0.01f, (pressure / 40));
        splash2.startColor = new Vector4(splash2.startColor.r, splash2.startColor.g, splash2.startColor.b, streamColorAlpha);

        //play sound
        if (!audioSrc.enabled || !audioSrc.isPlaying)
        {
            audioSrc.enabled = true;
            print("play Audio!");
            audioSrc.PlayOneShot(spraySnd);
        }
    }

    // 재장전 시도
    public void Reload()
    {
        if (currentState != State.Reloading)
        {
            StartCoroutine(ReloadRoutine());
        }
    }

    // 실제 재장전 처리
    private IEnumerator ReloadRoutine()
    {
        currentState = State.Reloading;
        if (!audioSrc.enabled || !audioSrc.isPlaying)
        {
            audioSrc.enabled = true;
            print("play Audio!");
            audioSrc.PlayOneShot(reloadSnd);
        }

        yield return new WaitForSeconds(ReloadTime);    // 재장전 시간만큼 처리를 쉰다

        currentAmmo = maxAmmo;
        currentState = State.Ready;
    }

    // 발사 종료
    public void ShutOff()
    {
        ParticleOff();
    }

    public void PullTrigger()
    {
        trigger.localPosition = Vector3.Lerp(triggerPos, triggerPressPos, (Time.time * triggerPressSpeed));
        if (currentState == State.Ready)
        {
            Squirt();
        }
    }

    public void ReleaseTrigger()
    {
        trigger.localPosition = Vector3.Lerp(triggerPressPos, triggerPos, (Time.time * triggerPressSpeed));
        if (squirtStatus)
        {
            ShutOff();
        }
    }

    public void ParticleOff()
    {
        squirtStatus = false;
        streamEM.enabled = false;
        sprayEM.enabled = false;
        streamSprayEM.enabled = false;
        audioSrc.enabled = false;
    }
}
