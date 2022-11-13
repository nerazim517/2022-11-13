using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State : MonoBehaviour
{
    public float Player_HP;
    public GameObject Player_Selected_Monster;
    public float Player_Score;
    public int state; //0代表人型態 1代表怪物型態
    bool ishit = false;
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        state = 1;
        Player_HP = 100f;
        Player_Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit))
        {
            ishit = true;
            
            if((hit.collider.gameObject.transform.tag=="Goblin")||(hit.collider.gameObject.transform.tag=="Wolf")||(hit.collider.gameObject.transform.tag=="Troll"))
            {
                print("hit");
                Player_Selected_Monster = hit.collider.gameObject;
            }
            else
            {
                Player_Selected_Monster = null;
            }
            ishit = false;
        }

        if (Player_Selected_Monster)
        {
            print(Player_Selected_Monster.transform.tag);
        }
        
    }
}
