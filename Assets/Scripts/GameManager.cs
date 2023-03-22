using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    //déclaration class IHMManager
    private IHMManager ihm;
    //déclaration class HangmamManager
    private HangmanManager hangman;
    //Fields liste de mots à deviner
    private List<string> wordList = new List<string>() { "ACROBAT", "HURT", "CALIFORNIA", "GAME", "FAIRY", "FIRE", "VOLCANO", "SEA", "WARRIOR", "ROAD" };
    // Fields du mot à deviner
    public Word wordToGuess;
    // Fields du champ de texte
    private string wordToDisplay;
    // tableaux de caractére unique ici des lettres
    private char[] charArray;
    // Fields du nombre d'essais
    [SerializeField] private int nbrEssais = 7;
    // Fields condition gameover
    private bool gameover;
    // Fields si partie gagné
    private bool IsWin = false;
    // Fields déclaré les deux sons
    public AudioClip SfxWin, SfxFailed;
    // Fields utilisations audio source
    private AudioSource audiosource;


    // méthode appelé (1 seule fois) quand le script IHM présent sur un GO
    private void Awake()
    {
        ihm = GetComponent<IHMManager>();
        hangman = GetComponent<HangmanManager>();
        audiosource = GetComponent<AudioSource>();

    }


    //fonction pour tester la lettre lors de l'appui sur les boutons du clavier virtuel
    public void KeyboardPress(string letter)
    {
        var button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if (gameover == false)
        {
            TestLetter(letter, button);
            //Debug.Log(letter);
        }
        button.interactable = false;
    }

    //méthode  Start is called before the first frame update
    void Start()
    {
        wordToGuess = new Word(ChooseRandomWord());
        charArray = new char[wordToGuess.length];
        SetWordToDisplay();
        hangman.SetHangman(nbrEssais);

    }

    // fonction pour générer aléatoirement le choix des mots à deviner dans la liste
    private string ChooseRandomWord()
    {
        int rnd = Random.Range(0, wordList.Count);
        return wordList[rnd];

    }


    // méthode vérifiant si les lettres sont présentes et créer un réaction 
    private void Result(bool IsLetterPresent)
    {

        if (!IsLetterPresent)
        {
            audiosource.PlayOneShot(SfxFailed);
            nbrEssais--;
            ihm.SetDisplayScore(nbrEssais);
            hangman.SetHangman(nbrEssais);
            //Debug.Log(nbrEssais);

        }
        else if (IsLetterPresent)
        {
            audiosource.PlayOneShot(SfxWin);
            IsWin = true;

        }
        CheckGameOver();
    }

    // fonction pour vérifier la condition du gameover
    private void CheckGameOver()
    {
        if (nbrEssais <= 0)
        {
            gameover = true;
            ihm.DisplayGameOverPanel(false);
        }
        else if (wordToDisplay == wordToGuess.word)
        {
            gameover = false;
            ihm.DisplayGameOverPanel(true);
        }

    }

    //fonction pour tester la lettre proposer par le joueur 
    private void TestLetter(string letter, Button button)
    {
        bool IsLetterPresent = false;

        // check letter > secret word
        for (int i = 0; i < wordToGuess.length; i++)
        {
            if (wordToGuess.word[i] == letter[0])
            {
                IsLetterPresent = true;
                //Debug.Log(IsLetterPresent);
            }
        }

        //Debug.Log(IsLetterPresent);
        SetWordToDisplay(letter[0]);
        Result(IsLetterPresent);
        ChangeButtonColor(button, IsLetterPresent);
    }

    // méthode pour changer la couleur des bouttons du clavier virtuel en vérifiant si la lettre est présente dans le wordToGuess
    private void ChangeButtonColor(Button button, bool IsLetterPresent)
    {
        var colorBlock = button.colors;
        if (IsLetterPresent)
        {
            colorBlock.disabledColor = Color.green;
        }
        else if (!IsLetterPresent)
        {
            colorBlock.disabledColor = Color.red;
        }
        button.colors = colorBlock;
    }

    // fonction pour paramètrer le champ de text sur Unity "MotPendu"
    private void SetWordToDisplay()
    {
        for (int i = 0; i < wordToGuess.length; i++)
        {
            charArray[i] += '_';

        }
        ihm.DisplayWord(ShowWord());
    }

    // fonction pour indiquer quelle lettre a était découverte
    private void SetWordToDisplay(char letter)
    {
        for (int i = 0; i < wordToGuess.length; i++)
        {
            if (wordToGuess.word[i] == letter)
            {
                charArray[i] = letter;
            }
        }
        ihm.DisplayWord(ShowWord());
    }

    // fonction pour faire apparaitre les lettres dans "MotPendu"
    private string ShowWord()
    {
        wordToDisplay = "";

        for (int i = 0; i < wordToGuess.length; i++)
        {
            wordToDisplay += charArray[i];
        }
        return wordToDisplay;
    }

    /* public string wordToGuess.word
    {
        get { return wordToGuess.word; }
        //set { wordToGuess = new Word(value); }
    }
    public int wordToGuess.length
    {
        get { return wordToGuess.length; }
        //set { wordToGuess = new Word(value); }
    }*/


}
