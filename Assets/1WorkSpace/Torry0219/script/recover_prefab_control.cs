using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recover_prefab_control : MonoBehaviour
{
    //private Transform recover_trans;
    public GameObject recover_prefab;
    //spawn after eat
    float prev_time;
    public static bool eat;
    private bool spawn;
    // spawn new's transform
    public static Vector3 pf_pos;
    public static Quaternion pf_rot;
    // audio
    public AudioClip Item_SE;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        prev_time = Time.time;
        eat = false;
        spawn = false;
        // initial prefab
        Instantiate(recover_prefab, new Vector3(12.77f, 0.74f, 6.67f), new Quaternion(0f, 0f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        // if eat item
        if (eat)
        {
            //audioPlayer.PlayOneShot(Item_SE);
            prev_time = Time.time;
            eat = false;
            spawn = true;
        }
        // spawn after 3 sec
        if (spawn)
        {
            if (Time.time - prev_time > 3f)
            {
                spawn = false;
                Instantiate(recover_prefab, pf_pos, pf_rot);
            }
        }
        
    }
    /*public void DestroyThenCreate(GameObject pf){
        pf_pos = pf.transform.position;
        pf_rot = pf.transform.rotation;
        Destroy(pf);
        Invoke("CreatePrefab", 3.0f);
    }
    void CreatePrefab(){
        Instantiate(recover_prefab, pf_pos, pf_rot);
    }*/
}
