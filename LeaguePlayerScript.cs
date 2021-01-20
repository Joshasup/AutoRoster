using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaguePlayerScript : MonoBehaviour
{

    public string name;
    public int minValue;
    public int maxValue;
    public Ability skill;
    public string skillName;
    public string skillDesc;
    public int randValue;

    public LeaguePlayerScript enemyLaner;

    public GameObject jacket,hat;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetRandomValue()
    {
        randValue = Random.Range(minValue, maxValue);
        

    }

    public void AssignSkill()
    {
        
        skill.Assigned(this.gameObject);
        skillName = skill.name;
        skillDesc = skill.desc;
    }

    public void UseAbility()
    {
        skill.TriggerAbility();
    }
}
