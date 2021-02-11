using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBoss : MonoBehaviour {
    
    public float velocidade = 6;
    public float distancia = 0.5f;
    private bool direita = true;
    public Transform groundCheck;    

    void Update() {

        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, distancia);
        
        if(groundInfo.collider == false) {
            if(direita) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                direita = false;
            }else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                direita = true;
            }
        }
    }
}
