using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdAtama : MonoBehaviour
{
    [SerializeField] private TMP_InputField Ad;
    [SerializeField] private TMP_InputField ID;
    [SerializeField] private TMP_InputField Hamle;
    [SerializeField] private TMP_InputField Seviye;

    public void Submit()
    {
        PlayerPrefs.SetString("OyuncuAdi", Ad.text);
        PlayerPrefs.SetString("OyuncuID", ID.text);
        PlayerPrefs.SetString("Hamle", Hamle.text);
        PlayerPrefs.SetString("Seviye", Seviye.text);
    }
}
