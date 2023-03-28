using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class board : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Text life;
    [SerializeField] private Text point;
    [SerializeField] private Text finalPoint;
    [SerializeField] private GameObject gameOver;
    void Start()
    {
        // Debug.Log(life.text);

    }

    // Update is called once per frame
    void Update()
    {
        life.text = player.GetComponent<player>().life.ToString();
        point.text = player.GetComponent<player>().bonus.ToString();
        if (int.Parse(life.text) <= 0)
        {
            gameOver.SetActive(true);
            finalPoint.text = player.GetComponent<player>().bonus.ToString();
        }
    }
}
