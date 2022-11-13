using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            GameObject bullet_ = Instantiate(Bullet,this.transform.position+this.transform.forward + new Vector3(0,1,0),this.transform.rotation);
            bullet_.GetComponent<Rigidbody>().velocity+=this.transform.forward*25;
            Destroy(bullet_,3);
        }
    }
}
