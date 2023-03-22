using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word
{
    //constructeur word liste de mots
    public string word;

    public int length;

    public Word(string value)
    {
        word = value;
        length = value.Length;
    }
}
