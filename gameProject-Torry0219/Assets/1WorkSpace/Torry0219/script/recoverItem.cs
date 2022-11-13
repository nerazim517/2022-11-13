using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recoverItem : MonoBehaviour
{
    public GameObject pf;
    // Start is called before the first frame update
    void Start()
    {
        pf = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            recover_prefab_control.eat = true;
            recover_prefab_control.pf_pos = transform.position;
            recover_prefab_control.pf_rot = transform.rotation;
            Destroy(this.gameObject);
        }
    }
}
