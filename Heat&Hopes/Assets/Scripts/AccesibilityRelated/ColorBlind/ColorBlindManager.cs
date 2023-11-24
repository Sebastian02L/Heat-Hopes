using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorBlindManager : MonoBehaviour
{
    [SerializeField] private ColorBlindFilter filter;
    [SerializeField] private TMP_Dropdown list;

    public void SelectMode()
    {
        filter.mode = (ColorBlindMode)list.value;
    }
}
