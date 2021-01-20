using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManagerScript : MonoBehaviour
{

    public GameObject[] userTeamRoster;

    public LeaguePlayerScript[] userPlayingTeam;
    public GameObject[] enemyTeamRoster;
    public LeaguePlayerScript[] enemyPlayingTeam;

    public LeaguePlayerScript topLaner, jungle, midLaner, adc, support;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void AssignTeam()
    {
        int counter = 0;
        foreach (GameObject x in userTeamRoster)
        {
            userPlayingTeam[counter] = x.GetComponent<LeaguePlayerScript>();
            counter++;
        }
    }

    void AssignEnemyLaners()
    {
        topLaner.enemyLaner = enemyPlayingTeam[0];
        jungle.enemyLaner = enemyPlayingTeam[1];
        midLaner.enemyLaner = enemyPlayingTeam[2];
        adc.enemyLaner = enemyPlayingTeam[3];
        support.enemyLaner = enemyPlayingTeam[4];

    }
}
