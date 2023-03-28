using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{
    private GameObject objectGen;
    void Awake()
    {
        objectGen = GameObject.Find("objectManager");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.collider.tag);
        if (other.collider.CompareTag("ground"))
        {
            // Debug.Log(gameObject.name);
            ObjectPool.Instance.PushObject(gameObject);
        }
        objectGen.GetComponent<objectManager>().RemoveFromList(gameObject);
    }
}
