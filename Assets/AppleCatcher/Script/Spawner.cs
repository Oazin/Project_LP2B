using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static Unity.Mathematics.math;

public class Spawner : MonoBehaviour
{
    private const float COORD_SCREEN_BORDER = 9.5f;
    private const float COORD_SCREEN_BOTTOM_SPAWN_RANGE = 6f;
    private const float COORD_SCREEN_TOPPON_SPAWN_RANGE = 11f;
    private const float RESPAWN_TIME = 1f;
    private bool gameStarted = false;
    private const int MULTIPLE_APPLE = 4;

    protected float timeBeforeStart = 3.4f;

    [SerializeField]
    public GameObject ref_panier;
    private int Score;
    private CollectBoy CollectBoy;

    [SerializeField]
    protected GameObject prefab_apple;

    [SerializeField]
    protected GameObject prefab_bomb;

    [SerializeField]
    protected TextMeshProUGUI ref_startText;

    [SerializeField]
    protected TextMeshPro ref_timeLeftText;

    [SerializeField]
    protected TextMeshProUGUI ref_textFinalScore;

    [SerializeField]
    public GameObject CanvasStart;

    [SerializeField]
    public GameObject CanvasGameOver;

    [SerializeField]
    public GameObject ref_timeManager;
    public TimeManager script_timeManager;


    [HideInInspector]
    public float timer = 0.000001f;

    [SerializeField]
    private CircleCollider2D apple_prefab_Collider;
    [SerializeField]
    private CircleCollider2D bomb_prefab_Collider;

    // Start is called before the first frame update
    void Start()
    {
        script_timeManager = ref_timeManager.GetComponent<TimeManager>();

        CanvasGameOver.SetActive(false);
        CanvasStart.SetActive(true);
        ref_startText.SetText("Start in " +timeBeforeStart+ " s");

        CollectBoy = ref_panier.GetComponent<CollectBoy>();

    }

    // Update is called once per frame
    void Update()
    {
        int lives = CollectBoy.getLife();

        if (!gameStarted) {
            timeBeforeStart -= Time.deltaTime;
            ref_startText.SetText("Start in " +Mathf.Round(timeBeforeStart)+ " s");
        }

        
        if (timeBeforeStart <= 0) { // If the starting time is over then
            CanvasStart.SetActive(false);
            gameStarted = true; // The game start
        }


        if (gameStarted) { // If the game has start we start to make spawn apple
            timer -= Time.deltaTime; 
        }

        if (timer <= 0 && lives > 0)
        {
            SpawnApple(); // Method that make an apple spawn

            timer = RESPAWN_TIME;
        }

        if (lives <= 0  || script_timeManager.getTimeLeft() <= 0) {
            ref_timeLeftText.SetText("Time left : ---");
            ref_textFinalScore.SetText("Final Score : "+CollectBoy.getScore());
            Destroy(GameObject.Find("Apple_prefab"));
            Destroy(GameObject.Find("Bomb_prefab"));
            CanvasGameOver.SetActive(true);
        }

    }

    protected void SpawnApple()
    {
        for (int i = 0; i < Random.Range(3,7); ++i) {
            if (Random.Range(1,9) <= 5) {
                GameObject newApple = Instantiate(prefab_apple);
                newApple.name = "Apple_prefab";
                float posX = Random.Range(-COORD_SCREEN_BORDER, COORD_SCREEN_BORDER);
                float posY = Random.Range(COORD_SCREEN_BOTTOM_SPAWN_RANGE, COORD_SCREEN_TOPPON_SPAWN_RANGE);
                newApple.transform.position = new Vector3(posX, posY, 0);
            } else {
                GameObject newBomb = Instantiate(prefab_bomb);
                newBomb.name = "Bomb_prefab";
                float posX = Random.Range(-COORD_SCREEN_BORDER, COORD_SCREEN_BORDER);
                float posY = Random.Range(COORD_SCREEN_BOTTOM_SPAWN_RANGE, COORD_SCREEN_TOPPON_SPAWN_RANGE);
                newBomb.transform.position = new Vector3(posX, posY, 0);
            }
            
        }

    }
}
