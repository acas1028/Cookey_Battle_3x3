using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class job_ability : MonoBehaviour
{
    public List<Sprite> job_Ability = new List<Sprite>();
    public GameObject first_Job;
    public GameObject second_Job;

    private int RandomJobAbility()
    {
        int number = 0;
        number = Random.Range(0, 8);
        return number;
    }

    private void ShowjobAbility()
    {
        int job_Number = RandomJobAbility();
        Debug.Log(job_Number);
        first_Job.GetComponent<Image>().sprite = job_Ability[job_Number];

        job_Number = RandomJobAbility();
        second_Job.GetComponent<Image>().sprite = job_Ability[job_Number];

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ShowjobAbility();
        }
        

    }


}
