using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    // fonction pour refaire le jeu
     public void RestartGame()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
         //Debug.Log("Hangman game restart");
     }

     //fonction du bouton pour quitter le jeu
     public void QuitGame()
     {
         Application.Quit();
         //Debug.Log("Quit game");
     }

}
