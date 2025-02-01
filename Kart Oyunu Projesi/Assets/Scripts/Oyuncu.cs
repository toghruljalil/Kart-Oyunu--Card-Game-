using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Oyuncu : MonoBehaviour
{
    public string OyuncuAdi;
    public int OyuncuID;
    public string BilgisayarAdi;
    public int BilgisayarID;
    public int OyuncuSkor;
    public int BilgisayarSkor;
    
    [SerializeField] private KartDagitmaOp KartListesi;
    [SerializeField] private Transform[] OrtaOP;
    public Transform[] Orta;

    [SerializeField] private TMP_Text SkorOyuncu;
    [SerializeField] private TMP_Text SkorBilgisayar;
    [SerializeField] private TMP_Text AdOyuncu;
    [SerializeField] private TMP_Text AdBilgisayar;
    public List<GameObject> secilenKartlarOp = new List<GameObject>();

    private void Start()
    {
        SkorGoster();
    }

    public Oyuncu()
    {
        BilgisayarAdi = "Bilgisayar";
        BilgisayarID = 0;
        BilgisayarSkor = 0;
    }

    public Oyuncu(string oyuncuAdi, int oyuncuID, int oyuncuSkor)
    {
        OyuncuAdi = oyuncuAdi;
        OyuncuID = oyuncuID;
        OyuncuSkor = oyuncuSkor;
    }

    public void SkorGoster()
    {
        AdOyuncu.text = PlayerPrefs.GetString("OyuncuAdi") + "(ID:" + PlayerPrefs.GetString("OyuncuID") + ")";
        SkorOyuncu.text = OyuncuSkor.ToString();
        AdBilgisayar.text = BilgisayarAdi;
        SkorBilgisayar.text = BilgisayarSkor.ToString();
    }

    void KartRenginiSifirla(GameObject kart)
    {
        Renderer renderer = kart.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.white;
        }
    }

    public void BilgisayarSecim()
    {
        if (KartListesi.EldekiKartlarOp.Count >= 3)
        {
            while (secilenKartlarOp.Count < 3)
            {
                int randomIndex = Random.Range(0, KartListesi.EldekiKartlarOp.Count);
                GameObject kart = KartListesi.EldekiKartlarOp[randomIndex];

                if (!secilenKartlarOp.Contains(kart))
                {
                    secilenKartlarOp.Add(kart);
                }
            }

            for(int i = 0; i<secilenKartlarOp.Count; i++)
            {
                secilenKartlarOp[i].transform.position = OrtaOP[i].transform.position;
                secilenKartlarOp[i].transform.rotation = OrtaOP[i].transform.rotation;
            }

            foreach (GameObject kart in secilenKartlarOp)
            {
                Debug.Log($"Secilen Kart: {kart.name}");
            }
        }
        else
        {
            Debug.Log("Liste 3 elemandan az!");
        }
    }
}
