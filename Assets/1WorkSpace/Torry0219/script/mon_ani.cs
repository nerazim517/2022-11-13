using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mon_ani : MonoBehaviour
{
    public float move_speed;
    private Animator ani;
    public static GameObject player;
    public bool lockAI;
    public bool playermode;
    
    int atkstate;
    int runstate;

    Vector3 prevPos;
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        atkstate = Animator.StringToHash("Base Layer.attack01");
        runstate = Animator.StringToHash("Base Layer.run");
        prevPos = transform.position;
        playermode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playermode)
        {
            ani.SetBool("attack01", true);
        }
    }
    void FixedUpdate(){
        player = GameObject.FindWithTag("Player");
        float vel = ((transform.position - prevPos) / Time.deltaTime).magnitude;
        AnimatorStateInfo state = ani.GetCurrentAnimatorStateInfo(0);
        if (!playermode)
        {
            lockAI = false;
            ani.SetFloat("speed", vel);
            if (Vector3.Distance(transform.position, player.transform.position) <= 2.5f)
            {
                ani.SetBool("attack01", true);
            }
            else if (state.fullPathHash == atkstate)
            {
                ani.SetBool("attack01", false);
                lockAI = true;
            }
        }
        else
        {
            lockAI = true;
            ani.SetFloat("speed", vel);
            if (state.fullPathHash == atkstate)
            {
                ani.SetBool("attack01", false);
                lockAI = true;
            }
        }
        prevPos = transform.position;
    }
    
}
