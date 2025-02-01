using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SavasAraclari : MonoBehaviour
{
    public abstract int Dayaniklilik { get; set; }
    public abstract int Vurus { get; set; }
    public abstract string Sinif { get; set; }
    public abstract int SeviyePuani { get; set; }

    public SavasAraclari(int dayaniklilik, int vurus, int seviyepuani, string sinif)
    {
        Dayaniklilik = dayaniklilik;
        Vurus = vurus;
        SeviyePuani = seviyepuani;
        Sinif = sinif;
    }

    public abstract void KartPuaniGoster();
    public abstract void DurumGuncelle(int dayaniklilik, int hasar);
}
