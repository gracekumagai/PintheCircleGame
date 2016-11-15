using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private Button shootBtn;

    [SerializeField]
    private GameObject needle;

    private GameObject[] gameNeedles;

    [SerializeField]
    private int howManyNeedles;

    private float needleDistance = .5f;
    private int needleIndex;

    public static bool isOver;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Text gameOverText;

    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private Text winText;

    public static bool isCollide;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        GetButton();
    }

    void Start()
    {
        CreateNeedles();
    }

    void Update()
    {
        if (isOver == true)
        {
            GameOver();
        }
    }

    void GetButton()
    {

        shootBtn = GameObject.Find("Shoot Button").GetComponent<Button>();
        shootBtn.onClick.AddListener(() => ShootTheNeedle());
    }

    public void ShootTheNeedle()
    {
        gameNeedles[needleIndex].GetComponent<NeedleMovScript>().FireTheNeedle();
        needleIndex++;

        if ((needleIndex == gameNeedles.Length) && (isCollide == false))
        {
            winPanel.SetActive(true);
            shootBtn.onClick.RemoveAllListeners();
        }
    }

    void CreateNeedles()
    {
        gameNeedles = new GameObject[howManyNeedles];
        Vector3 temp = transform.position;

        for (int i = 0; i < gameNeedles.Length; i++)
        {
            gameNeedles[i] = Instantiate(needle, temp, Quaternion.identity) as GameObject;
            temp.y -= needleDistance;
        }
    }

    public void InstantiateNeedle()
    {
        Instantiate(needle, transform.position, Quaternion.identity);
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "Game Over!";
    }
}
