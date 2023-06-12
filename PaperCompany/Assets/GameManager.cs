using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI[] timeText;
    public TextMeshProUGUI sliderText;
    public Slider ammoSlider;
    float time = 180;   // 제한 시간 180초
    int min, sec;
    int score;

    void Start()
    {
        timeText[0].text = "03";
        timeText[1].text = "00";
        score = 0;
        SetText();
    }

    public void GetScore(int a)
    {
        score += a;
        SetText();
    }

    public void SetText()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {
        Timer();
        changSlider();
    }

    void Timer()
    {
        time -= Time.deltaTime;

        min = (int)time / 60;
        sec = ((int)time - min * 60) % 60;

        if (min <= 0 && sec <= 0)
        {
            timeText[0].text = 0.ToString();
            timeText[1].text = 0.ToString();
        }

        else
        {
            if (sec >= 60)
            {
                min += 1;
                sec -= 60;
            }
            else
            {
                timeText[0].text = min.ToString();
                timeText[1].text = sec.ToString();
            }
        }
    }
    void changSlider()
    {
        int tmp = (int)ammoSlider.value;
        sliderText.text = tmp.ToString() + "%";
    }
}
