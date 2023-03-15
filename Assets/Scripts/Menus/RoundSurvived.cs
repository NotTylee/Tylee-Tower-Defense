using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RoundSurvived : MonoBehaviour
{
    
     
  

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    } 
       
    public void Menu()
    {
        Debug.Log("Menu");
    }
}
