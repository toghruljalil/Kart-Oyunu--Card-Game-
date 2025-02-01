using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectParameters : MonoBehaviour
{
    public int dayaniklilik;
    public int vurus;
    public int seviye;
    public string sinif;
    public int havavurus;
    public int karavurus;
    public int denizvurus;
    [SerializeField] private TMP_Text can;
    [SerializeField] private TMP_Text puan;

    private void Start()
    {
        if(gameObject.CompareTag("Firkateyn"))
        {
            dayaniklilik = 25;
            vurus = 10;
            sinif = "Deniz";
            havavurus = 5;
            karavurus = 0;
            denizvurus = 0;
            seviye = int.Parse(PlayerPrefs.GetString("Seviye"));
        }
        if (gameObject.CompareTag("Obus"))
        {
            dayaniklilik = 20;
            vurus = 10;
            sinif = "Kara";
            havavurus = 0;
            karavurus = 0;
            denizvurus = 5;
            seviye = int.Parse(PlayerPrefs.GetString("Seviye"));
        }
        if (gameObject.CompareTag("Ucak"))
        {
            dayaniklilik = 20;
            vurus = 10;
            sinif = "Hava";
            havavurus = 0;
            karavurus = 10;
            denizvurus = 0;
            seviye = int.Parse(PlayerPrefs.GetString("Seviye"));
        }
        if (gameObject.CompareTag("Siha"))
        {
            dayaniklilik = 15;
            vurus = 10;
            sinif = "Hava";
            havavurus = 0;
            karavurus = 10;
            denizvurus = 10;
            seviye = int.Parse(PlayerPrefs.GetString("Seviye"));
        }
        if (gameObject.CompareTag("Sida"))
        {
            dayaniklilik = 15;
            vurus = 10;
            sinif = "Deniz";
            havavurus = 10;
            karavurus = 10;
            denizvurus = 0;
            seviye = int.Parse(PlayerPrefs.GetString("Seviye"));
        }
        if (gameObject.CompareTag("KFS"))
        {
            dayaniklilik = 10;
            vurus = 10;
            sinif = "Kara";
            havavurus = 10;
            karavurus = 0;
            denizvurus = 10;
            seviye = int.Parse(PlayerPrefs.GetString("Seviye"));
        }
        SkorGoster();
    }

    public void SkorGoster()
    {
        can.text = "dayaniklilik : " + dayaniklilik.ToString();
        puan.text = "seviye puani : " + seviye.ToString();
    }
}
