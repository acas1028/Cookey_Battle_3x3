using System.Collections;

using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;



public class LoadingSceneManager : MonoBehaviour

{

    public static int nextScene;

    int time = 0;

    
    [SerializeField]
    Image progressBar;
    [SerializeField]
    Text text;



    private void Start()

    {

        StartCoroutine(LoadScene());

    }


    public static void LoadScene(int sceneNum)
    {

        nextScene = sceneNum;

        SceneManager.LoadScene("LoadingScene");
    }



    IEnumerator LoadScene()

    {

        yield return null;



        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);

        op.allowSceneActivation = false;



        float timer = 0.0f;

        while (!op.isDone)

        {

            yield return null;



            timer += Time.deltaTime;



            if (op.progress < 0.9f)

            {

                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);

                if (progressBar.fillAmount >= op.progress)

                {
                    timer = 0f;

                }

            }

            else

            {
                time++;
                if (time > 300)
                { 
                    text.gameObject.SetActive(true); 
                }
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);



                if (Input.GetKeyDown(KeyCode.Space))

                {

                    op.allowSceneActivation = true;

                    yield break;

                }

            }

        }

    }

}