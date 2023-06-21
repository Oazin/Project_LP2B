using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static Unity.Mathematics.math;

public class CollectBoy : MonoBehaviour
{
    const float SPEED = 9.0f;
    private float score = 0f;
    private const float SCORE_PER_APPLE = 100f;
    private const float COMBO = 2f;
    private float COMBO_TRACKER = 0f;
    private const float MAX_COMBO = 5f;

    private const float X_GENERATION_START = -8f;
    private const float Y_GENERATION_START = 3.2f;
    private const float SPACE_BETWEEN_LIVES = 1f;
    private const float BORDER = 9.068405f;


    [SerializeField]
    protected GameObject CanvasCombo;
    [SerializeField]
    protected TextMeshProUGUI ref_comboText;


    [SerializeField]
    protected GameObject lives_prefab;
    protected int lives = 3;

    [SerializeField]
    protected TextMeshPro ref_textScore;

    [SerializeField]
    protected AudioClip collectSound;

    [SerializeField] protected Animator ref_animator;

    protected AudioSource sfx_player;

    [SerializeField]
    protected ExitToMainMenu ref_exitToMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        LivesGenerator();
        sfx_player = gameObject.AddComponent<AudioSource>();
        sfx_player.clip = collectSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < BORDER)
        {
            transform.Translate(SPEED * Time.deltaTime, 0, 0);
            ref_animator.SetBool("isIdle", false);
            ref_animator.SetBool("isWalk", true);
            ref_animator.SetBool("isRear", false);
        }
        else if (Input.GetKey(KeyCode.Q) && transform.position.x > -BORDER)
        {
            transform.Translate(-SPEED * Time.deltaTime, 0, 0);
            ref_animator.SetBool("isIdle", false);
            ref_animator.SetBool("isWalk", false);
            ref_animator.SetBool("isRear", true);
        } 
        else
        {
            ref_animator.SetBool("isIdle", true);
            ref_animator.SetBool("isWalk", false);
            ref_animator.SetBool("isRear", false);

        }

        if (Input.GetKey(KeyCode.Escape))
        {
            ref_exitToMainMenu.LoadMenu();
        }
        
       


        if (COMBO_TRACKER > 1) {
            CanvasCombo.SetActive(true);
            ref_comboText.SetText(COMBO_TRACKER + "x combo");
        }

        if (COMBO_TRACKER <= 1) {
            CanvasCombo.SetActive(false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            sfx_player.Play();
            score += SCORE_PER_APPLE*Mathf.Pow(COMBO,COMBO_TRACKER);
            if (COMBO_TRACKER < MAX_COMBO) {
                ++COMBO_TRACKER;
            }
            ref_textScore.SetText("Score : " + score);
        }

        if (collision.gameObject.name == "Bomb_prefab")
        {
            score += SCORE_PER_APPLE;
            COMBO_TRACKER = 0;
            Destroy(collision.gameObject);
            ReductNumberOfLife();
        }

    }

    private void LivesGenerator() {
        for (int i = 0; i < lives ; ++i) {
            GameObject lives_object = Instantiate(lives_prefab);
            lives_object.transform.position = new Vector2(X_GENERATION_START + i*SPACE_BETWEEN_LIVES , Y_GENERATION_START);
            lives_object.name = "lives"  + (i + 1);
        }
    }

    private void ReductNumberOfLife()
    {
        --lives;
        string vie = "lives"+(lives+1); 
        if (lives <= -1) {
            Debug.Log("FIN DU JEU");
        } else {
            Debug.Log(vie);
            Destroy(GameObject.Find(vie));
        }
    }

    public int getLife() 
    {
        return lives;
    }

    public float getScore() 
    {
        ref_textScore.SetText("Score : " + score);
        return score;
    }

}
