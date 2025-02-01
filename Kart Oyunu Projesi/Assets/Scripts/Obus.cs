using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obus : Kara
{
    [SerializeField] private TMP_Text dayaniklik_text;
    [SerializeField] private TMP_Text seviyePuani_text;
    public override int Dayaniklilik { get; set; }
    public override int SeviyePuani { get; set; }
    public override int Vurus { get; set; }
    public override string Sinif { get; set; }
    public override int DenizVurusAvantaji { get; set; } = 5;
    public override string AltSinif { get; set; } = "Obus";

    public Obus() : base(20, 10, 0, "Kara") { }

    public override void KartPuaniGoster()
    {
        dayaniklik_text.text = "DAYANIKLILIK : " + Dayaniklilik.ToString();
        seviyePuani_text.text = "SEVIYE PUANI : " + SeviyePuani.ToString();
    }

    public override void DurumGuncelle(int dayaniklilik, int hasar)
    {
        dayaniklilik = dayaniklilik - hasar;
    }

    private void Start()
    {
        KartPuaniGoster();
    }
}