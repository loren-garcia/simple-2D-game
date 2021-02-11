using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour {

public float speed = 0.15f;
private Transform target;

private bool maxMin = true;
private float xMin = 0;
private float xMax = 118.87f;
private float yMin = -3;
private float yMax = 8;

    void Start() {
        target = GameObject.FindGameObjectWithTag("head").transform;
    }
    
    void Update() {
        
        /*Vector3 posicao = new Vector3(pc.transform.position.x, pc.transform.position.y + offset_y, -10);
        this.transform.position = posicao;*/

        if(target) {
            transform.position = Vector3.Lerp(transform.position, target.position, speed) + new Vector3(0, 0, target.position.z);

            if(maxMin) {
                transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);
            }
        }
    }
}
