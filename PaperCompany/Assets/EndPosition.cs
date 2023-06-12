using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPosition : MonoBehaviour
{
    public Transform targetPosition; // 특정 위치를 가리키는 트랜스폼

    private void Update()
    {
        // 현재 위치와 특정 위치 간의 거리 계산
        float distance = Vector3.Distance(transform.position, targetPosition.position);

        // 특정 위치에 도달했을 때 게임 종료
        if (distance <= 0.1f) // 원하는 거리로 조정
        {
            GameEnd();
        }
    }

    private void GameEnd()
    {
        // 게임 종료 로직을 작성하세요.
        // 예: 게임 오버 화면 표시, 결과 표시, 리스타트 등
        Debug.Log("게임 종료!");
        // 여기서 게임을 종료하는 코드를 추가할 수 있습니다.
        // 예: Application.Quit();
    }
