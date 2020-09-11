using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    private GC scriptGC;

    void Start()
    {
        scriptGC = FindObjectOfType(typeof(GC)) as GC;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player1":
                Destroy(col.gameObject);
                scriptGC.p1 -= 1;
                scriptGC.p2 += 1;
                scriptGC.p3 += 1;
                scriptGC.p4 += 1;
                break;
            case "Player2":
                Destroy(col.gameObject);
                scriptGC.p1 += 1;
                scriptGC.p2 -= 1;
                scriptGC.p3 += 1;
                scriptGC.p4 += 1;
                break;
            case "Player3":
                Destroy(col.gameObject);
                scriptGC.p1 += 1;
                scriptGC.p2 += 1;
                scriptGC.p3 -= 1;
                scriptGC.p4 += 1;
                break;
            case "Player4":
                Destroy(col.gameObject);
                scriptGC.p1 += 1;
                scriptGC.p2 += 1;
                scriptGC.p4 += 1;
                scriptGC.p4 -= 1;
                break;
        }
    }
}
