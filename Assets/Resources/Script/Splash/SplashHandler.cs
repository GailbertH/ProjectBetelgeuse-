using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashHandler : MonoBehaviour
{
    [SerializeField] private CanvasGroup splashCanvas;
    [SerializeField] private Button StartButton;
    [SerializeField] private Text SetupText;
    [SerializeField] private Animation SetupTextAnimation;
    private bool isMenuReady = false;
    //should be handling load balancer
    void Start()
    {
        SetupText.text = "Loading...";
        StartButton.interactable = false;
        SetupData();
    }

    private void SetupComplete()
    {
        SetupText.text = "Tap screen to start.";
        StartButton.interactable = true;

        if (SetupTextAnimation != null)
            SetupTextAnimation.Play();
    }

    private void SetupData()
    {
        StartCoroutine(FakeLoadBalancer());
        SetupLoadManager();
    }

    private void SetupLoadManager()
    {
        var loadSceneAsync = SceneManager.LoadSceneAsync(SceneNames.LOADING_SCREEN, LoadSceneMode.Additive);
        StartCoroutine(LoadStartupScenes(loadSceneAsync));
    }

    public void OnStartButtonPress()
    {
        SetupText.gameObject.SetActive(false);
        StartButton.interactable = false;
        StartCoroutine(FadeOutCoroutine());
        LoadingManager.Instance.ActivateSilentLoadedScene();
    }

    private void UnloadScene()
    {
        if (SetupTextAnimation != null)
            SetupTextAnimation.Stop();
        splashCanvas = null;
        StartButton = null;
        SetupText = null;
        SetupTextAnimation = null;
        LoadingManager.Instance.SetSceneToUnload(SceneNames.SPLASH_SCREEN);
        LoadingManager.Instance.UnloadScene();
    }

    IEnumerator LoadStartupScenes(AsyncOperation loadScene)
    {
        yield return new WaitUntil(() => loadScene.isDone == true && LoadingManager.Instance != null);

        LoadingManager.Instance.SetSceneToLoad(SceneNames.DATA_SCENE);
        yield return LoadingManager.Instance.LoadSceneAsync();
        LoadingManager.Instance.SetSceneToLoad(SceneNames.LOBBY_SCENE);
        LoadingManager.Instance.SilentLoadScene();
        isMenuReady = true;
    }

    IEnumerator FadeOutCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        float time = 0.5f;
        while (splashCanvas.alpha > 0)
        {
            splashCanvas.alpha -= Time.deltaTime / time;
            yield return null;
        }
        UnloadScene();
    }

    IEnumerator FakeLoadBalancer()
    {
        while (!isMenuReady)
        {
            yield return null;
        }

        SetupComplete();
    }
}
