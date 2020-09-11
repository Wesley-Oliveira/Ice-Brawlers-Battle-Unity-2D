using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    public GameObject P1a, P1b, P2a, P2b, P3a, P3b, P4a, P4b;
    private string escolha1, escolha2, escolha3, escolha4;
    private int campeao;

    void Start()
    {
        escolha1 = PlayerPrefs.GetString("escolha1").ToString(); //salvar como P1a, P1b, etc
        escolha2 = PlayerPrefs.GetString("escolha2").ToString();
        escolha3 = PlayerPrefs.GetString("escolha3").ToString();
        escolha4 = PlayerPrefs.GetString("escolha4").ToString();

        campeao = PlayerPrefs.GetInt("Campeao");

        P1a.SetActive(false);
        P1b.SetActive(false);
        P2a.SetActive(false);
        P2b.SetActive(false);
        P3a.SetActive(false);
        P3b.SetActive(false);
        P4a.SetActive(false);
        P4b.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (campeao == 1)
        {
            if (escolha1 == "P1a")
                P1a.SetActive(true);
            else if (escolha1 == "P1b")
                P1b.SetActive(true);
        }
        else if(campeao == 2)
        {
            if (escolha2 == "P2a")
                P2a.SetActive(true);
            else if (escolha2 == "P2b")
                P2b.SetActive(true);
        }
        else if(campeao == 3)
        {
            if (escolha3 == "P3a")
                P3a.SetActive(true);
            else if (escolha3 == "P3b")
                P3b.SetActive(true);
        }
        else if(campeao == 4)
        {
            if (escolha4 == "P4a")
                P4a.SetActive(true);
            else if (escolha4 == "P4b")
                P4b.SetActive(true);
        }
    }
}
