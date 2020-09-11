using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GC : MonoBehaviour
{
    private float time = 0f;
    public GameObject P1a, P1b, P2a, P2b, P3a, P3b, P4a, P4b;
    private string escolha1, escolha2, escolha3, escolha4;

    public int campeao;
    public int p1, p2, p3, p4;

	// Use this for initialization
	void Start ()
    {
        escolha1 = PlayerPrefs.GetString("escolha1").ToString(); //salvar como P1a, P1b, etc
        escolha2 = PlayerPrefs.GetString("escolha2").ToString();
        escolha3 = PlayerPrefs.GetString("escolha3").ToString();
        escolha4 = PlayerPrefs.GetString("escolha4").ToString();

        campeao = 0;
        p1 = 0;
        p2 = 0;
        p3 = 0;
        p4 = 0;

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
        time += Time.deltaTime;

        if (time <= 3)
        {
            
        }
        else if(time > 3 && time < 4)
        {
            if (escolha1 == "P1a")
                P1a.SetActive(true);
            else if (escolha1 == "P1b")
                P1b.SetActive(true);
            else
                p1 = -1;

            if (escolha2 == "P2a")
                P2a.SetActive(true);
            else if (escolha2 == "P2b")
                P2b.SetActive(true);
            else
                p2 = -1;

            if (escolha3 == "P3a")
                P3a.SetActive(true);
            else if (escolha3 == "P3b")
                P3b.SetActive(true);
            else
                p3 = -1;

            if (escolha4 == "P4a")
                P4a.SetActive(true);
            else if (escolha4 == "P4b")
                P4b.SetActive(true);
            else
                p4 = -1;
        }
        else
        {
            if ((p1 > p2) && (p1 > p3) && (p1 > p4))
            {
                campeao = 1;
                PlayerPrefs.SetInt("Campeao", campeao);
                SceneManager.LoadScene("Winner");
            }

            if ((p2 > p1) && (p2 > p3) && (p2 > p4))
            {
                campeao = 2;
                PlayerPrefs.SetInt("Campeao", campeao);
                SceneManager.LoadScene("Winner");
            }

            if ((p3 > p1) && (p3 > p2) && (p3 > p4))
            {
                campeao = 3;
                PlayerPrefs.SetInt("Campeao", campeao);
                SceneManager.LoadScene("Winner");
            }

            if ((p4 > p1) && (p4 > p3) && (p4 > p2))
            {
                campeao = 4;
                PlayerPrefs.SetInt("Campeao", campeao);
                SceneManager.LoadScene("Winner");
            }
        }        
    }
}
