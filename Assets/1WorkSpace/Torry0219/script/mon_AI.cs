using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mon_AI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navi;
    public static GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        navi = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        navi.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.FindWithTag("Player");
        if(Vector3.Distance(transform.position, player.transform.position) <= 10f && Vector3.Distance(transform.position, player.transform.position)>2.5f && !this.GetComponent<mon_ani>().lockAI){
            navi.enabled = true;
            navi.SetDestination(player.transform.position);
        }
        else navi.enabled = false;
    }
}
