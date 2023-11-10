using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DyslexiaControl : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        GameObject go = GameObject.Find("TestText");
        text = go.GetComponent<TextMeshProUGUI>();
    }
    public void changeLetterDistance(float sliderFloat)
    {
        switch (sliderFloat)
        {
            case 0:
                text.characterSpacing = sliderFloat;
                break;
            case 1:
                text.characterSpacing = sliderFloat + 2;
                break;
            case 2:
                text.characterSpacing = sliderFloat + 4;
                break;
            case 3:
                text.characterSpacing = sliderFloat + 6;
                break;
            case 4:
                text.characterSpacing = sliderFloat + 6;
                break;
            case 5:
                text.characterSpacing = sliderFloat + 7;
                break;
        }
    }

    public void changeWordDistance(float sliderFloat)
    {
        switch (sliderFloat)
        {
            case 0:
                text.wordSpacing = sliderFloat;
                break;
            case 1:
                text.wordSpacing = sliderFloat + 2;
                break;
            case 2:
                text.wordSpacing = sliderFloat + 4;
                break;
            case 3:
                text.wordSpacing = sliderFloat + 6;
                break;
            case 4:
                text.wordSpacing = sliderFloat + 6;
                break;
            case 5:
                text.wordSpacing = sliderFloat + 7;
                break;
        }
    }

    public void changeLineDistance(float sliderFloat)
    {
        switch (sliderFloat)
        {
            case 0:
                text.lineSpacing = sliderFloat;
                break;
            case 1:
                text.lineSpacing = sliderFloat + 2;
                break;
            case 2:
                text.lineSpacing = sliderFloat + 4;
                break;
            case 3:
                text.lineSpacing = sliderFloat + 6;
                break;
            case 4:
                text.lineSpacing = sliderFloat + 6;
                break;
            case 5:
                text.lineSpacing = sliderFloat + 7;
                break;
        }
    }
}
