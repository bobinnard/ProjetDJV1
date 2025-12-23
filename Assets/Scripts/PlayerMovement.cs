using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    [SerializeField] private CharacterController player;

    // Update is called once per frame
    void Update()
    {
        player.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))*speed*Time.deltaTime);
    }
}
