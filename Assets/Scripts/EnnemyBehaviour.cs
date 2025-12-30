using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    public int role; // 0: role non attribue, -1: imposteur, 1: crewmate
    public string[] targets;
    public float taskTime;
    public float speed;
    private bool taskDone = true;
    public Vector3 hubPosition;
    public bool isDead = false;
    public bool isVoted = false;
    [SerializeField] private MeshRenderer mr;
    [SerializeField] private Material voted;
    [SerializeField] private Material notVoted;
    [SerializeField] private Rooms currentRoom;
    [SerializeField] private CharacterController character;
    public List<Vector3> path = new List<Vector3>();
    public int currentTarget = 1;
    public bool doingTask = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = hubPosition;
    }

    public void UpdateRoom(Rooms newRoom){
        currentRoom = newRoom;
    }

    // Update is called once per frame
    void Update()
    {
        if(taskDone){
            currentTarget = 1;
            string targetName = targets[Random.Range(0,7)];
            path = currentRoom.pathFind(targetName, new List<Vector3>(), new List<string>());
            taskDone = false;
        }
        else if(!doingTask){
            Vector3 curCo = path[currentTarget];
            transform.LookAt(curCo);
            character.Move(transform.forward*speed*Time.deltaTime);
        }
        if(isVoted && Voting.isVoting){
            mr.material = voted;
        }
        else mr.material = notVoted;
        if(isVoted && Voting.isVoting && Input.GetMouseButtonDown(0)) Die();
    }

    public IEnumerator DoTask(){
        doingTask = true;
        yield return new WaitForSeconds(taskTime);
        taskDone = true;
        doingTask = false;
    }

    public void Die(){
        isVoted = false;
        isDead = true;
        gameObject.SetActive(false);
        GameManager.characterCount--;
        if (role == -1) GameManager.impostorCount--;
        if(Voting.isVoting) Voting.isVoting = false;
        //animation de mort
    }
}
