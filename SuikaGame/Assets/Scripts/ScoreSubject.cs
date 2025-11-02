using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSubject
{
    private int score = 0;
    private Action<int> scoreChanged;

    public int Score
    {
        get { return score; }
        set
        {
            if (score != value)
            {
                score = value;
                NotifyObservers(score);
            }
        }
    }

    public void AddScoreObserver(Action<int> observer) // 추가
    {
        scoreChanged += observer;
    }

    public void RemoveScoreObserver(Action<int> observer) // 제거
    {
        scoreChanged -= observer;
    }

    private void NotifyObservers(int newScore) // 실행
    {
        if (scoreChanged != null)
            scoreChanged(newScore);
    }

    public void IncreaseScore(int point) // 점수 변동
    {
        Score += point;
    }
}