using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerTransferS : MonoBehaviour
{
    public static MultiplayerTransferS instance;

    public bool earnedAllAchievements;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Loaded()
    {
        if (earnedAllAchievements == true)
        {
            Controller1.instance.earnedAllAchievements = true;
        }
    }
}
