using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hava : SavasAraclari
{
    public Hava(int dayaniklilik, int vurus, int seviyepuani, string sinif)
        : base(dayaniklilik, vurus, seviyepuani, sinif) { }

    public abstract int KaraVurusAvantaji { get; set; }
    public abstract string AltSinif { get; set; }
}
