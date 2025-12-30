using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class Rooms : MonoBehaviour
{
    public string roomName;
    public Rooms[] voisins;
    [SerializeField] private Vector3 coordinate;
    private List<EnnemyBehaviour> impostorList = new List<EnnemyBehaviour>();
    private List<EnnemyBehaviour> crewmateList = new List<EnnemyBehaviour>();
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other){
        EnnemyBehaviour ennemy;
        if(other.gameObject.TryGetComponent<EnnemyBehaviour>(out ennemy)){
            if (ennemy.role == -1) impostorList.Add(ennemy);
            else crewmateList.Add(ennemy);
        }
    }

    void OnTriggerExit(Collider other){
        EnnemyBehaviour ennemy;
        if(other.gameObject.TryGetComponent<EnnemyBehaviour>(out ennemy)){
            if (ennemy.role == -1) impostorList.Remove(ennemy);
            else crewmateList.Remove(ennemy);
        }
    }

    void OnTriggerStay(Collider other){
        EnnemyBehaviour ennemy;
        if(other.gameObject.TryGetComponent<EnnemyBehaviour>(out ennemy)){
            if (Vector3.Distance(ennemy.gameObject.transform.position, coordinate) < 0.5 && ennemy.path[ennemy.currentTarget] == coordinate){
                if (ennemy.path.Count == ennemy.currentTarget+1) ennemy.StartCoroutine("DoTask");
                else ennemy.currentTarget += 1;
            }
            ennemy.UpdateRoom(this);
        }
    }

    public List<Vector3> pathFind(string nameSearched, List<Vector3> currentPath, List<string> roomsExplored){
        if(!roomsExplored.Contains(roomName)) {
            currentPath.Add(coordinate);
            roomsExplored.Add(roomName);
        }
        else return (null);
        if (roomName == nameSearched) return currentPath;
        else{
            int shortestPath = 1000000;
            List<Vector3> newPath = null;
            for (int i = 0; i<voisins.Length; i++){
                List<Vector3> temp = voisins[i].pathFind(nameSearched, currentPath, roomsExplored);
                if (temp != null){
                    if(temp.Count < shortestPath && temp != null){
                        newPath = temp;
                        shortestPath = temp.Count;
                    }
                }
                
            }
            currentPath = newPath;
        }
        return(currentPath);
    }

    // Update is called once per frame
    void Update()
    {
        if(impostorList.Count >= crewmateList.Count){
            for (int i = 0; i<crewmateList.Count; i++){
                if(crewmateList[i].doingTask) crewmateList[i].Die();
            }
        }
    }
}
