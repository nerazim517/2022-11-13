using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster_State : MonoBehaviour
{
    public float Monster_HP;
    // Start is called before the first frame update
    void Start()
    {
        Monster_HP = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Bullet")
        {
            //Player_State.Player_Score += 5;
            
            Destroy(collision.transform);
            Monster_HP-=5;
        }
    }
}
