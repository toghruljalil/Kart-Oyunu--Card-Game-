using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Oyun : MonoBehaviour
{
    [SerializeField] private Oyuncu Oyuncu;
    [SerializeField] private GameObject Buton;
    [SerializeField] private GameObject Liste;
    [SerializeField] private KartDagitma Kartlar;
    [SerializeField] private KartDagitmaOp KartlarOp;
    [SerializeField] private Transform DesteKonum;
    [SerializeField] private Transform DesteKonumOp;
    [SerializeField] private Vector3 rotasyonOp;
    [SerializeField] private Vector3 rotasyon;
    [SerializeField] private Transform area;
    [SerializeField] private GameObject[] yenikartlar;
    [SerializeField] private GameObject[] yenibutonlar;
    [SerializeField] private GameObject YeniKartVerme;
    [SerializeField] private GameObject OyunBitti;
    [SerializeField] private GameObject OyunBittiOp;
    [SerializeField] private TMP_Text HamleDisplayer;
    private int toplamhasar;
    private int puan;
    private int HamleSayisi;
    private int MevcutHamle = 1;
    private int indis;
    private int bitis = 0;
    private string dosyaYolu;
    static public int SecilenKartSayisi;
    public List<GameObject> secilenKartlar = new List<GameObject>();
    public void Main(string[] args)
    {
        Ucak UcakKarti = new Ucak();
        Siha SihaKarti = new Siha();
        Obus ObusKarti = new Obus();
        KFS KFSKarti = new KFS();
        Firkateyn FirkateynKarti = new Firkateyn();
        Sida SidaKarti = new Sida();

        UcakKarti.KartPuaniGoster();
        SihaKarti.KartPuaniGoster();
        ObusKarti.KartPuaniGoster();
        KFSKarti.KartPuaniGoster();
        FirkateynKarti.KartPuaniGoster();
        SidaKarti.KartPuaniGoster();
    }

    private void Start()
    {
        HamleSayisi = int.Parse(PlayerPrefs.GetString("Hamle"));
        Invoke("ButonAktif", 10f);
    }

    private void Update()
    {
        if (SecilenKartSayisi == 3)
        {
            SecilenKartSayisi = 0;
            Invoke("ListeKapa", 0.5f);
            Invoke("BilgisayarKartSecimi", 1f);
            Invoke("SaldiriHesapla", 3f);
        }
    }

    private void ButonAktif()
    {
        HamleDisplayer.text = "Hamle : " + MevcutHamle;
        Buton.SetActive(true);
    }

    private void BilgisayarKartSecimi()
    {
        Oyuncu.BilgisayarSecim();
    }

    public void ListeAc()
    {
        Liste.SetActive(true);
        Buton.SetActive(false);
    }

    private void ListeKapa()
    {
        Liste.SetActive(false);
        Invoke("KartlarOrtaya", 0.5f);
    }

    private void KartlarOrtaya()
    {
        for (int i = 0; i < secilenKartlar.Count; i++)
        {
            secilenKartlar[i].transform.position = Oyuncu.Orta[i].transform.position;
            secilenKartlar[i].transform.rotation = Oyuncu.Orta[i].transform.rotation;
        }
    }

    private void KartlarDesteye()
    {
        if (MevcutHamle == HamleSayisi)
        {
            Time.timeScale = 0;
            if(Oyuncu.BilgisayarSkor > Oyuncu.OyuncuSkor)
            {
                OyunBittiOp.SetActive(true);
            }
            else
            {
                OyunBitti.SetActive(true);
            }
        }
        else if (bitis > 0)
        {
            Time.timeScale = 0;
            if(bitis == 1)
            {
                OyunBittiOp.SetActive(true);
            }
            else if (bitis == 2)
            {
                OyunBitti.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < secilenKartlar.Count; i++)
            {
                if (secilenKartlar[i] != null)
                {
                    secilenKartlar[i].transform.position = DesteKonum.position;
                }
            }
            for (int i = 0; i < Oyuncu.secilenKartlarOp.Count; i++)
            {
                if (Oyuncu.secilenKartlarOp[i] != null)
                {
                    Oyuncu.secilenKartlarOp[i].transform.position = DesteKonumOp.position;
                    Oyuncu.secilenKartlarOp[i].transform.rotation = Quaternion.Euler(rotasyonOp);
                }
            }
            Oyuncu.secilenKartlarOp.Clear();
            secilenKartlar.Clear();
            MevcutHamle++;
            if (Kartlar.EldekiKartlar.Count < 2)
            {
                StartCoroutine("YeniKart");
                bitis = 1;
            }
            if(KartlarOp.EldekiKartlarOp.Count < 2)
            {
                StartCoroutine("YeniKartOp");
                bitis = 2;
            }
            StartCoroutine("YeniKart");
            StartCoroutine("YeniKartOp");
        }
    }

    private void SaldiriHesapla()
    {
        for (int i = 0; i < 3; i++)
        {
            toplamhasar = 0;
            ObjectParameters script = secilenKartlar[i].GetComponent<ObjectParameters>();
            ObjectParameters scriptOP = Oyuncu.secilenKartlarOp[i].GetComponent<ObjectParameters>();
            int index = Kartlar.EldekiKartlar.IndexOf(secilenKartlar[i]);
            ObjectParameters scriptbutton = Kartlar.EldekiButonlar[index].GetComponent<ObjectParameters>();
            if (scriptOP.sinif == "Hava")
            {
                toplamhasar += script.havavurus;
            }
            if (scriptOP.sinif == "Deniz")
            {
                toplamhasar += script.denizvurus;
            }
            if (scriptOP.sinif == "Kara")
            {
                toplamhasar += script.karavurus;
            }
            toplamhasar += script.vurus;
            scriptOP.dayaniklilik -= toplamhasar;

            toplamhasar = 0;
            if (script.sinif == "Hava")
            {
                toplamhasar += scriptOP.havavurus;
            }
            if (script.sinif == "Deniz")
            {
                toplamhasar += scriptOP.denizvurus;
            }
            if (script.sinif == "Kara")
            {
                toplamhasar += scriptOP.karavurus;
            }
            toplamhasar += scriptOP.vurus;
            script.dayaniklilik -= toplamhasar;
            scriptbutton.dayaniklilik -= toplamhasar;

            if (script.dayaniklilik <= 0)
            {
                if (script.seviye <= 10)
                {
                    puan = 10;
                }
                else
                {
                    puan = script.seviye;
                }
                scriptOP.seviye += puan;
                Oyuncu.BilgisayarSkor += puan;
                indis = Kartlar.EldekiKartlar.IndexOf(secilenKartlar[i]);
                Kartlar.EldekiKartlar.RemoveAt(indis);
                Kartlar.EldekiButonlar.RemoveAt(indis);
                Destroy(secilenKartlar[i]);
            }
            puan = 0;
            if (scriptOP.dayaniklilik <= 0)
            {
                if (scriptOP.seviye <= 10)
                {
                    puan = 10;
                }
                else
                {
                    puan = scriptOP.seviye;
                }
                script.seviye += puan;
                scriptbutton.seviye += puan;
                Oyuncu.OyuncuSkor += puan;
                indis = KartlarOp.EldekiKartlarOp.IndexOf(Oyuncu.secilenKartlarOp[i]);
                KartlarOp.EldekiKartlarOp.RemoveAt(indis);
                Destroy(Oyuncu.secilenKartlarOp[i]);
            }
            script.SkorGoster();
            scriptbutton.SkorGoster();
            scriptOP.SkorGoster();
            Oyuncu.SkorGoster();
        }
        Invoke("KartlarDesteye", 2f);
        if (Kartlar.EldekiKartlar.Count == 0 && KartlarOp.EldekiKartlarOp.Count == 0)
        {
            Time.timeScale = 0;
            if(Oyuncu.BilgisayarSkor > Oyuncu.OyuncuSkor)
            {
                OyunBittiOp.SetActive(true);
            }
            else if(Oyuncu.OyuncuSkor > Oyuncu.BilgisayarSkor)
            {
                OyunBitti.SetActive(true);
            }
        }
        else if (Kartlar.EldekiKartlar.Count == 0)
        {
            Time.timeScale = 0;
            OyunBittiOp.SetActive(true);
        }
        else if (KartlarOp.EldekiKartlarOp.Count == 0)
        {
            Time.timeScale = 0;
            OyunBitti.SetActive(true);
        }
        
    }

    private IEnumerator YeniKart()
    {
        yield return new WaitForSeconds(1f);
        YeniKartVerme.SetActive(true);
        int randomIndex = Random.Range(0, yenikartlar.Length);
        GameObject yeniKart = Instantiate(yenikartlar[randomIndex], DesteKonum.position, Quaternion.Euler(rotasyon));
        GameObject yeniButon = Instantiate(yenibutonlar[randomIndex], area.transform);
        Kartlar.EldekiKartlar.Add(yeniKart);
        Kartlar.EldekiButonlar.Add(yeniButon);
        yield return new WaitForSeconds(2f);
        YeniKartVerme.SetActive(false);
        ButonAktif();
    }

    private IEnumerator YeniKartOp()
    {
        yield return new WaitForSeconds(1f);
        YeniKartVerme.SetActive(true);
        int randomIndex = Random.Range(0, yenikartlar.Length);
        randomIndex = Random.Range(0, yenikartlar.Length);
        GameObject yeniKartOp = Instantiate(yenikartlar[randomIndex], DesteKonumOp.position, Quaternion.Euler(rotasyonOp));
        KartlarOp.EldekiKartlarOp.Add(yeniKartOp);
        yield return new WaitForSeconds(2f);
        YeniKartVerme.SetActive(false);
        ButonAktif();
    }
}
