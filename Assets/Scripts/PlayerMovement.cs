using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime,0,0);
        transform.position += new Vector3(0,0,Input.GetAxis("Vertical")*speed*Time.deltaTime);
    }
}
