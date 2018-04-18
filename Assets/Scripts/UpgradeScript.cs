using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class UpgradeScript : MonoBehaviour
{
  
    public GameObject fireRate;
    public GameObject moveSpeed;
    public GameObject hardenedBullets;
    public GameObject maxLives;
    public GameObject sold;
    public GameObject sold2;
    public GameObject sold3;
    public GameObject sold4;
    public GameObject og;
    public GameObject ogC;
    public GameObject ogH;
    public GameObject ogS;

    public Button fireRateButton;
    public Button moveSpeedButton;
    public Button hardenedBulletsButton;
    public Button maxLivesButton;
    // public Button loginButton;


    public Text printThis;
    //public string Username;
    public Text UsernameText;
    // private string Username;
    // private string Password;
    int playerCurrency;

    public GameObject UserC;

    User currentUser;
    public Text fireCost;
    public Text moveCost;
    public Text hardCost;
    public Text maxLivesCost;

    int move = 5000;
    int hardB = 10000;
    int fire = 200;
    int lives = 20000;

    int moveSel = 0;
    int hardSel = 0;
    int fireSel = 0;
    int livesSel = 0;



    public Color newColor;
    //
    //private string connectionString;

    // Use this for initialization
    void Start()
    {


        currentUser = FindObjectOfType<CurrentUser>().GetComponent<CurrentUser>().currentUser;

        UserC.GetComponent<CurrentUser>().Load();

        UsernameText.text = "Username: " + (currentUser.getName());


        playerCurrency = currentUser.getCurrency();

        //currentUser.set(mov)

        if(playerCurrency < fire || currentUser.getRateOfFire() == 1)
        {
            // Text tet = fireRate.GetComponent<Button>().GetComponent<Text>();

            og.SetActive(false);
            sold.SetActive(true);
            ColorBlock cb = fireRateButton.colors;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            //cb.pressedColor = newColor;
            fireRateButton.colors = cb;

            //og.SetActive(false);
            //sold.SetActive(true);

            //fireRate.GetComponent<Button>().
        }

        if (playerCurrency < move || currentUser.getSpeed() == 1)
        {
            ColorBlock cb = moveSpeedButton.colors;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            moveSpeedButton.colors = cb;

            ogS.SetActive(false);
            sold2.SetActive(true);

        }

        if (playerCurrency < hardB || currentUser.getHard() == 1)
        {
            ColorBlock cb = hardenedBulletsButton.colors;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            hardenedBulletsButton.colors = cb;

            ogH.SetActive(false);
            sold3.SetActive(true);
        }

        if (playerCurrency < lives)
        {
            ColorBlock cb = maxLivesButton.colors;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            maxLivesButton.colors = cb;

            ogC.SetActive(false);
            sold4.SetActive(true);
        }


        printThis.text = "Player Currency: " + playerCurrency.ToString();



        fireRateButton = fireRate.GetComponent<Button>();
        moveSpeedButton = moveSpeed.GetComponent<Button>();
        hardenedBulletsButton = hardenedBullets.GetComponent<Button>();
        maxLivesButton = maxLives.GetComponent<Button>();


        fireCost.text = "Cost: " + fire.ToString();
        moveCost.text = "Cost: " + move.ToString();
        hardCost.text = "Cost: " + hardB.ToString();
        maxLivesCost.text = "Cost: " + lives.ToString();
        
        //


        fireRateButton.onClick.AddListener(SubtractFire);
        moveSpeedButton.onClick.AddListener(SubtractMove);
        hardenedBulletsButton.onClick.AddListener(SubtractHard);
        maxLivesButton.onClick.AddListener(SubtractMaxLives);


       // fireRateButton.
    }

 
    private void SubtractMove()
    {
      //  moveSel = currentUser.getSpeed();

        if ((playerCurrency < move) || currentUser.getSpeed() == 1)
        {
            ColorBlock cb = moveSpeedButton.colors;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            moveSpeedButton.colors = cb;
        //    print("YOU BROKE AS FUCK BOII");
        }
        else
        {
            ColorBlock cb = moveSpeedButton.colors;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            moveSpeedButton.colors = cb;

            moveSel = 1;

            currentUser.setMoveMultiplier(2.0f);

            playerCurrency -= move;

            currentUser.setCurrency(playerCurrency);

            printThis.text = "Player Currency: " + currentUser.getCurrency().ToString();


            currentUser.setSpeed(moveSel);

            UserC.GetComponent<CurrentUser>().Save(currentUser);

            
        }
    }

    private void  SubtractHard()
    {
        if (playerCurrency < hardB || currentUser.getHard() == 1)
        {
            ColorBlock cb = hardenedBulletsButton.colors;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            hardenedBulletsButton.colors = cb;

            print("YOU BROKE AS FUCK BOII");
        }
        else
        {
            ColorBlock cb = hardenedBulletsButton.colors;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            hardenedBulletsButton.colors = cb;


            hardSel = 1;

            playerCurrency -= hardB;

            currentUser.setCurrency(playerCurrency);

            printThis.text = "Player Currency: " + currentUser.getCurrency().ToString();


            currentUser.setHard(hardSel);

            UserC.GetComponent<CurrentUser>().Save(currentUser);
        }
    }

    

    private void SubtractFire()
    {
        if (playerCurrency < fire || currentUser.getRateOfFire() == 1 )
        {
            // enable the text that says we can't buy this 
            print("YOU BROKE AS FUCK BOII");

            ColorBlock cb = fireRateButton.colors;
            cb.normalColor = newColor;
            fireRateButton.colors = cb;
        }
        else
        {
            ColorBlock cb = fireRateButton.colors;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            fireRateButton.colors = cb;

            currentUser.setFireMultiplier(.5f);

            fireSel = 1;
            
            playerCurrency -= fire;

            currentUser.setCurrency(playerCurrency);

            currentUser.setRateOfFire(fireSel);

            printThis.text = "Player Currency: " + currentUser.getCurrency().ToString();

            UserC.GetComponent<CurrentUser>().Save(currentUser);

        }

    }


    private void SubtractMaxLives()
    {
        if (playerCurrency < lives)
        {
           

            print("YOU BROKE AS FUCK BOII");
        }
        //livesSel = PlayerPrefs.GetInt("lives");
        else
        {

            ColorBlock cb = moveSpeedButton.colors;
            cb.normalColor = newColor;
            cb.highlightedColor = newColor;
            moveSpeedButton.colors = cb;

            
            livesSel += 1;

            //PlayerPrefs.SetInt("lives", livesSel);

            playerCurrency -= lives;


            currentUser.setCurrency(playerCurrency);

            printThis.text = "Player Currency: " + currentUser.getCurrency().ToString();

            int max = currentUser.getMaxHealth();

            currentUser.setMaxHealth(livesSel+max);

            UserC.GetComponent<CurrentUser>().Save(currentUser);

        }
    }


}
