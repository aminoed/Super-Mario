using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnManager : MonoBehaviour
{
    public Button startBtn;
    public Button exitBtn;
    public Button againBtn;

    // Use this for initialization
    void Start()
    {
        if (startBtn != null)
            startBtn.onClick.AddListener(StartGame);
        if (againBtn != null)
            againBtn.onClick.AddListener(PlayAgain);
        exitBtn.onClick.AddListener(ExitGame);
    }
    void StartGame()
    {
        //Loading Scene1
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

        // Debug.Log("已执行退出");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        // Debug.Log("已执行游戏");
    }
}
