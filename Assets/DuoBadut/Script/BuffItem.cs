using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItem : MonoBehaviour
{
    public GameObject[] item;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("buff3") == 1)
        {
            i = Random.Range(0, item.Length);
            Instantiate(item[i], transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("buff3", 0);
        }
    }
}
