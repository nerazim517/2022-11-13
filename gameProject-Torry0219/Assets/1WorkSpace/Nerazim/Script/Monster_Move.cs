using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Move : MonoBehaviour
{
    private Quaternion lookDir;
    Rigidbody rb;
    public float speed;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3.5f;
        rotateSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 v = new Vector2(inputX, inputY);

        if (v.magnitude > 1.0f)
            v = v.normalized;

        if (v.magnitude > 0.1f)
            lookDir = Quaternion.LookRotation(new Vector3(v.x, 0.0f, v.y));

        this.gameObject.transform.rotation = 
            Quaternion.Slerp(this.gameObject.transform.rotation, lookDir, rotateSpeed);
        this.transform.position += new Vector3(v.x * speed, 0, v.y * speed)*Time.deltaTime;
        
        /*if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0,0,speed)*Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.position -= new Vector3(speed,0,0)*Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= new Vector3(0,0,speed)*Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(speed,0,0)*Time.deltaTime;
        }*/
    }
}


