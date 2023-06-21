using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{

    // Bird animation's variales
    [SerializeField]
    protected Sprite[] ref_bird;
    protected int birdIndex = 0;
    [SerializeField]
    protected Sprite ref_deadBird;


    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating(nameof(AnimateBird), 0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to animate the flying of the bird
    protected void AnimateBird()
    {
        birdIndex++;
        if (birdIndex >= ref_bird.Length)
        {
            birdIndex = 0;
        }

        GetComponent<SpriteRenderer>().sprite = ref_bird[birdIndex];
    }


    // Method to change the sprite of the bird for the dead bird sprite
    public void AnimateDeadBird()
    {
        GetComponent<SpriteRenderer>().sprite = ref_deadBird;
    }
}
