using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Main Attributes")]
    [SerializeField] private HUD hud;
    [SerializeField] private TimeBarController timeBar;
    [Header("Gaming Parts")]
    [SerializeField] private List<GameObject> boxes = new List<GameObject>();
    [SerializeField] private PlayerController player;
    [SerializeField] private Vector3 playerPos;

    private GameSate gameSate = GameSate.Stop;
    private float maxTime = 15;

    private void Awake()
    {
        hud.OnStart += StartGame;
        hud.restartBt.onClick.AddListener(ReloadScene);
        player.OnFall += GameOver;
    }
    void Start()
    {
        SetPlayer();
    }

    void Update()
    {
        if (gameSate == GameSate.Play)
            CheckBoxes();
    }
    void FixedUpdate()
    {
        if (gameSate == GameSate.Play)
        {
            if (maxTime >= 0)
            {
                maxTime -= Time.fixedDeltaTime;
                timeBar.SetTime(maxTime);
            }
            else
            {
                GameOver("Невдахо!");
            }
        }
    }
    private void SetPlayer()
    {
        player.ragDollControl.MakeKinematic();
        player.gameObject.transform.position = playerPos;
        player.gameObject.transform.rotation = Quaternion.identity;
        player.GameSate = GameSate.Play;
    }
    private void StartGame()
    {
        gameSate = GameSate.Play;
    }
    private void GameOver(string infoTxt)
    {
        gameSate = GameSate.Stop;
        player.GameSate = GameSate.Stop;
        hud.GameOverPanel(infoTxt);
    }

    private void CheckBoxes()
    {
        var fallenBoxes = 0;
        foreach (var box in boxes)
        {
            if (box.transform.position.y < 0)
                fallenBoxes++;
        }

        if (fallenBoxes == boxes.Count)
            GameOver("Красавчик!");
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene("Test Scene");
    }
    private void OnDisable()
    {
        hud.OnStart -= StartGame;
        player.OnFall -= GameOver;
    }
}
public enum GameSate
{
    Play,
    Stop
}