using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManagerScript : MonoBehaviour
{

    public bool fight = false;
    public LeaguePlayerScript[] userPlayingTeam;
    public GameObject[] enemyPlayingTeam;

    public int matchCount = 0;

    public TeamManagerScript teamManager;
    public EnemyTeamManager enemyManager;


    public int userSum = 0, enemySum = 0;

    public GameObject[] playerSlots;
    public GameObject playerScore, playerRange, enemyScore, enemyRange, announcerTextBox, middleBox, metaBox, musicObject;

    private IEnumerator coroutine;

    public bool won;
    public GameObject victoryScreen, defeatScreen, battleScreen;




    
    // Start is called before the first frame update
    public void Fight()
    {
        
        AssignPlayersToTeam();
        coroutine= PlayBattle();
        StartCoroutine(coroutine);
      
        
    }

    // Update is called once per frame


    
    public void AssignPlayersToTeam()
    {
        for (int i = 0; i < 5; i++)
        {
            playerSlots[i].GetComponent<BattleSlotScript>().player = teamManager.userTeamRoster[i];
            playerSlots[i].GetComponent<BattleSlotScript>().AssignSprites();
        }
        
        teamManager.AssignTeam();
        userPlayingTeam = teamManager.userPlayingTeam;
        enemyPlayingTeam = enemyManager.enemyTeam1;
        int countPlayer = 0;
        foreach(LeaguePlayerScript x in userPlayingTeam)
        {
            x.enemyLaner = enemyPlayingTeam[countPlayer].GetComponent<LeaguePlayerScript>();
            countPlayer++;
        }
        countPlayer = 0;
        foreach(GameObject x in enemyPlayingTeam)
        {
            LeaguePlayerScript enem = x.GetComponent<LeaguePlayerScript>();
            enem.enemyLaner = userPlayingTeam[countPlayer];
            countPlayer = 0;
        }

    }
    
    public void StartBattle()
    {
        foreach(LeaguePlayerScript x in userPlayingTeam)
        {
            x.GetRandomValue();
            Debug.Log(x.name + " : " + x.randValue);
            userSum = userSum + x.randValue;
        }
        foreach(GameObject x in enemyPlayingTeam)
        {
            LeaguePlayerScript enem = x.GetComponent<LeaguePlayerScript>();
            enem.GetRandomValue();
            Debug.Log(enem.name + " : " + enem.randValue);
            enemySum = enemySum + enem.randValue;
        }

        Debug.Log(userSum);
        Debug.Log(enemySum);

        userSum = 0;
        enemySum = 0;
        foreach(GameObject x in enemyPlayingTeam)
        {
            LeaguePlayerScript enem = x.GetComponent<LeaguePlayerScript>();
            enem.UseAbility();
            Debug.Log(enem.name + " : " + enem.randValue);
            enemySum = enemySum + enem.randValue;
        }

        foreach(LeaguePlayerScript x in userPlayingTeam)
        {
            x.UseAbility();
            Debug.Log(x.name + " : " + x.randValue);
            userSum = userSum + x.randValue;
        }

        Debug.Log(userSum);
        Debug.Log(enemySum);
    }

    public void OverallMeta()
    {
        StartBattle();
        if (userSum >= enemySum)
        {
            Debug.Log("victory");
        }
    }

    public void BetterLaneWins()
    {
        StartBattle();
        int laneWins = 0;
        for (int i = 0; i < 5; i++)
        {
            if (userPlayingTeam[i].randValue >= enemyPlayingTeam[i].GetComponent<LeaguePlayerScript>().randValue)
            {
                laneWins++;
            }
        } 

        if (laneWins >= 3)
        {
            Debug.Log("victory");
        }
    }

    public void LevelOneCheese()
    {
        userSum = 0;
        enemySum = 0;
        foreach(GameObject x in enemyPlayingTeam)
        {
            LeaguePlayerScript enem = x.GetComponent<LeaguePlayerScript>();
            enem.randValue = Random.Range(1,3);
            enem.UseAbility();
            Debug.Log(enem.name + " : " + enem.randValue);
            enemySum = enemySum + enem.randValue;
        }

        foreach(LeaguePlayerScript x in userPlayingTeam)
        {
            x.randValue = Random.Range(1,3);
            x.UseAbility();
            Debug.Log(x.name + " : " + x.randValue);
            userSum = userSum + x.randValue;
        }

        if (userSum >= enemySum)
        {
            Debug.Log("victory");
        }
    }

    private IEnumerator PlayBattle()
    {

         if (matchCount == 0)
        {
            metaBox.GetComponent<Text>().text = "Normal Game. Team with the highest points wins!";
        }
        else if(matchCount == 1)
        {
            metaBox.GetComponent<Text>().text = "Better Lane Wins. Team who wins the most amount of lanes wins!";
        }
        int laneCounter = 0;
        Text aText = announcerTextBox.GetComponent<Text>();
        Text pRangeText = playerRange.GetComponent<Text>();
        Text eRangeText = enemyRange.GetComponent<Text>();
        Text pScore = playerScore.GetComponent<Text>();
        Text eSCore = enemyScore.GetComponent<Text>();
        aText.text = "Welcome to the match! We got an exciting game for you all!";
        yield return new WaitForSeconds(3f);
        aText.text = "And the match just started! Let's see how one of the lane is going.";
        playerSlots[laneCounter].GetComponent<BattleSlotScript>().AssignMiddle();
        middleBox.SetActive(true);
        userPlayingTeam[laneCounter].GetRandomValue();
        enemyPlayingTeam[laneCounter].GetComponent<LeaguePlayerScript>().GetRandomValue();
        int playerTopLaneValue = userPlayingTeam[laneCounter].randValue;
        int enemyTopLaneValue = enemyPlayingTeam[laneCounter].GetComponent<LeaguePlayerScript>().randValue;
        pRangeText.text = userPlayingTeam[laneCounter].minValue + " - " + userPlayingTeam[laneCounter].maxValue;
        eRangeText.text = enemyPlayingTeam[laneCounter].GetComponent<LeaguePlayerScript>().minValue + " - " + enemyPlayingTeam[laneCounter].GetComponent<LeaguePlayerScript>().maxValue;
        yield return new WaitForSeconds(3f);
        aText.text = "Let's see what they got!";
        pScore.text = playerTopLaneValue.ToString();
        eSCore.text = enemyTopLaneValue.ToString();
        yield return new WaitForSeconds(2f);
        if (playerTopLaneValue > enemyTopLaneValue)
        {
            aText.text = "Team Liquid is winning this lane!";
        }
        else if (playerTopLaneValue == enemyTopLaneValue)
        {
            aText.text = "It's dead even!";
        }
        else 
        {
            aText.text = "Team Liquid is losing this lane!";
        }
        yield return new WaitForSeconds(3f);
        aText.text = "It's time for the skills!";
        yield return new WaitForSeconds(2f);
        enemyPlayingTeam[laneCounter].GetComponent<LeaguePlayerScript>().UseAbility();
        aText.text =  enemyPlayingTeam[laneCounter].GetComponent<LeaguePlayerScript>().name + " used " + enemyPlayingTeam[laneCounter].GetComponent<LeaguePlayerScript>().skillName + ". " + enemyPlayingTeam[laneCounter].GetComponent<LeaguePlayerScript>().skillDesc;
        enemyTopLaneValue = enemyPlayingTeam[laneCounter].GetComponent<LeaguePlayerScript>().randValue;
        eSCore.text = enemyTopLaneValue.ToString();
        yield return new WaitForSeconds(3f);
        userPlayingTeam[laneCounter].UseAbility();
        aText.text = userPlayingTeam[laneCounter].name + " used " + userPlayingTeam[laneCounter].skillName + ". " + userPlayingTeam[laneCounter].skillDesc;
        playerTopLaneValue = userPlayingTeam[laneCounter].randValue;
        pScore.text = playerTopLaneValue.ToString();
        yield return new WaitForSeconds(3f);
        if (playerTopLaneValue > enemyTopLaneValue)
        {
            aText.text = "Team Liquid is winning this lane!";
        }
        else if (playerTopLaneValue == enemyTopLaneValue)
        {
            aText.text = "It's dead even!";
        }
        else 
        {
            aText.text = "Team Liquid is losing this lane!";
        }

        yield return new WaitForSeconds(3f);
        aText.text = "The other lanes will be finished calculating automatically!";

        for (int i = 1; i < 5; i++)
        {
            userPlayingTeam[i].GetRandomValue();
            enemyPlayingTeam[i].GetComponent<LeaguePlayerScript>().GetRandomValue();
            enemyPlayingTeam[i].GetComponent<LeaguePlayerScript>().UseAbility();
            userPlayingTeam[i].UseAbility();
            userSum = userSum + userPlayingTeam[i].randValue;
            enemySum = enemySum + enemyPlayingTeam[i].GetComponent<LeaguePlayerScript>().randValue;

        }
        yield return new WaitForSeconds(3f);

        aText.text = "And here are the results! Team Liquid got " + userSum + ". The enemy got "+ enemySum + ".";
        yield return new WaitForSeconds(3f);
        if (userSum > enemySum)
        {
            aText.text= "And we have our winners! Team Liquid wins it all!";
            won = true;
        }
        else
        {
            aText.text = "And Team Liquid is our losers! :(" ;
            won = false;
        }
        yield return new WaitForSeconds(3f);
        matchCount = matchCount + 1;

        
        if (matchCount > 3)
        {
            matchCount = 0;
        }
        middleBox.SetActive(false);
          if (won)
        {
            victoryScreen.SetActive(true);
            battleScreen.SetActive(false);
            musicObject.SetActive(true);
        }
        else
        {
            defeatScreen.SetActive(true);
            battleScreen.SetActive(false);
            musicObject.SetActive(true);
        }




    }
}
