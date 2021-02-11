using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour {
    
    private Rigidbody2D rbd;
    public float velocidade = 5;
    public float pulo = 600;
    private bool chao = true;
    private bool direita = true;
    private Animator anim;
    public GameObject gameOverText, restartButton, gameWinText, exitButton;

    void Start() {

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        gameWinText.SetActive(false);
        exitButton.SetActive(false);

        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        chao = true;

        scriptNPC npc = collision.collider.GetComponent<scriptNPC>();

        /*if(npc != null) {
            
            foreach (ContactPoint2D point in collision.contacts) {
                
                //Debug.Log(point.normal);
                //Debug.DrawLine(point.point, point.point + point.normal, Color.red, 10);
                if(point.normal.y >= -3) {
                    Destroy(collision.gameObject);
                    Vector2 vel = rbd.velocity;
                    vel.y = pulo * velocidade;
                    rbd.velocity = vel;
                }else {
                    gameOverText.SetActive(true);
                    restartButton.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }*/
        
        if(collision.gameObject.tag.Equals("hitNPC")) {
            
            if (collision.collider.GetType() == typeof(CircleCollider2D)) {
                
                Death();
            }else if (collision.collider.GetType() == typeof(BoxCollider2D)) {
                
                /*GetComponent<Collider2D>().enabled = false;
                npc.GetComponent<SpriteRenderer>().flipY = true;
                npc.GetComponent<Collider2D>().enabled = false;
                Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
                npc.transform.position += movement * Time.deltaTime;
                rbd.AddForce(new Vector2(0, pulo - 300));
                rbd.transform.position = new Vector2(transform.position.x, -3.61f);
                npc.gameObject.SetActive(false);*/

                Destroy(collision.gameObject);
                chao = false;
            }
        }

        if(collision.gameObject.tag.Equals("cactus") || collision.gameObject.tag.Equals("spears")) {

            Death();
        }

        if(collision.gameObject.tag.Equals("end")) {

            Win();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        chao = false;
    }

    void Update() {

        float x = Input.GetAxis("Horizontal");
        float velY;

        if(x == 0) {
            anim.SetBool("chao", true);
        }else {
            anim.SetBool("chao", false);
        }

        if(direita && x < 0 || !direita && x > 0) {
            direita = !direita;
            transform.Rotate(new Vector2(0, 180));
        }

        if(chao) {
            velY = 0;
        }else {
            velY = rbd.velocity.y;
        }
        rbd.velocity = new Vector2(x * velocidade, velY);

        if(Input.GetKeyDown(KeyCode.Space) && chao) {
            rbd.AddForce(new Vector2(0, pulo));
            chao = false;
        }

        if(rbd.position.y < -5) {
            Death();
        }
    }

    void Death() {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
        gameObject.SetActive(false);
    }

    void Win() {
        gameWinText.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
