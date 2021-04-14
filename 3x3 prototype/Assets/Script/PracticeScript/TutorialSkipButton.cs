using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSkipButton : MonoBehaviour
{

    public GameObject practicemodeSelect;

    public GameObject tutorialInput;

    public void SkipButton()
    {
        practicemodeSelect.SetActive(true);

        tutorialInput.SetActive(false);

    }
}
