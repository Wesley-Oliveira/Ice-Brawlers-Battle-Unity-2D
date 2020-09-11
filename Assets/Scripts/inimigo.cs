using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public GameObject knockForcePrefab;
    public Transform knockPositionEsquerda, knockPositionDireita;

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "arma":
                Transform quemBateu = col.gameObject.transform.parent;

                if (quemBateu.transform.localPosition.x < transform.localPosition.x)
                {
                    //bota o r pra esquerda
                    GameObject knockTemp = Instantiate(knockForcePrefab, knockPositionEsquerda.position, knockPositionEsquerda.localRotation);
                    Destroy(knockTemp, 0.03f);
                    print("Tomei dano Esquerda");
                }
                else if (quemBateu.transform.localPosition.x > transform.localPosition.x)
                {
                    //bota o r pra direita                   
                    GameObject knockTemp = Instantiate(knockForcePrefab, knockPositionDireita.position, knockPositionDireita.localRotation);
                    Destroy(knockTemp, 0.03f);
                    print("Tomei dano Direita");
                }
                else
                {

                } 
                break;
        }
    }
}
