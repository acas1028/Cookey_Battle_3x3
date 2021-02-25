using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueEndingCredit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] nextObject;
    public GameObject fader;

    public float waitTime;
    public float fadeInTime;
    public float fadeOutTime;

    void Start()
    {
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        fader.GetComponent<TrueEndingCreditFaderController>().FadeIn(fadeInTime);

        yield return new WaitForSeconds(waitTime);

        int i = 0;
        while (i < nextObject.Length)
        {
            GameObject sub = nextObject[i];
            if (sub.gameObject.tag == "Empty")
                fader.GetComponent<TrueEndingCreditFaderController>().FadeOut(fadeOutTime);
            else
                fader.GetComponent<TrueEndingCreditFaderController>().FadeOut(fadeOutTime, () => sub.SetActive(true));

            i++;
        }
    }
}
