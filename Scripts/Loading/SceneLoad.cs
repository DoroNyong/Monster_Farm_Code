using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoad : MonoBehaviour
{
    
    static string nextScene;

    public Slider progressBar;
    public TMP_Text loadingTxt;

    SoundManager soundManager;

    private void Awake()
    {
        soundManager = SoundManager.instance;
    }

    public static void LoadScene(string scene)
    {
        nextScene = scene;
        SceneManager.LoadScene("Loading");
    }

    private void Start()
    {
        soundManager.StopBGM();
        StartCoroutine(LoadGameLobbyScene());
    }

    IEnumerator LoadGameLobbyScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false; // ���� �񵿱�� �ҷ����� �� �ڵ����� ���� ������ �Ѿ �� �����ϴ� ��. false�� �ϸ� 90%(0.9f)������ ������ �� ��ٸ���.

        while (!operation.isDone)
        {
            yield return null;
            if(progressBar.value < 1f)
            {
                progressBar.value = Mathf.MoveTowards(progressBar.value, 1f, Time.deltaTime); // ���࿡ ���� �ε��ٰ� ��������
            }
            else
            {
                loadingTxt.text = "Press SpaceBar";
            }

            if(Input.GetKeyDown(KeyCode.Space) && progressBar.value >= 1f && operation.progress >= 0.9f)
            {
                soundManager.PlayLoadingEffect();
                operation.allowSceneActivation = true;
            }
        }
    }
}
