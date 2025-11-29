using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Challenges : MonoBehaviour
{
    public SizeController sizeCon;

    public GameObject ControllerModule;
    public Controller controller;
    public ChallengeCommander challengeCommander;

    public bool earnedAllAchievements;

    public WorldGeneration worldGen;
    public GameObject WorldGenerator;

    public bool nothingPressed = true;
    public bool singleHeliChallenge;
    public bool spotterSurvivalChallenge;
    public bool busTransitChallenge;
    public bool noMoneyChallenge;
    public bool lotteryChallenge;
    public bool allAtOnceChallenge;
    public bool doubleTroubleChallenge;
    public bool timedChallenge;
    public bool wavesChallenge;
    public bool ultimateChallenge;


    public void Loaded()
    {
        ControllerModule = GameObject.Find("Controller Module");
        controller = ControllerModule.GetComponent("Controller") as Controller;
        challengeCommander = ControllerModule.GetComponent("ChallengeCommander") as ChallengeCommander;

        WorldGenerator = GameObject.Find("WorldGenerator");
        worldGen = WorldGenerator.GetComponent("WorldGeneration") as WorldGeneration;

        if (earnedAllAchievements == true)
        {
            controller.earnedAllAchievements = true;
        }

        if (nothingPressed == true)
        {
            sizeCon.Loaded();
        }
        if (nothingPressed == false)
        {
            controller.challengeMode = true;

            if (singleHeliChallenge == true)
            {
                challengeCommander.singleHeliChallenge = true;
                challengeCommander.SingleHeliChallenge();
                controller.singleHeliChallenge = true;
            }
            if (spotterSurvivalChallenge == true)
            {
                challengeCommander.spotterSurvivalChallenge = true;
                challengeCommander.SpotterSurvivalChallenge();
                controller.spotterSurvivalChallenge = true;
            }
            if (busTransitChallenge == true)
            {
                challengeCommander.busTransitChallenge = true;
                challengeCommander.BusTransitChallenge();
                controller.busTransitChallenge = true;
            }
            if (noMoneyChallenge == true)
            {
                challengeCommander.noMoneyChallenge = true;
                challengeCommander.NoMoneyChallenge();
                controller.noMoneyChallenge = true;
            }
            if (lotteryChallenge == true)
            {
                challengeCommander.lotteryChallenge = true;
                challengeCommander.LotteryChallenge();
                controller.lotteryChallenge = true;
            }
            if (allAtOnceChallenge == true)
            {
                challengeCommander.allAtOnceChallenge = true;
                challengeCommander.AllAtOnceChallenge();
                controller.allAtOnceChallenge = true;
            }
            if (doubleTroubleChallenge == true)
            {
                challengeCommander.doubleTroubleChallenge = true;
                challengeCommander.DoubleTroubleChallenge();
                controller.doubleTroubleChallenge = true;
            }
            if (timedChallenge == true)
            {
                challengeCommander.timedChallenge = true;
                challengeCommander.TimedChallenge();
                controller.timedChallenge = true;
            }
            if (wavesChallenge == true)
            {
                challengeCommander.wavesChallenge = true;
                challengeCommander.WavesChallenge();
                controller.wavesChallenge = true;
            }
            if (ultimateChallenge == true)
            {
                challengeCommander.ultimateChallenge = true;
                challengeCommander.UltimateChallenge();
                controller.ultimateChallenge = true;
            }
            sizeCon.Loaded();
        }

        controller.ChangeColor();
        Destroy(this.gameObject, 2);
    }

    public void SingleHeliCButton()
    {
        nothingPressed = false;
        singleHeliChallenge = true;
        sizeCon.small = true;
        SceneManager.LoadScene(2);
    }
    public void SpotterSurvival()
    {
        nothingPressed = false;
        spotterSurvivalChallenge = true;
        sizeCon.large = true;
        SceneManager.LoadScene(2);
    }
    public void BusTransit()
    {
        nothingPressed = false;
        busTransitChallenge = true;
        sizeCon.large = true;
        SceneManager.LoadScene(2);
    }
    public void NoMoney()
    {
        nothingPressed = false;
        noMoneyChallenge = true;
        sizeCon.small = true;
        SceneManager.LoadScene(2);
    }
    public void Lottery()
    {
        nothingPressed = false;
        lotteryChallenge = true;
        sizeCon.medium = true;
        SceneManager.LoadScene(2);
    }
    public void AllAtOnce()
    {
        nothingPressed = false;
        allAtOnceChallenge = true;
        sizeCon.medium = true;
        SceneManager.LoadScene(2);
    }
    public void DoubleTrouble()
    {
        nothingPressed = false;
        doubleTroubleChallenge = true;
        sizeCon.medium = true;
        SceneManager.LoadScene(2);
    }
    public void Timed()
    {
        nothingPressed = false;
        timedChallenge = true;
        sizeCon.small = true;
        SceneManager.LoadScene(2);
    }
    public void Waves()
    {
        nothingPressed = false;
        wavesChallenge = true;
        sizeCon.medium = true;
        SceneManager.LoadScene(2);
    }
    public void Ultimate()
    {
        nothingPressed = false;
        ultimateChallenge = true;
        sizeCon.large = true;
        SceneManager.LoadScene(2);
    }
}
