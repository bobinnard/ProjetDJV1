using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private GameManager game;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject defeat;
    [SerializeField] private GameObject retryButton;
    // Start is called before the first frame update
    public void OnReset(){
        player.gameObject.transform.position = player.hubPosition;
        for (int i = 0; i<6; i++){
        Debug.Log("reset1");
            game.characters[i].gameObject.SetActive(true);
            game.characters[i].gameObject.transform.position = game.characters[i].hubPosition;
            game.characters[i].isDead = false;
        }
        GameManager.characterCount = 6;
        GameManager.impostorCount = 2;
        game.Setup();
        victory.SetActive(false);
        defeat.SetActive(false);
        retryButton.SetActive(false);
    }
}
