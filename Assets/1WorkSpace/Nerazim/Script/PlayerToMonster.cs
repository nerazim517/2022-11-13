using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerToMonster : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.GetComponent<Player_State>().Player_Selected_Monster)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                
                GetComponent<Player_State>().Player_Selected_Monster.transform.tag = "Player";
                GetComponent<Player_State>().Player_Selected_Monster.transform.GetComponent<Monster_Move>().enabled = true;
                GetComponent<Player_State>().Player_Selected_Monster.transform.GetComponent<PlayerToMonster>().enabled = true;
                GetComponent<Player_State>().Player_Selected_Monster.transform.GetComponent<Player_State>().enabled = true;

                GetComponent<Player_State>().Player_Selected_Monster.transform.GetComponent<Player_State>().state = 1;
                
                ///////// 
                GetComponent<Player_State>().Player_Selected_Monster.transform.GetComponent<mon_ani>().playermode = true;

                
                GetComponent<Player_State>().Player_Selected_Monster = null;
                
                
                this.gameObject.SetActive(false);
            }
        }
        if ((Input.GetKey(KeyCode.E))&&(GetComponent<Player_State>().state==1))
        {
            Instantiate(Player, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
