using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IHMManager : MonoBehaviour
{

    [SerializeField] private GameManager gamemanager;

    [SerializeField] private TextMeshProUGUI wordToDisplay;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI textGameOver;

    [SerializeField] private TextMeshProUGUI textScore;

    // m�thode appel� (1 seule fois) quand le script IHM pr�sent sur un GO
    private void Awake()
    {
        gamemanager = GetComponent<GameManager>();
    }

    // fonction pour afficher le text mot pendu
    public void DisplayWord(string word)
    {
        wordToDisplay.text = word;
    }

    // fonction pour afficher le panel gameover
    public void DisplayGameOverPanel(bool isWin)
    {

        gameOverPanel.SetActive(true);
        if (isWin == false)
        {
            textGameOver.color = Color.red;
            textGameOver.text = "You LOOSE ! The word is " + gamemanager.wordToGuess.word;
        }
        else if (isWin == true)
        {
            textGameOver.color = Color.green;
            textGameOver.text = "You WIN ! ";
        }

    }

    // fonction cr�er pour afficher/param�trer le score
    public void SetDisplayScore(int nbrEssais)
    {
        textScore.text = "Chances left  : " + nbrEssais--;

    }

}


