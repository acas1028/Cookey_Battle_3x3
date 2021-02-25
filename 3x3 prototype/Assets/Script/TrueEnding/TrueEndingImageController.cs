using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueEndingImageController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fader;

    void Start()
    {
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        fader.GetComponent<FadeController>().FadeIn(0.7f);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(16);
    }
}
