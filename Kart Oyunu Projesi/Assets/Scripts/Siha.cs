using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Siha : Hava
{
    [SerializeField] private TMP_Text dayaniklik_text;
    [SerializeField] private TMP_Text seviyePuani_text;
    public override int Dayaniklilik { get; set; }
    public override int SeviyePuani { get; set; }
    public override int Vurus { get; set; }
    public override string Sinif { get; set; }
    public override int KaraVurusAvantaji { get; set; } = 10;
    public override string AltSinif { get; set; } = "Siha";

    public int DenizVurusSiha = 10;

    public Siha() : base(15, 10, 0, "Hava") { }

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