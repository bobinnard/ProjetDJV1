using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voting : MonoBehaviour
{
    [SerializeField] private MeshRenderer playerVisor;
    [SerializeField] private GameManager game;

    void OnTriggerStay(Collider other){
        PlayerMovement player;
        if (other.gameObject.TryGetComponent<PlayerMovement>(out player) && Input.GetKeyDown("space")){
            Debug.Log("vote");
            player.gameObject.transform.position = player.hubPosition;
            for (int i = 0; i<6; i++){
                if (!game.characters[i].isDead) game.characters[i].gameObject.transform.position = game.characters[i].hubPosition;
            }
            player.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
