using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonPickScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public SpriteRenderer mane;
    public SpriteRenderer jacket;

    public GameObject middleImageMane, middleImageJacket, nameText, costText, statsText, abilityName ,abilityDesc;
    

    public void AssignSprites()
    {
        jacket.sprite = player.GetComponent<LeaguePlayerScript>().jacket.GetComponent<SpriteRenderer>().sprite;
        mane.sprite = player.GetComponent<LeaguePlayerScript>().hat.GetComponent<SpriteRenderer>().sprite;
    }

    public void AssignMiddle()
    {
        middleImageMane.GetComponent<SpriteRenderer>().sprite = mane.sprite;
        middleImageJacket.GetComponent<SpriteRenderer>().sprite = jacket.sprite;

        nameText.GetComponent<Text>().text = player.GetComponent<LeaguePlayerScript>().name;

        string statText = player.GetComponent<LeaguePlayerScript>().minValue + " - " + player.GetComponent<LeaguePlayerScript>().maxValue;
        statsText.GetComponent<Text>().text = statText; 
        abilityName.GetComponent<Text>().text = player.GetComponent<LeaguePlayerScript>().skillName;
        abilityDesc.GetComponent<Text>().text = player.GetComponent<LeaguePlayerScript>().skillDesc;
    }

    public void AssignText()
    {
        
    }
}
