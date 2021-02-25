using System.Collections;

using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;



public class LoadingSceneManager : MonoBehaviour

{

    public static int nextScene;

    int time = 0;

    bool isClick;
    
    [SerializeField]
    Image progressBar;
    [SerializeField]

    public Image backGroundImage;
    public Sprite backGroundImageSource;
    public GameObject nextButton;
    public GameObject backGroundImageObject;

    private void Start()

    {
        isClick = false;
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
                    backGroundImageObject.GetComponent<Animator>().SetBool("isLoadingFinish", true);
                    backGroundImage.sprite = backGroundImageSource;

                    yield return new WaitForSeconds(1.5f);
                    nextButton.gameObject.SetActive(true);

                }
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);



                if (isClick == true)
                {

                    op.allowSceneActivation = true;

                    yield break;

                }

            }

        }

    }

    public void isClicked()
    {
        isClick = true;
    }

}