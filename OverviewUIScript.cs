using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverviewUIScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject rosterScreen, battleScreen, battlePromptScreen, victoryScreen, defeatScreen, creditScreen, metaChangePrompt, musicObject;
    public ButtonRosterScript buttonRoster;
    public TeamManagerScript teamManager;
    public BattleManagerScript battleManager;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConfirmBattle()
    {
        rosterScreen.SetActive(false);
        battlePromptScreen.SetActive(false);
        battleScreen.SetActive(true);
        battleManager.Fight();
    }

    public void VictoryDefeatButton()
    {
        victoryScreen.SetActive(false);
        defeatScreen.SetActive(false);
        creditScreen.SetActive(true);
    }

    public void CreditScreenButton()
    {
        creditScreen.SetActive(false);
        rosterScreen.SetActive(true);
        metaChangePrompt.SetActive(true);
        musicObject.SetActive(false);

        for (int i = 0; i < 5; i++)
         {
             teamManager.userTeamRoster[i] = null;
         }
        
    }

    public void ConfirmPrompt()
    {
        metaChangePrompt.SetActive(false);
    }
}
