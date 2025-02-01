using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButonlaKartSec : MonoBehaviour
{
    private KartDagitma Dagitici;
    private Oyun Oynatici;
    public void OnButtonClick(GameObject clickedButton)
    {
        GameObject obj = GameObject.FindWithTag("Manager");
        if (obj != null)
        {
            Dagitici = obj.GetComponent<KartDagitma>();
            Oynatici = obj.GetComponent<Oyun>();
        }
        int index = Dagitici.EldekiButonlar.IndexOf(clickedButton);
        Oynatici.secilenKartlar.Add(Dagitici.EldekiKartlar[index]);
        clickedButton.GetComponent<Image>().color = Color.yellow;
        Oyun.SecilenKartSayisi++;
    }
}
