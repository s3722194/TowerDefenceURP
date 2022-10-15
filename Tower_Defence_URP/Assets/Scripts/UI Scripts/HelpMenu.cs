using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> passes = new List<GameObject>();    
    [SerializeField] private GameObject HelpMenuCanvas;    
    [SerializeField] private GameObject MainMenuCanvas;

    private int i;

    // Start is called before the first frame update
    void OnEnable()
    {
        i = 0;

        if(passes.Count > 0)
        {
            for(int index = 0; index < passes.Count; index++)
            {
                passes[index].SetActive(false);
            }

            passes[i].SetActive(true);
        }

        Debug.Log("show passes[" + i + "]");
    }

    public void RestartPasses()
    {
        i = 0;

        if (passes.Count > 0)
        {
            for (int index = 0; index < passes.Count; index++)
            {
                passes[index].SetActive(false);
            }

            passes[i].SetActive(true);
        }

        Debug.Log("show passes[" + i + "]");
    }

    public void NextPass()
    {
        if(i + 1 < passes.Count)
        {
            passes[i].SetActive(false);
            i++;
            passes[i].SetActive(true);
        } else
        {
            MainMenuCanvas.SetActive(true);
            HelpMenuCanvas.SetActive(false);
        }
    }

    public void BackPass()
    {
        if (i - 1 >= 0)
        {
            passes[i].SetActive(false);
            i--;
            passes[i].SetActive(true);
        } else
        {
            MainMenuCanvas.SetActive(true);
            HelpMenuCanvas.SetActive(false);
        }
    }

    public void ToMenu()
    {
        MainMenuCanvas.SetActive(true);
        HelpMenuCanvas.SetActive(false);
    }
}
