using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    //d�claration class IHMManager
    private IHMManager ihm;
    //d�claration class HangmamManager
    private HangmanManager hangman;
    //Fields liste de mots � deviner
    private List<string> wordList = new List<string>() { "ACROBAT", "HURT", "CALIFORNIA", "GAME", "FAIRY", "FIRE", "VOLCANO", "SEA", "WARRIOR", "ROAD" };
    // Fields du mot � deviner
    public Word wordToGuess;
    // Fields du champ de texte
    private string wordToDisplay;
    // tableaux de caract�re unique ici des lettres
    private char[] charArray;
    // Fields du nombre d'essais
    [SerializeField] private int nbrEssais = 7;
    // Fields condition gameover
    private bool gameover;
    // Fields si partie gagn�
    private bool IsWin = false;
    // Fields d�clar� les deux sons
    public AudioClip SfxWin, SfxFailed;
    // Fields utilisations audio source
    private AudioSource audiosource;


    // m�thode appel� (1 seule fois) quand le script IHM pr�sent sur un GO
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

    //m�thode  Start is called before the first frame update
    void Start()
    {
        wordToGuess = new Word(ChooseRandomWord());
        charArray = new char[wordToGuess.length];
        SetWordToDisplay();
        hangman.SetHangman(nbrEssais);

    }

    // fonction pour g�n�rer al�atoirement le choix des mots � deviner dans la liste
    private string ChooseRandomWord()
    {
        int rnd = Random.Range(0, wordList.Count);
        return wordList[rnd];

    }


    // m�thode v�rifiant si les lettres sont pr�sentes et cr�er un r�action 
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

    // fonction pour v�rifier la condition du gameover
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

    // m�thode pour changer la couleur des bouttons du clavier virtuel en v�rifiant si la lettre est pr�sente dans le wordToGuess
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

    // fonction pour param�trer le champ de text sur Unity "MotPendu"
    private void SetWordToDisplay()
    {
        for (int i = 0; i < wordToGuess.length; i++)
        {
            charArray[i] += '_';

        }
        ihm.DisplayWord(ShowWord());
    }

    // fonction pour indiquer quelle lettre a �tait d�couverte
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
