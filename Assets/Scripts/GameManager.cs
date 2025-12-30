using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int impostorCount = 2;
    public static int characterCount = 6;
    [SerializeField] public EnnemyBehaviour[] characters;
    [SerializeField] private string[] targets;
    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject defeat;
    [SerializeField] private GameObject retryButton;
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    public void Setup(){
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
        if(impostorCount == 0){
            victory.SetActive(true);
            retryButton.SetActive(true);
        }
        if (impostorCount >= characterCount-impostorCount+1){
            defeat.SetActive(true);
            retryButton.SetActive(true);
        }
    }
}
