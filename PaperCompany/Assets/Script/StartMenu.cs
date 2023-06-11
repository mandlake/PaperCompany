using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject title;
    public GameObject menu;
    public GameObject settings;
    public GameObject credit;
    public GameObject newLoad;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button settingsButton;
    public Button creditButton;
    public Button quitButton;
    public Button newButton;
    public Button loadButton;

    public List<Button> returnButtons;

    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(EnableNewLoad);
        settingsButton.onClick.AddListener(EnableSettings);
        creditButton.onClick.AddListener(EnableCredit);
        quitButton.onClick.AddListener(QuitGame);
        newButton.onClick.AddListener(NewGame);
        loadButton.onClick.AddListener(LoadGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnableNewLoad()
    {
        title.SetActive(true);
        menu.SetActive(false);
        settings.SetActive(false);
        credit.SetActive(false);
        newLoad.SetActive(true);
    }

    // 새 게임
    public void NewGame()
    {
        HideAll();
        //SceneTransitionManager.singleton.GoToSceneAsync(1);   // 씬 전환
    }

    // 불러오기
    public void LoadGame()
    {
        HideAll();
        //SceneTransitionManager.singleton.GoToSceneAsync(1);   // 씬 전환
    }

    public void HideAll()
    {
        title.SetActive(false);
        menu.SetActive(false);
        settings.SetActive(false);
        credit.SetActive(false);
        newLoad.SetActive(false);
    }

    public void EnableMainMenu()
    {
        title.SetActive(true);
        menu.SetActive(true);
        settings.SetActive(false);
        credit.SetActive(false);
        newLoad.SetActive(false);
    }
    public void EnableSettings()
    {
        title.SetActive(false);
        menu.SetActive(false);
        settings.SetActive(true);
        credit.SetActive(false);
        newLoad.SetActive(false);
    }
    public void EnableCredit()
    {
        title.SetActive(false);
        menu.SetActive(false);
        settings.SetActive(false);
        credit.SetActive(true);
        newLoad.SetActive(false);
    }
}
