using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Page;
using UnityEngine.UI;

public class PaginasInterface : MonoBehaviour
{
    public static Paginas paginas ;
    
    public GameObject left ;
    public GameObject right  ;

    public GameObject[] fichasdisplay = new GameObject[3];

    void Start()
    {
        Next();
        left.SetActive(false);
    }
    public void Back( )
    {
        if ( paginas == null) throw new System.Exception("Las paginas estan nulas ");

        paginas.Back();
        for (int i = 0; i < fichasdisplay.Length; i++)
        {   if(i<paginas.actual.Count)
            {
                fichasdisplay[i].GetComponent<CardInfo>().Load(paginas.actual[i]);
                fichasdisplay[i].SetActive(true);
            }
            else
            fichasdisplay[i].SetActive(false);
        }


        if(paginas.atras.Count== 0)
        {
            left.SetActive(false);
        }
        if(paginas.adelante.Count>0)
        {
            right.SetActive(true);
        }

    }

    public void Next()
    {
        if ( paginas == null) throw new System.Exception("Las paginas estan nulas ");
        
        paginas.Next();

        
        
        for (int i = 0; i < fichasdisplay.Length; i++)
        {   if(i<paginas.actual.Count)
            {
                fichasdisplay[i].GetComponent<CardInfo>().Load(paginas.actual[i]);
                fichasdisplay[i].SetActive(true);
            }
            else
            fichasdisplay[i].SetActive(false);
        }

        if(paginas.adelante.Count== 0)
        {
            right.SetActive(false);
        }
        if(paginas.atras.Count>0)
        {
            left.SetActive(true);
        }
        
    }
}