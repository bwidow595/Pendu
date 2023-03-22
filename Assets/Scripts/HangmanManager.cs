using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangmanManager : MonoBehaviour
{
    [SerializeField] private Image image;

    // tableau de sprite
    public Sprite[] hg;

    //fonction pour parametrer les sprites
    public void SetHangman(int sp)
    {
        image.sprite = hg[sp];
    }
}
