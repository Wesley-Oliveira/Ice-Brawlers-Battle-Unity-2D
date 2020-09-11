using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enfeite : MonoBehaviour
{
    public GameObject spriteRodar;
    private float time = 0;
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        spriteRodar.transform.rotation = new Quaternion(spriteRodar.transform.rotation.x , spriteRodar.transform.rotation.y, time, spriteRodar.transform.rotation.w);
	}
}
