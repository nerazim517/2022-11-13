using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Monster_Canvas : MonoBehaviour
{
    GameObject cam;
    public Image HpBar;
    float RemainHP;
    float StartHP;
    string name;
    GameObject monster;
    void Start() {
        monster = gameObject.transform.parent.gameObject;
        cam = GameObject.FindGameObjectsWithTag("MainCamera")[0]; 
        name = this.transform.tag;

        
    }

    private void Update()
    {
        this.transform.LookAt(this.transform.position + (cam.transform.rotation * Vector3.forward), cam.transform.rotation * Vector3.up);
        
        RemainHP = monster.GetComponent<Monster_State>().Monster_HP;
        
        HpBar.GetComponent<Image>().fillAmount = RemainHP/100;
        
    }
    
}
