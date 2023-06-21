using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeColor : MonoBehaviour
{

    // Pipe colors's variales
    [SerializeField]
    protected Sprite[] ref_PipeColors;
    protected int colorIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectPipeColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to select the pipe's color    
    protected void SelectPipeColor()
    { 
        colorIndex = Random.Range(0, ref_PipeColors.Length);
        GetComponent<SpriteRenderer>().sprite = ref_PipeColors[colorIndex];
    }
}
