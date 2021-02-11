using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNPC : MonoBehaviour {
    
    private Rigidbody2D rbd;
    public float velocidade = 5;
    private Animator anim;
    private bool bateu = false;

    void Start() {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "bateu") {
            bateu = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.tag == "bateu") {
            bateu = false;
        }
    }

    void Update() {

        if(bateu) {
            transform.Rotate(new Vector2(0, 180));
            velocidade = -velocidade;
            rbd.velocity = new Vector2(velocidade, rbd.velocity.y);
            bateu = false;
        }else {
            rbd.velocity = new Vector2(velocidade, rbd.velocity.y);
        }

        /*if(transform.position.y < -7) {
            Destroy(this.gameObject);
        }*/
    }
}
