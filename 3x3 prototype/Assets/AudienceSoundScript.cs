using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSoundScript : MonoBehaviour
{

    public GameObject BeforeGameObject;
    public GameObject SoundBox;

    SoundBoxController soundBoxAudio;
    int playerScore;
    int enemyScore1;
    int enemyScore2;


    // Start is called before the first frame update
    void Start()
    {
        playerScore = BeforeGameObject.GetComponent<BeforeChangeScript>().GetPlayerScore();
        enemyScore1 = BeforeGameObject.GetComponent<BeforeChangeScript>().GetEnemy1Score();
        enemyScore2 = BeforeGameObject.GetComponent<BeforeChangeScript>().GetEnemy2Score();

        soundBoxAudio = SoundBox.GetComponent<SoundBoxController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudience()
    {
        if (playerScore >= enemyScore1 && playerScore >= enemyScore2)
        {
            soundBoxAudio.PlaySound(1);
        }
        else
        {
            soundBoxAudio.PlaySound(2);
        }
    }
}
