using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{

public class Bullet : MonoBehaviour {

        void OnCollisionEnter()
        {
            Destroy(gameObject);
        }
    
}

}

