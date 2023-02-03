using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosingGhost : MonoBehaviour
{
    [SerializeField] private GameObject[] ghost;
    private int ghostID = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextGhost()
    {
        ghostID++;
        if(ghostID >= ghost.Length)
        {
            ghostID = 0;
        }

        for (int i = 0; i < ghost.Length; i++)
        {
            if (i == ghostID)
            {
                ghost[i].SetActive(true);
            }
            else
            {
                ghost[i].SetActive(false);
            }
        }
    }

    public void PreviousGhost()
    {
        ghostID--;
        if (ghostID < 0)
        {
            ghostID = ghost.Length - 1;
        }
        
        for (int i = 0; i < ghost.Length; i++)
        {
            if (i == ghostID)
            {
                ghost[i].SetActive(true);
            }
            else
            {
                ghost[i].SetActive(false);
            }
        }
    }
}
