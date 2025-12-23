using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    [SerializeField] private CharacterController player;
    [SerializeField] private Transform visor;
    public int denounceCooldown;
    public Vector3 hubPosition;
    [SerializeField] public MeshRenderer mr;

    void Start(){
        gameObject.transform.position = hubPosition;
    }

    // Update is called once per frame
    void Update()
    {
        player.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))*speed*Time.deltaTime);
        if (Input.GetAxis("Horizontal") > 0) visor.LookAt(visor.position + gameObject.transform.right, visor.up);
        if (Input.GetAxis("Horizontal") < 0) visor.LookAt(visor.position - gameObject.transform.right, visor.up);
        if (Input.GetAxis("Vertical") > 0) visor.LookAt(visor.position + gameObject.transform.forward, visor.up);
        if (Input.GetAxis("Vertical") < 0) visor.LookAt(visor.position - gameObject.transform.forward, visor.up);
    }
}
