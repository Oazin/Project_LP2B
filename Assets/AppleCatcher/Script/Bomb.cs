using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
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

}
