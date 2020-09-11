using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator trasitionAnimm;
    public string sceneName;
    public bool isSplash, isWinner;
    public float timeWait;

    void Start()
    {
        if (isSplash)
            StartCoroutine(LoadScene());
        else
            timeWait = 1.5f;
    }

    void Update ()
    {
        if (Input.GetButtonDown("BP1") || Input.GetButtonDown("Start")) //bola "BP" + numberPlayer
            StartCoroutine(LoadScene());
        if (Input.GetButtonDown("Start"))
            StartCoroutine(Winner());
	}

    public void OpenScene(string name)
    {
        sceneName = name;
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        if(isSplash)
        {
            yield return new WaitForSeconds(2.5f);
            trasitionAnimm.SetTrigger("end");
            yield return new WaitForSeconds(timeWait);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            trasitionAnimm.SetTrigger("end");
            yield return new WaitForSeconds(timeWait);
            SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator Winner()
    {
        if (isWinner)
        {
            trasitionAnimm.SetTrigger("end");
            yield return new WaitForSeconds(timeWait);
            SceneManager.LoadScene(sceneName);
        }
    }
}
