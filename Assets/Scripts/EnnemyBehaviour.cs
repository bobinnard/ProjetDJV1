using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    public int role; // 0: role non attribue, -1: imposteur, 1: crewmate
    public Vector3[] targets;
    public float taskTime;
    private bool taskDone = true;
    public Vector3 hubPosition;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = hubPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(taskDone){
            Vector3 targetToGoTo = targets[Random.Range(0,7)];

        }
    }

    private void Die(){
        isDead = true;
        GameManager.characterCount--;
        if (role == -1) GameManager.impostorCount--;
        //animation de mort
    }
}
