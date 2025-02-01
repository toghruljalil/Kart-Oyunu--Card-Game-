using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Deniz : SavasAraclari
{
    public Deniz(int dayaniklilik, int vurus, int seviyepuani, string sinif) : base(dayaniklilik, vurus, seviyepuani, sinif) { }
    public abstract int HavaVurusAvantaji { get; set; }
    public abstract string AltSinif { get; set; }
}
