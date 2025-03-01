using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameStart : MonoBehaviour
{
    int numOFRestart = 0;
    public AdMobController mobController;
    public Events ev;
    private void Start()
    {
        
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        GameObject.FindGameObjectWithTag("Timer").GetComponent<TimeCalc>().textMeshProUGUI.text = highScore+" meter";
        
        Debug.Log("Loaded High Score: " + highScore);

        numOFRestart = PlayerPrefs.GetInt("numOfRestart", 0);
    }
    public void GameShuru()
    {
        GameObject[] wall = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] res= GameObject.FindGameObjectsWithTag("Respawn");
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player22");
        GameObject[] env = GameObject.FindGameObjectsWithTag("Environment");
        GameObject.FindGameObjectWithTag("Timer").GetComponent<TimeCalc>().Reseto();
        GameObject.FindGameObjectWithTag("Timer").GetComponent<TimeCalc>().enabled = true;
        
        foreach (var i in wall)
        {
            i.GetComponent<Plane>().enabled=true;
        }
        foreach (var i in res)
        {
            i.GetComponent<Plane>().enabled = true;
        }
        foreach (var i in env)
        {
            if(i.GetComponent<Plane>() != null)
            i.GetComponent<Plane>().enabled = true;
            else
            {
                i.GetComponent<LandMove>().enabled = true;
            }
        }
        foreach (var i in player)
        {
            i.GetComponent<Animator>().enabled=true;
        }



    }


    public void GameShuruInter()
    {

        if (numOFRestart % 3 == 0)
        {
            mobController.ShowInterstitialAd();
        }
        numOFRestart++;

        PlayerPrefs.SetInt("numOfRestart", numOFRestart);
        PlayerPrefs.Save();

        numOFRestart--;
        if(numOFRestart % 3 != 0)
        ev.Play();
    }



    public void GameShuruAfterAD()
    {
        GameObject[] wall = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] res = GameObject.FindGameObjectsWithTag("Respawn");
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player22");
        GameObject[] env = GameObject.FindGameObjectsWithTag("Environment");


        foreach (var i in wall)
        {
            i.GetComponent<Plane>().enabled = true;
        }
        foreach (var i in res)
        {
            i.GetComponent<Plane>().enabled = true;
        }
        foreach (var i in env)
        {
            if (i.GetComponent<Plane>() != null)
                i.GetComponent<Plane>().enabled = true;
            else
            {
                i.GetComponent<LandMove>().enabled = true;
            }
        }
        foreach (var i in player)
        {
            i.GetComponent<Animator>().enabled = true;
        }

    }
}
