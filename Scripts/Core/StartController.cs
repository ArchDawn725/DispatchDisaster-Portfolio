using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public Challenges challenges;
    public MultiplayerTransferS multiplayerTransferS;

    public GameObject extraMenu;

    public GameObject betaTesting;

    public GameObject multiplayer;

    public GameObject freePlay;
    public GameObject sizeController;

    public GameObject achievementsMenu;

    public int beatOnSmallasEMS;
    public int beatOnSmallasFire;
    public int beatOnSmallasPolice;
    public int beatOnSmallas2A;
    public int beatOnSmallas3A;
    public int beatOnMediumasEMS;
    public int beatOnMediumasFire;
    public int beatOnMediumasPolice;
    public int beatOnMediumas2A;
    public int beatOnMediumas3A;
    public int beatOnBigasEMS;
    public int beatOnBigasFire;
    public int beatOnBigasPolice;
    public int beatOnBigas2A;
    public int beatOnBigas3A;
    public int completedSingleHeli;
    public int completedSpotterSurvival;
    public int completedBusTransit;
    public int completedNoMoney;
    public int completedLottery;
    public int completedAllAtOnce;
    public int completedDoubleTrouble;
    public int completedTimed;
    public int completedWaves;
    public int completedUltimate;
    public int multiplayerWins;
    public int totalAchievements;
    public int numberOfAchievements;

    public GameObject ibeatOnSmallasEMS;
    public GameObject ibeatOnSmallasFire;
    public GameObject ibeatOnSmallasPolice;
    public GameObject ibeatOnSmallas2A;
    public GameObject ibeatOnSmallas3A;
    public GameObject ibeatOnMediumasEMS;
    public GameObject ibeatOnMediumasFire;
    public GameObject ibeatOnMediumasPolice;
    public GameObject ibeatOnMediumas2A;
    public GameObject ibeatOnMediumas3A;
    public GameObject ibeatOnBigasEMS;
    public GameObject ibeatOnBigasFire;
    public GameObject ibeatOnBigasPolice;
    public GameObject ibeatOnBigas2A;
    public GameObject ibeatOnBigas3A;
    public GameObject icompletedSingleHeli;
    public GameObject icompletedSpotterSurvival;
    public GameObject icompletedBusTransit;
    public GameObject icompletedNoMoney;
    public GameObject icompletedLottery;
    public GameObject icompletedAllAtOnce;
    public GameObject icompletedDoubleTrouble;
    public GameObject icompletedTimed;
    public GameObject icompletedWaves;
    public GameObject icompletedUltimate;
    public GameObject multiplayerWins1;
    public GameObject multiplayerWins5;
    public GameObject multiplayerWins10;
    public GameObject multiplayerWins15;
    public GameObject multiplayerWins20;
    public GameObject multiplayerWins25;
    public GameObject iearnedAllAchievements;

    public GameObject multiplayerTransfer;

    public GameObject StartMenu;

    public GameObject tutorialMenu;

    public GameObject spotLight;

    public GameObject error;

    public void FreePlay()
    {
        sizeController.SetActive(true);
        ExitMenu();
        freePlay.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        ExitMenu();
        tutorialMenu.SetActive(true);
    }

    public void OpenExtraMenu()
    {
        ExitMenu();
        sizeController.SetActive(true);
        extraMenu.SetActive(true);
    }

    public void Return()
    {
        ExitMenu();
        StartMenu.SetActive(true);
    }

    public void BetaTesting()
    {
        sizeController.SetActive(true);
        Instantiate(betaTesting, transform.position, Quaternion.identity);
        SceneManager.LoadScene(2);
    }

    public void OnMultiplayerButton()
    {
        ExitMenu();
        multiplayer.SetActive(true);
        multiplayerTransfer.SetActive(true);
    }

    public void ExitMenu()
    {
        multiplayer.SetActive(false);
        extraMenu.SetActive(false);
        freePlay.SetActive(false);
        achievementsMenu.SetActive(false);
        StartMenu.SetActive(false);
        multiplayerTransfer.SetActive(false);
        tutorialMenu.SetActive(false);

        spotLight.SetActive(false);
        spotLight.SetActive(true);
    }

    public void AchievementsButton()
    {
        ExitMenu();
        achievementsMenu.SetActive(true);
    }

    public void Error()
    {
        error.SetActive(true);
    }

    public void Accept()
    {
        error.SetActive(false);
    }

    public void Start()
    {
        beatOnSmallasEMS = PlayerPrefs.GetInt("beatOnSmallasEMS");
        if (beatOnSmallasEMS >= 1)
        {
            ibeatOnSmallasEMS.SetActive(true);
            totalAchievements++;
        }
        beatOnSmallasFire = PlayerPrefs.GetInt("beatOnSmallasFire");
        if (beatOnSmallasFire >= 1)
        {
            ibeatOnSmallasFire.SetActive(true);
            totalAchievements++;
        }
        beatOnSmallasPolice = PlayerPrefs.GetInt("beatOnSmallasPolice");
        if (beatOnSmallasPolice >= 1)
        {
            ibeatOnSmallasPolice.SetActive(true);
            totalAchievements++;
        }
        beatOnSmallas2A = PlayerPrefs.GetInt("beatOnSmallas2A");
        if (beatOnSmallas2A >= 1)
        {
            ibeatOnSmallas2A.SetActive(true);
            totalAchievements++;
        }
        beatOnSmallas3A = PlayerPrefs.GetInt("beatOnSmallas3A");
        if (beatOnSmallas3A >= 1)
        {
            ibeatOnSmallas3A.SetActive(true);
            totalAchievements++;
        }

        beatOnMediumasEMS = PlayerPrefs.GetInt("beatOnMediumasEMS");
        if (beatOnMediumasEMS >= 1)
        {
            ibeatOnMediumasEMS.SetActive(true);
            totalAchievements++;
        }
        beatOnMediumasFire = PlayerPrefs.GetInt("beatOnMediumasFire");
        if (beatOnMediumasFire >= 1)
        {
            ibeatOnMediumasFire.SetActive(true);
            totalAchievements++;
        }
        beatOnMediumasPolice = PlayerPrefs.GetInt("beatOnMediumasPolice");
        if (beatOnMediumasPolice >= 1)
        {
            ibeatOnMediumasPolice.SetActive(true);
            totalAchievements++;
        }
        beatOnMediumas2A = PlayerPrefs.GetInt("beatOnMediumas2A");
        if (beatOnMediumas2A >= 1)
        {
            ibeatOnMediumas2A.SetActive(true);
            totalAchievements++;
        }
        beatOnMediumas3A = PlayerPrefs.GetInt("beatOnMediumas3A");
        if (beatOnMediumas3A >= 1)
        {
            ibeatOnMediumas3A.SetActive(true);
            totalAchievements++;
        }

        beatOnBigasEMS = PlayerPrefs.GetInt("beatOnBigasEMS");
        if (beatOnBigasEMS >= 1)
        {
            ibeatOnBigasEMS.SetActive(true);
            totalAchievements++;
        }
        beatOnBigasFire = PlayerPrefs.GetInt("beatOnBigasFire");
        if (beatOnBigasFire >= 1)
        {
            ibeatOnBigasFire.SetActive(true);
            totalAchievements++;
        }
        beatOnBigasPolice = PlayerPrefs.GetInt("beatOnBigasPolice");
        if (beatOnBigasPolice >= 1)
        {
            ibeatOnBigasPolice.SetActive(true);
            totalAchievements++;
        }
        beatOnBigas2A = PlayerPrefs.GetInt("beatOnBigas2A");
        if (beatOnBigas2A >= 1)
        {
            ibeatOnBigas2A.SetActive(true);
            totalAchievements++;
        }
        beatOnBigas3A = PlayerPrefs.GetInt("beatOnBigas3A");
        if (beatOnBigas3A >= 1)
        {
            ibeatOnBigas3A.SetActive(true);
            totalAchievements++;
        }

        completedSingleHeli = PlayerPrefs.GetInt("completedSingleHeli");
        if (completedSingleHeli >= 1)
        {
            icompletedSingleHeli.SetActive(true);
            totalAchievements++;
        }
        completedSpotterSurvival = PlayerPrefs.GetInt("completedSpotterSurvival");
        if (completedSpotterSurvival >= 1)
        {
            icompletedSpotterSurvival.SetActive(true);
            totalAchievements++;
        }
        completedBusTransit = PlayerPrefs.GetInt("completedBusTransit");
        if (completedBusTransit >= 1)
        {
            icompletedBusTransit.SetActive(true);
            totalAchievements++;
        }
        completedNoMoney = PlayerPrefs.GetInt("completedNoMoney");
        if (completedNoMoney >= 1)
        {
            icompletedNoMoney.SetActive(true);
            totalAchievements++;
        }
        completedLottery = PlayerPrefs.GetInt("completedLottery");
        if (completedLottery >= 1)
        {
            icompletedLottery.SetActive(true);
            totalAchievements++;
        }
        completedAllAtOnce = PlayerPrefs.GetInt("completedAllAtOnce");
        if (completedAllAtOnce >= 1)
        {
            icompletedAllAtOnce.SetActive(true);
            totalAchievements++;
        }
        completedDoubleTrouble = PlayerPrefs.GetInt("completedDoubleTrouble");
        if (completedDoubleTrouble >= 1)
        {
            icompletedDoubleTrouble.SetActive(true);
            totalAchievements++;
        }
        completedTimed = PlayerPrefs.GetInt("completedTimed");
        if (completedTimed >= 1)
        {
            icompletedTimed.SetActive(true);
            totalAchievements++;
        }
        completedWaves = PlayerPrefs.GetInt("completedWaves");
        if (completedWaves >= 1)
        {
            icompletedWaves.SetActive(true);
            totalAchievements++;
        }
        completedUltimate = PlayerPrefs.GetInt("completedUltimate");
        if (completedUltimate >= 1)
        {
            icompletedUltimate.SetActive(true);
            totalAchievements++;
        }


        multiplayerWins = PlayerPrefs.GetInt("multiplayerWins");
        if (multiplayerWins >= 1)
        {
            if (multiplayerWins >= 1)
            {
                multiplayerWins1.SetActive(true);
                totalAchievements++;
            }
            if (multiplayerWins >= 5)
            {
                multiplayerWins5.SetActive(true);
                totalAchievements++;
            }
            if (multiplayerWins >= 10)
            {
                multiplayerWins10.SetActive(true);
                totalAchievements++;
            }
            if (multiplayerWins >= 15)
            {
                multiplayerWins15.SetActive(true);
                totalAchievements++;
            }
            if (multiplayerWins >= 20)
            {
                multiplayerWins20.SetActive(true);
                totalAchievements++;
            }
            if (multiplayerWins >= 25)
            {
                multiplayerWins25.SetActive(true);
                totalAchievements++;
            }

        }

        if (totalAchievements == numberOfAchievements)
        {
            iearnedAllAchievements.SetActive(true);
            challenges.earnedAllAchievements = true;
            multiplayerTransferS.earnedAllAchievements = true;
        }
    }
}
