using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Canvas : MonoBehaviour
{
    public TextMeshProUGUI Selected_Monster_UI;
    public TextMeshProUGUI Player_HP_UI;
    public TextMeshProUGUI Time_UI;
    public TextMeshProUGUI Score_UI;
    public TextMeshProUGUI Selected_Monster_Info_Monster_Name;
    public Image Monster_HPBar;
    public GameObject Selected_Monster_Info;
    // Start is called before the first frame update
    void Start()
    {
        Selected_Monster_Info.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player.GetComponent<Player_State>().Player_Selected_Monster)
        {
            Selected_Monster_UI.text = "Selected Monster:" + player.GetComponent<Player_State>().Player_Selected_Monster.transform.tag;
            Selected_Monster_Info.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Player_State>().Player_Selected_Monster.transform.tag;
            Monster_HPBar.fillAmount = player.GetComponent<Player_State>().Player_Selected_Monster.GetComponent<Monster_State>().Monster_HP/100;
            Selected_Monster_Info.SetActive(true);
        }
        else
        {
            Selected_Monster_UI.text = "Selected Monster:";
            Selected_Monster_Info.SetActive(false);
        }
        Player_HP_UI.text = "HP:" + player.GetComponent<Player_State>().Player_HP;
        Time_UI.text = "Time:" + Time.time;
        Score_UI.text = "Score:" + player.GetComponent<Player_State>().Player_Score;
    }
}
