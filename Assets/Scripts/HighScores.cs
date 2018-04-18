using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


    public class HighScores : MonoBehaviour {

    // private string connectionString;

    private static List<User> highScores;
    // private List<User>  = new List<User>();

    public GameObject scorePrefab;

    public Transform scoreParent;

    public int topRanks;

   //public Text printThis;

  //  public Text printMe;

    public GameObject UserC;

    int playerCurrency;
    // Use this for initialization
    void Start ()
    {

        highScores = new List<User>();

        UserC.GetComponent<CurrentUser>().Load();

        UserC.GetComponent<CurrentUser>().savedUsers.Sort();

        // CurrentUser.Load();

        int count = UserC.GetComponent<CurrentUser>().savedUsers.Count;



      //  Load();


        // this prints all of the users in the file created on the platform
       // LoginScript.savedUsers.ForEach(user => print(user.getName()));



        // LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));


        // playerCurrency = (FindObjectOfType<CurrentUser>().currentUser.getCurrency());

        UserC.GetComponent<CurrentUser>().currentUser.getHighScore();
      //  UserC.currentUser.getHighScore();

        // printMe.text = playerCurrency.ToString();



        //  LoginScript.savedUsers.ForEach(print);

       // int count = LoginScript.savedUsers.Count;


        

        if (count < topRanks)
            topRanks = count;

        for (int i = 0; i < topRanks; i++)
        {
            GameObject tempObject = Instantiate(scorePrefab);

            print("User name: " + UserC.GetComponent<CurrentUser>().savedUsers[i].getName());

            if (UserC.GetComponent<CurrentUser>().savedUsers[i].getName() == null)
                continue;
            User tempScore = UserC.GetComponent<CurrentUser>().savedUsers[i];

            tempObject.GetComponent<HighScoreScrript>().SetScore(tempScore.getName(), tempScore.getHighScore().ToString(), "#" + (i + 1).ToString());

            tempObject.transform.SetParent(scoreParent);

            tempObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        }


        // this game object stores the instance of the current user 
        //print(GameObject.FindObjectOfType<CurrentUser>().currentUser.getName());

      //  printThis.text = (FindObjectOfType<CurrentUser>().currentUser.getName());

        // LoginScript.savedUsers.Sort();


        //FindObjectOfType<Cu>().currentUser.setCurrency(50000);

        // User.getName();

    }


    
    // Update is called once per frame
    void Update ()
    {

		
	}


       

    }

   
     


  
