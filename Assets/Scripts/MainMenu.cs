using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //fonction pour retourner au main menu(nom sc�ne)
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //fonction pour changer de sc�ne et activer le jeu (index)
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    //fonction pour quitter le jeu
    public void QuitGame()
    {
        Application.Quit();
    }
}
