using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    [SerializeField] 
    protected SpriteRenderer spriteRenderer;
    protected Color newColor;
    protected float red, green, blue;

    [SerializeField]
    protected GameObject prefab_coin;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        DefineColor();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            CoinsSpawn();
            Destroy(gameObject);
        }
    }

    // DefineColor is called when the brick is created. It aim is define a random color for the brick sprite
    protected void DefineColor()
    {
        red = Random.Range(0, 255);
        green = Random.Range(0, 255);
        blue = Random.Range(0, 255);    
        spriteRenderer.color = new Color(red/255, green / 255, blue / 255, 0.8f) ;
    }

    // CoinsSpawn is called when a brick is collided by the ball. There is a percentage than a coin spawn at this moment 
    protected void CoinsSpawn()
    {
        int change = Random.Range(0, 101);
        if (change >= 80)
        {
            GameObject newCoin = Instantiate(prefab_coin);
            newCoin.transform.position = transform.position;
        }
    }

}
