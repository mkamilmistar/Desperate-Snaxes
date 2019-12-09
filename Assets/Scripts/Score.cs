using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public static class Score
{
    public static event EventHandler OnHighscoreChanged;
    public static int score;
    public static void InitializeStatic()
    {
        OnHighscoreChanged = null;
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 100;
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }

    public static bool TrySetNewHighscore()
    {
        return TrySetNewHighscore(score);
    }
    public static bool TrySetNewHighscore(int score)
    {
        int highscore = GetHighScore();
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            if (OnHighscoreChanged != null) OnHighscoreChanged(null, EventArgs.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }

    internal static int GetScore(object score)
    {
        throw new NotImplementedException();
    }
}
