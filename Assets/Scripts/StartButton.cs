using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UIElements;

public class StartButton : MonoBehaviour
{
    
    public void StartLevel(){
        SceneManager.LoadScene("SampleScene");
    }
}
