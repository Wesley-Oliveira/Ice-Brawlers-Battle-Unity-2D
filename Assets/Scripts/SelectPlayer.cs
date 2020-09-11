using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{
    public GameObject P1a, P1b, PressStartP1;
    public GameObject P2a, P2b, PressStartP2;
    public GameObject P3a, P3b, PressStartP3;
    public GameObject P4a, P4b, PressStartP4;

    private float h1, h2, h3, h4;
    private bool entrou1, entrou2, entrou3, entrou4;
    private int pos1, pos2, pos3, pos4;
    private int jafoi = 0, jafoi2 = 0, jafoi3 = 0, jafoi4 = 0;
    private int countPlayers, countReady;
    private bool selecionado1, selecionado2, selecionado3, selecionado4;
    // Use this for initialization
    void Start()
    {
        entrou1 = false;
        entrou2 = false;
        entrou3 = false;
        entrou4 = false;
        selecionado1 = false;
        selecionado2 = false;
        selecionado3 = false;
        selecionado4 = false;
        pos1 = 0;
        pos2 = 0;
        pos3 = 0;
        pos4 = 0;
        countPlayers = 0;
        countReady = 0;
        P1a.SetActive(false);
        P1b.SetActive(false);
        P2a.SetActive(false);
        P2b.SetActive(false);
        P3a.SetActive(false);
        P3b.SetActive(false);
        P4a.SetActive(false);
        P4b.SetActive(false);

        PressStartP1.SetActive(true);
        PressStartP2.SetActive(true);
        PressStartP3.SetActive(true);
        PressStartP4.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        h1 = Input.GetAxisRaw("HP1");
        h2 = Input.GetAxisRaw("HP2");
        h3 = Input.GetAxisRaw("HP3");
        h4 = Input.GetAxisRaw("HP4");

        //Entra pra jogar
        if (Input.GetButtonDown("AP1") && jafoi == 0)
        {
            entrou1 = true;
            jafoi = 1;
            countPlayers++;
            P1a.SetActive(true);
            PressStartP1.SetActive(false);
            print("Entrou");
        }
        //confirmando personagem
        else if (entrou1 == true && Input.GetButtonDown("AP1"))
        {
            if (P1a.activeSelf == true)
            {
                print("Selecionou e confirmou");
                PlayerPrefs.SetString("escolha1", "P1a");
                selecionado1 = true;
                countReady++;
            }
            else if (Input.GetButtonDown("AP1") && P1b.activeSelf == true)
            {
                print("Selecionou e confirmou");
                PlayerPrefs.SetString("escolha1", "P1b");
                selecionado1 = true;
                countReady++;
            }
        }
        if (Input.GetButtonDown("AP2") && jafoi2 == 0)
        {
            entrou2 = true;
            jafoi2 = 1;
            countPlayers++;
            P2a.SetActive(true);
            PressStartP2.SetActive(false);
        }
        else if (entrou2 == true && Input.GetButtonDown("AP2")) //confirma o que tá selecionado
        {
            if (P2a.activeSelf == true)
            {
                PlayerPrefs.SetString("escolha2", "P2a");
            }
            else if (P2b.activeSelf == true)
            {
                PlayerPrefs.SetString("escolha2", "P2b");
            }
            selecionado2 = true;
            countReady++;

        }
        if (Input.GetButtonDown("AP3") && jafoi3 == 0)
        {
            entrou3 = true;
            jafoi3 = 1;
            countPlayers++;
            P3a.SetActive(true);
            PressStartP3.SetActive(false);
        }
        else if (entrou3 == true && Input.GetButtonDown("AP3")) //confirma o que tá selecionado
        {
            if (P3a.activeSelf == true)
            {
                PlayerPrefs.SetString("escolha3", "P3a");
            }
            else if (P3b.activeSelf == true)
            {
                PlayerPrefs.SetString("escolha3", "P3b");
            }
            selecionado3 = true;
            countReady++;

        }
        if (Input.GetButtonDown("AP4") && jafoi4 == 0)
        {
            entrou4 = true;
            jafoi4 = 1;
            countPlayers++;
            P4a.SetActive(true);
            PressStartP4.SetActive(false);
        }
        else if (entrou4 == true && Input.GetButtonDown("AP4")) //confirma o que tá selecionado
        {
            if (P4a.activeSelf == true)
            {
                PlayerPrefs.SetString("escolha4", "P4a");
            }
            else if (P4b.activeSelf == true)
            {
                PlayerPrefs.SetString("escolha4", "P4b");
            }
            selecionado4 = true;
            countReady++;
        }

        //cancelando player
        if (Input.GetButtonDown("XP1") && entrou1 == true)
        {
            entrou1 = false;
            jafoi = 0;
            pos1 = 0;
            countPlayers--;
            P1a.SetActive(false);
            P1b.SetActive(false);
            PressStartP1.SetActive(true);
            print("Saiu");
        }
        if (Input.GetButtonDown("XP2") && entrou2 == true)
        {
            entrou2 = false;
            jafoi2 = 0;
            pos2 = 0;
            countPlayers--;
            P2a.SetActive(false);
            P2b.SetActive(false);
            PressStartP2.SetActive(true);
        }
        if (Input.GetButtonDown("XP3") && entrou3 == true)
        {
            entrou3 = false;
            jafoi3 = 0;
            pos3 = 0;
            countPlayers--;
            P3a.SetActive(false);
            P3b.SetActive(false);
            PressStartP3.SetActive(true);
        }
        if (Input.GetButtonDown("XP4") && entrou4 == true)
        {
            entrou4 = false;
            jafoi4 = 0;
            pos4 = 0;
            countPlayers--;
            P4a.SetActive(false);
            P4b.SetActive(false);
            PressStartP4.SetActive(true);
        }

        //passa os personagens
        if (h1 != 0 && selecionado1 == false && entrou1 == true)
        {
            if (pos1 == 0 && h1 > 0)
            {
                pos1++;

                P1a.SetActive(false);
                P1b.SetActive(true);
                print("passou");
            }
            else if (pos1 == 1 && h1 < 0)
            {
                pos1--;
                print("voltou");
                P1a.SetActive(true);
                P1b.SetActive(false);
            }
        }
        if (h2 != 0 && selecionado2 == false && entrou2 == true)
        {
            if (pos2 == 0 && h2 > 0)
            {
                pos2++;

                P2a.SetActive(false);
                P2b.SetActive(true);
            }
            else if (pos2 == 1 && h2 < 0)
            {
                pos2--;

                P2a.SetActive(true);
                P2b.SetActive(false);
            }
        }
        if (h3 != 0 && selecionado3 == false && entrou3 == true)
        {
            if (pos3 == 0 && h3 > 0)
            {
                pos3++;

                P3a.SetActive(false);
                P3b.SetActive(true);
            }
            else if (pos3 == 1 && h3 < 0)
            {
                pos3--;

                P3a.SetActive(true);
                P3b.SetActive(false);
            }
        }
        if (h4 != 0 && selecionado4 == false && entrou4 == true)
        {
            if (pos4 == 0 && h4 > 0)
            {
                pos4++;

                P4a.SetActive(false);
                P4b.SetActive(true);
            }
            else if (pos4 == 1 && h4 < 0)
            {
                pos4--;

                P4a.SetActive(true);
                P4b.SetActive(false);
            }
        }

        //cancelando confirmação XP1
        if (selecionado1 == true && Input.GetButtonDown("XP1"))
        {
            selecionado1 = false;
            countReady--;
            PlayerPrefs.SetString("escolha1", "");
        }
        if (selecionado2 == true && Input.GetButtonDown("XP2"))
        {
            selecionado2 = false;
            countReady--;
            PlayerPrefs.SetString("escolha2", "");
        }
        if (selecionado3 == true && Input.GetButtonDown("XP3"))
        {
            selecionado3 = false;
            countReady--;
            PlayerPrefs.SetString("escolha3", "");
        }
        if (selecionado4 == true && Input.GetButtonDown("XP4"))
        {
            selecionado4 = false;
            countReady--;
            PlayerPrefs.SetString("escolha4", "");
        }

        //passando scene
        if (Input.GetButtonDown("BP1") && ((selecionado1 && selecionado2 && selecionado3 && selecionado4) || (selecionado1 && selecionado2 && selecionado3) || (selecionado1 && selecionado2) || (selecionado1 || selecionado2 || selecionado3 || selecionado4)))
        {
            //random de levels
            int randQuallugar = Random.Range(1, 3);

            if(randQuallugar == 1)
                SceneManager.LoadScene("Globo");
            else
                SceneManager.LoadScene("QG");
        }        
    }
}
