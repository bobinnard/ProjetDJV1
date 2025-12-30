using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voting : MonoBehaviour
{
    public static bool isVoting = false;
    [SerializeField] private GameManager game;
    private int isSelected = 0;
    [SerializeField] private GameObject playerObject;

    void OnTriggerStay(Collider other){
        PlayerMovement player;
        if (other.gameObject.TryGetComponent<PlayerMovement>(out player) && Input.GetKeyDown("space")){
            Debug.Log("vote");
            isVoting = true;
            player.gameObject.transform.position = player.hubPosition;
            for (int i = 0; i<6; i++){
                if (!game.characters[i].isDead){
                    game.characters[i].gameObject.transform.position = game.characters[i].hubPosition;
                    isSelected = i;
                }
            }
            game.characters[isSelected].isVoted = true;
            player.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isVoting && Input.GetKeyDown("left")){
            game.characters[isSelected].isVoted = false;
            isSelected = (isSelected-1);
            if (isSelected < 0) isSelected = 5;
            while(game.characters[isSelected].isDead){
                isSelected = (isSelected-1);
                if(isSelected < 0) isSelected = 5;
            }
            game.characters[isSelected].isVoted = true;
        }
        if(isVoting && Input.GetKeyDown("right")){
            game.characters[isSelected].isVoted = false;
            isSelected = (isSelected+1)%6;
            while(game.characters[isSelected].isDead){
                isSelected = (isSelected+1)%6;
            }
            game.characters[isSelected].isVoted = true;
        }
        if (!isVoting) playerObject.SetActive(true);
    }
}
