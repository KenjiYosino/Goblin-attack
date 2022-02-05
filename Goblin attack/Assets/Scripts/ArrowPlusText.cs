using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowPlusText : MonoBehaviour
{
    public static int ArrowPlus = 50;
    private int previousValue;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();      
        ArrowPlus = 50;
    }

    private void Update()
    {
        if (ArrowPlus != previousValue)
        {
            text.text = ArrowPlus.ToString();
            previousValue = ArrowPlus;
        }    
    }
}
