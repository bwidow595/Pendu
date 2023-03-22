using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class MainMenu : MonoBehaviour
{
    
    //fonction pour changer de scène et activer le jeu

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      

    }
    //fonction pour quitter le jeu
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
