using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject title;
    public GameObject menu;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button quitButton;

    public List<Button> returnButtons;

    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // �� ����
    public void StartGame()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void HideAll()
    {
        title.SetActive(false);
        menu.SetActive(false);
    }

    public void EnableMainMenu()
    {
        title.SetActive(true);
        menu.SetActive(true);
    }
}
