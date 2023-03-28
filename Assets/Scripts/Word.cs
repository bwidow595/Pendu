using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word
{
    public string word;

    public int length;
    //constructeur word liste de mots
    public Word(string value)
    {
        word = value;
        length = value.Length;
    }
}
