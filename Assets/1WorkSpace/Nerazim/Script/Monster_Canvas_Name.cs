using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Monster_Canvas_Name : MonoBehaviour
{
    public TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = this.transform.tag;
        
    }
}