using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartDagitmaOp : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform spawnPoint; 
    [SerializeField] private Vector3 rotation;
    public List<GameObject> EldekiKartlarOp = new List<GameObject>();

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
        for (int i = 0; i < 6; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject yeniKart = Instantiate(prefabs[randomIndex], spawnPoint.position, Quaternion.Euler(rotation));
            EldekiKartlarOp.Add(yeniKart);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
