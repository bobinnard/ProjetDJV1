using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int impostorCount = 2;
    public static int characterCount = 6;
    [SerializeField] public EnnemyBehaviour[] characters;
    [SerializeField] private Vector3[] targets;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<characterCount; i++){
            characters[i].targets = targets;
            characters[i].role = 1;
        }
        for (int i = 0; i<impostorCount; i++){
            characters[Random.Range(0,characterCount)].role = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(impostorCount == 0)Debug.Log("you win!");
        if (impostorCount > characterCount+1) Debug.Log("you lost!");
    }
}
