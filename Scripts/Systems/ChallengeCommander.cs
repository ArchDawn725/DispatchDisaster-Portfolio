using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeCommander : MonoBehaviour
{
    public Controller controller;

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

    public GameObject fire;
    public GameObject police;
    public GameObject fireBuy;
    public GameObject policeBuy;
    public GameObject van;
    public GameObject ambulance;
    public GameObject paraambulance;
    public GameObject lifeflight;

    public GameObject ems;
    public GameObject emsBuy;
    public GameObject rescue;
    public GameObject truck;
    public GameObject ladder;
    public GameObject station;

    public GameObject patrol;
    public GameObject trooper;
    public GameObject swat;
    public GameObject pStation;

    public ZoneBuy2 zoneBuy;



    public void Update()
    {
        if (singleHeliChallenge == true)
        {
            if (controller.unitNmbers > 0)
            {
                lifeflight.SetActive(false);
            }
        }
    }

    public void SingleHeliChallenge()
    {
        fire.SetActive(false);
        police.SetActive(false);
        fireBuy.SetActive(false);
        policeBuy.SetActive(false);
        van.SetActive(false);
        ambulance.SetActive(false);
        paraambulance.SetActive(false);
    }

    public void SpotterSurvivalChallenge()
    {
        zoneBuy.challengeMode = true;
        ems.SetActive(false);
        emsBuy.SetActive(false);
        fire.SetActive(false);
        fireBuy.SetActive(false);
        patrol.SetActive(false);
        trooper.SetActive(false);
        swat.SetActive(false);
        pStation.SetActive(false);
    }

    public void BusTransitChallenge()
    {
        ems.SetActive(false);
        police.SetActive(false);
        emsBuy.SetActive(false);
        policeBuy.SetActive(false);
        rescue.SetActive(false);
        truck.SetActive(false);
        ladder.SetActive(false);
        station.SetActive(false);
    }

    public void NoMoneyChallenge()
    {
        controller.money = 0;
    }

    public void LotteryChallenge()
    {
        controller.money = 10000;
    }

    public void AllAtOnceChallenge()
    {
        zoneBuy.challengeMode = true;
    }

    public void DoubleTroubleChallenge()
    {

    }

    public void TimedChallenge()
    {

    }

    public void WavesChallenge()
    {

    }

    public void UltimateChallenge()
    {
        zoneBuy.challengeMode = true;
    }


}
