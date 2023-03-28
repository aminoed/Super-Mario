using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectManager : MonoBehaviour
{
    public bool spawnObject = true;
    [SerializeField] private GameObject[] objectPrefabs;
    //每一波生成间隔时间
    [SerializeField] private float timeBetweenSpawns = 1f;
    [SerializeField] private float timeBetweenWaves = 1f;
    //等待生成间隔时间
    [SerializeField] private int minNum = 100;
    [SerializeField] private int maxNum = 10000;

    public int waveNum = 1;
    //每一波数量
    int objectNum;
    WaitForSeconds waitTimeBetweenWaves;
    WaitForSeconds waitTimeBetweemSpawns;
    WaitUntil waitUntilNoObject;
    public List<GameObject> objectList;
    private Vector2 genPoint;
    void Awake()
    {
        objectList = new List<GameObject>();
        waitTimeBetweemSpawns = new WaitForSeconds(timeBetweenSpawns);
        waitTimeBetweenWaves = new WaitForSeconds(timeBetweenWaves);
        waitUntilNoObject = new WaitUntil(NoObject);
    }

    bool NoObject()
    {
        return objectList.Count == 0;
    }

    IEnumerator Start()
    {

        while (spawnObject)
        {
            yield return waitUntilNoObject;
            yield return waitTimeBetweenWaves;
            yield return StartCoroutine(nameof(RandomlySpawnCoroutine));
        }
    }

    IEnumerator RandomlySpawnCoroutine()
    {
        objectNum = Random.Range(minNum, maxNum);
        for (int i = 0; i < objectNum; i++)
        {
            genPoint = new Vector2(gameObject.transform.position.x + Random.Range(-7f, 7f), gameObject.transform.position.y);
            GameObject obj = ObjectPool.Instance.GetObject(objectPrefabs[Random.Range(0, objectPrefabs.Length)]);
            obj.transform.position = genPoint;
            objectList.Add(obj);

            // objectPrefabs[index].transform.SetParent()
            yield return waitTimeBetweemSpawns;
        }
        waveNum++;

        if (waveNum >= 100000)
        {
            spawnObject = false;
        }
    }
    public void RemoveFromList(GameObject obj)
    {
        if (objectList.Count >= 0)
        {
            objectList.Remove(obj);
            // Debug.Log("移除了" + (i++) );
            if (waveNum == 4 && objectList.Count == 0)
            {

            }
        }
    }
}
