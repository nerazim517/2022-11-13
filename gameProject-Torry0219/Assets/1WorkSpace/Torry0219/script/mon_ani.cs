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
    public bool dead;

    private Vector3 lookDir;
    
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
        dead = false;
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
        lookDir = player.transform.position - transform.position;
        float vel = ((transform.position - prevPos) / Time.deltaTime).magnitude;
        AnimatorStateInfo state = ani.GetCurrentAnimatorStateInfo(0);
        if (GetComponent<Monster_State>().Monster_HP <= 0f && !dead)
        {
            dead = true;
            ani.SetBool("dead", dead);
            Invoke("DestroyIt", 4.0f);
            
        }
        else if (!playermode && !dead)
        {
            lockAI = false;
            ani.SetFloat("speed", vel);
            if (Vector3.Distance(transform.position, player.transform.position) <= 2.5f)
            {
                Quaternion q = Quaternion.LookRotation(lookDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, 2 * Time.deltaTime);
                ani.SetBool("attack01", true);
            }
            else if (state.fullPathHash == atkstate)
            {
                ani.SetBool("attack01", false);
                lockAI = true;
            }
        }
        else if(playermode && !dead)
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
    public void DestroyIt()
    {
        Destroy(gameObject);
    }
    
}
