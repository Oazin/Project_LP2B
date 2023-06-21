using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomme : MonoBehaviour
{
    const float BAS_ECRAN = -7.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.y < BAS_ECRAN)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.name == "CollectBoy" )
        {
            Destroy(gameObject);
        }
  
    }


}
