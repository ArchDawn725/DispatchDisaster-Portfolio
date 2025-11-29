using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject HospitalToPlace;
    public Controller controller;
    public ZoneBuy2 zoneBuy2;

    public GameObject welcome;
    public GameObject money;
    public GameObject loyalty;
    public GameObject eMSStart;
    public GameObject ambulanceGo;
    public GameObject ambulanceReturn;
    public GameObject ambulanceTip;
    public GameObject zoneBuy;
    public GameObject fireTransition;
    public GameObject fireTip;
    public GameObject finisher;
    public GameObject exitButton;

    public void Start()
    {
        zoneBuy2.GetZoneBuys();
    }

    public void StepOne()
    {
        welcome.SetActive(false);
        money.SetActive(true);
    }

    public void StepTwo()
    {
        money.SetActive(false);
        loyalty.SetActive(true);
    }

    public void StepThree()
    {
        loyalty.SetActive(false);
        eMSStart.SetActive(true);
        HospitalToPlace.SetActive(true);
    }

    public void StepFour()
    {
        eMSStart.SetActive(false);
        ambulanceGo.SetActive(true);
        controller.FindEMSEmergancies();
        controller.GetSpawnPoints();
        controller.spawnEmergancies();
    }

    public void StepFive()
    {
        ambulanceGo.SetActive(false);
        ambulanceReturn.SetActive(true);
    }

    public void StepSix()
    {
        ambulanceReturn.SetActive(false);
        ambulanceTip.SetActive(true);
    }

    public void StepSeven()
    {
        controller.money += 180;
        ambulanceTip.SetActive(false);
        zoneBuy.SetActive(true);
    }

    public void StepEight()
    {
        zoneBuy.SetActive(false);
        fireTransition.SetActive(true);
        controller.money += 1000;
    }

    public void StepNine()
    {
        fireTransition.SetActive(false);
        fireTip.SetActive(true);
    }

    public void StepTen()
    {
        fireTip.SetActive(false);
        finisher.SetActive(true);
    }

    public void ExitButton()
    {
        finisher.SetActive(false);
        exitButton.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
