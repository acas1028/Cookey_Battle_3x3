using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject fader;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Activate());
    }

    // Update is called once per frame
    IEnumerator Activate()
    {
        fader.GetComponent<FadeController>().FadeOut(0.7f,() => fader.SetActive(false));

        yield return new WaitForSeconds(3f);
    }
}
