using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSlotScript : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer mane;
    public SpriteRenderer jacket;

    public SpriteRenderer middleMane, middleJacket;
    // Start is called before the first frame update
    public void AssignSprites()
    {
        jacket.sprite = player.GetComponent<LeaguePlayerScript>().jacket.GetComponent<SpriteRenderer>().sprite;
        mane.sprite = player.GetComponent<LeaguePlayerScript>().hat.GetComponent<SpriteRenderer>().sprite;
    }

    public void AssignMiddle()
    {
        middleJacket.sprite = player.GetComponent<LeaguePlayerScript>().jacket.GetComponent<SpriteRenderer>().sprite;
        middleMane.sprite = player.GetComponent<LeaguePlayerScript>().hat.GetComponent<SpriteRenderer>().sprite;
    }
}
