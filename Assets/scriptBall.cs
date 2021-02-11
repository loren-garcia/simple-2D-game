using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBall : MonoBehaviour {
    
    private Rigidbody2D rbd;
    public float leftRange;
    public float rightRange;
    public float velocityThreshold;

    void Start() {

        rbd = GetComponent<Rigidbody2D>();
        rbd.angularVelocity = velocityThreshold;
    }

    void Update() {
        
        if(transform.rotation.z > 0
        && transform.rotation.z < rightRange 
        && (rbd.angularVelocity > 0)
        && rbd.angularVelocity < velocityThreshold) {
            rbd.angularVelocity = velocityThreshold;
        }else if(transform.rotation.z < 0 
        && transform.rotation.z > leftRange 
        && (rbd.angularVelocity < 0) 
        && rbd.angularVelocity > velocityThreshold * (-1)) {
            rbd.angularVelocity = velocityThreshold * (-1);
        }
    }
}
