using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRosterScript : MonoBehaviour
{

    public GameObject[]  buttonList;
    public GameObject middleImage;

    public int playerSelection = -1;
    public int rosterNumber = 0;

    public TeamManagerScript teamManager;

    public GameObject[] teamRosterSlots;

    public GameObject rosterScreen, overviewBattlePrompt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RosterButtonPush_One()
    {
        foreach (GameObject x in buttonList)
        {
            Color color = x.GetComponent<Image>().color;
            color.a = 1f;
            x.GetComponent<Image>().color = color;
        }
        Color buttonColor = buttonList[0].GetComponent<Image>().color;
        buttonColor.a = 20f;
        buttonList[0].GetComponent<Image>().color = buttonColor;
        middleImage.SetActive(true);

        playerSelection = 0;
    }
    
    public void RosterButtonPush_Two()
    {
        foreach (GameObject x in buttonList)
        {
            Color color = x.GetComponent<Image>().color;
            color.a = 0f;
            x.GetComponent<Image>().color = color;
        }
        Color buttonColor = buttonList[1].GetComponent<Image>().color;
        buttonColor.a = 100f;
        buttonList[1].GetComponent<Image>().color = buttonColor;
        middleImage.SetActive(true);

        playerSelection = 1;
    }
    public void RosterButtonPush_Three()
    {
        foreach (GameObject x in buttonList)
        {
            Color color = x.GetComponent<Image>().color;
            color.a = 0f;
            x.GetComponent<Image>().color = color;
        }
        Color buttonColor = buttonList[2].GetComponent<Image>().color;
        buttonColor.a = 100f;
        buttonList[2].GetComponent<Image>().color = buttonColor;
        middleImage.SetActive(true);

        playerSelection = 2;
    }
    public void RosterButtonPush_Four()
    {
        foreach (GameObject x in buttonList)
        {
            Color color = x.GetComponent<Image>().color;
            color.a = 0f;
            x.GetComponent<Image>().color = color;
        }
        Color buttonColor = buttonList[3].GetComponent<Image>().color;
        buttonColor.a = 100f;
        buttonList[3].GetComponent<Image>().color = buttonColor;
        middleImage.SetActive(true);

        playerSelection = 3;
    }
    public void RosterButtonPush_Five()
    {
        foreach (GameObject x in buttonList)
        {
            Color color = x.GetComponent<Image>().color;
            color.a = 0f;
            x.GetComponent<Image>().color = color;
        }
        Color buttonColor = buttonList[4].GetComponent<Image>().color;
        buttonColor.a = 100f;
        buttonList[4].GetComponent<Image>().color = buttonColor;
        middleImage.SetActive(true);

        playerSelection = 4;
    }
    public void RosterButtonPush_Six()
    {
        foreach (GameObject x in buttonList)
        {
            Color color = x.GetComponent<Image>().color;
            color.a = 0f;
            x.GetComponent<Image>().color = color;
        }
        Color buttonColor = buttonList[5].GetComponent<Image>().color;
        buttonColor.a = 100f;
        buttonList[5].GetComponent<Image>().color = buttonColor;
        middleImage.SetActive(true);

        playerSelection = 5;
    }
    public void RosterButtonPush_Seven()
    {
        foreach (GameObject x in buttonList)
        {
            Color color = x.GetComponent<Image>().color;
            color.a = 0f;
            x.GetComponent<Image>().color = color;
        }
        Color buttonColor = buttonList[6].GetComponent<Image>().color;
        buttonColor.a = 100f;
        buttonList[6].GetComponent<Image>().color = buttonColor;
        middleImage.SetActive(true);

        playerSelection = 6;
    }
    public void RosterButtonPush_Eight()
    {
       foreach (GameObject x in buttonList)
        {
            Color color = x.GetComponent<Image>().color;
            color.a = 0f;
            x.GetComponent<Image>().color = color;
        }
        Color buttonColor = buttonList[7].GetComponent<Image>().color;
        buttonColor.a = 100f;
        buttonList[7].GetComponent<Image>().color = buttonColor;
        middleImage.SetActive(true);

        playerSelection = 7;
    }
    public void RosterButtonPush_Nine()
    {
        foreach (GameObject x in buttonList)
        {
            Color color = x.GetComponent<Image>().color;
            color.a = 0f;
            x.GetComponent<Image>().color = color;
        }
        Color buttonColor = buttonList[8].GetComponent<Image>().color;
        buttonColor.a = 100f;
        buttonList[8].GetComponent<Image>().color = buttonColor;
        middleImage.SetActive(true);

        playerSelection = 8;
    }
    public void RosterButtonPush_Ten()
    {
        foreach (GameObject x in buttonList)
        {
            Color color = x.GetComponent<Image>().color;
            color.a = 0f;
            x.GetComponent<Image>().color = color;
        }
        Color buttonColor = buttonList[9].GetComponent<Image>().color;
        buttonColor.a = 100f;
        buttonList[9].GetComponent<Image>().color = buttonColor;
        middleImage.SetActive(true);
        
        playerSelection = 9;
    }

    public void ConfirmButton()
    {
        if (playerSelection != -1)
        {
            foreach (GameObject x in teamManager.userTeamRoster) 
            {

                if (x == buttonList[playerSelection].GetComponent<CharacterButtonPickScript>().player)
                {
                    Debug.Log("repeating characters");
                    return;
                }
            }
            teamManager.userTeamRoster[rosterNumber] = buttonList[playerSelection].GetComponent<CharacterButtonPickScript>().player;
            teamRosterSlots[rosterNumber].GetComponent<Text>().text = teamManager.userTeamRoster[rosterNumber].GetComponent<LeaguePlayerScript>().name;
            rosterNumber++;
        }

        if (rosterNumber == 5)
        {
            foreach (GameObject x in teamRosterSlots)
            {
                x.GetComponent<Text>().text = " ";
            }
            rosterNumber = 0;
            playerSelection = -1;
            PromptBattle();
        }
    }

    public void PromptBattle()
    {
        overviewBattlePrompt.SetActive(true);
    }
    

}
