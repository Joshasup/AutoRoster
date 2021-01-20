using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaguePlayerGenerator : MonoBehaviour
{

    public string[] listOfNames;

    public Ability[] listOfAbilities;
    public int minValue;
    public int maxValue;

    public GameObject playerPrefab;

    public int playerListIndex = 0;

    public Sprite[] jacketList;
    public Sprite[] hatList;

    public GameObject jacket;
    public GameObject hat;

    public GameObject[]  buttonList;
    public int buttonIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        string textOfNames = "Impulse Neoguri Bun Wender 963 Boris Boom Blipo Pascal Firework Longx Duo Twin Fin BeeBee BLISS Topon Arnut Acceu Bricksa Crayon MofS Gankos Carson Mark Canavi Selfdestruction Click Roger Almond Santochin Kangaroo Uninspired Speca EHeHeCiK Bibap Kackle Josedoodoo Jenten ShowFaker Devil Claps Night Choppy Egao ArchNemesis Add Broken zie PowerOfGood Rika2 Larsen Burger King Yesmanz Sally Belulu Togethered Tactile Host FuanHeng Porkz LKJ Theft ToKeN noworldswin:( Triplelift Gizmo Rayes Zitnot Laza CoreGG BeryW AsunaXKirito Mickeyx JYY Carrya LMao Hylissong Death Yowan Marc InVar Atlas Vender Bioflame SoNToS Ailes FireFlower Sunlight";
        listOfNames = textOfNames.Split(' ');

    for (int i = 0; i < listOfNames.Length; i++) {
         string temp = listOfNames[i];
         int randomIndex = Random.Range(i, listOfNames.Length);
         listOfNames[i] = listOfNames[randomIndex];
         listOfNames[randomIndex] = temp;
     }

     for (int i = 0; i < listOfAbilities.Length; i++) {
         Ability temp = listOfAbilities[i];
         int randomIndex = Random.Range(i, listOfAbilities.Length);
         listOfAbilities[i] = listOfAbilities[randomIndex];
         listOfAbilities[randomIndex] = temp;
     }

     for (int i = 0; i < jacketList.Length; i++) {
         Sprite temp = jacketList[i];
         int randomIndex = Random.Range(i, jacketList.Length);
         jacketList[i] = jacketList[randomIndex];
         jacketList[randomIndex] = temp;
     }

     for (int i = 0; i < hatList.Length; i++) {
         Sprite temp = hatList[i];
         int randomIndex = Random.Range(i, hatList.Length);
         hatList[i] = hatList[randomIndex];
         hatList[randomIndex] = temp;
     }

     for (int i = 0; i < 10; i++)
     {
         CreatePlayer();
     }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePlayer()
    {
        GameObject player = Instantiate(playerPrefab, new Vector3 (50f,50f,0), Quaternion.identity);
        LeaguePlayerScript playerScript = player.GetComponent<LeaguePlayerScript>();
        
        playerScript.name = listOfNames[playerListIndex];
        

        int randMinValue = Random.Range(minValue, maxValue-1);
        playerScript.minValue = randMinValue;

        int randMaxValue = 0;

        while (randMinValue > randMaxValue)
            randMaxValue = Random.Range(minValue, maxValue);
        
        playerScript.maxValue = randMaxValue;

        playerScript.maxValue = randMaxValue;

        playerScript.skill = listOfAbilities[playerListIndex];
        playerScript.AssignSkill();
        
        jacket = playerScript.jacket;
        hat = playerScript.hat;

        jacket.GetComponent<SpriteRenderer>().sprite = jacketList[playerListIndex];
        hat.GetComponent<SpriteRenderer>().sprite = hatList[playerListIndex]; 

        playerListIndex++;

        buttonList[buttonIndex].GetComponent<CharacterButtonPickScript>().player = player;
        buttonList[buttonIndex].GetComponent<CharacterButtonPickScript>().AssignSprites();
        buttonIndex++;
    }
}
