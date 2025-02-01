using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartDagitma : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private GameObject[] butonlar;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private GameObject Message;
    [SerializeField] private GameObject parentObject;
    public List<GameObject> EldekiKartlar = new List<GameObject>();
    public List<GameObject> EldekiButonlar = new List<GameObject>();

    void Start()
    {
        Invoke("KartlariCagir", 7f);
    }

    private void KartlariCagir()
    {
        StartCoroutine(SpawnRandomPrefabs());
    }

    IEnumerator SpawnRandomPrefabs()
    {
        Message.SetActive(true);
        for (int i = 0; i < 6; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject yeniKart = Instantiate(prefabs[randomIndex], spawnPoint.position, Quaternion.Euler(rotation));
            GameObject yeniButon = Instantiate(butonlar[randomIndex], parentObject.transform);
            EldekiKartlar.Add(yeniKart);
            EldekiButonlar.Add(yeniButon);
            yield return new WaitForSeconds(0.5f);
        }
        Message.SetActive(false);
    }
}