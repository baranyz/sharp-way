using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rgb;
    bool _isDown, _isGround, _isFirstTouch;
    float _startTime, _sprColor;
    [SerializeField] float _jumpSpeed;
    [SerializeField] AudioSource _jumpSound, _DownSound, _DeathSound;
    SpriteRenderer _spr;
    Collider2D _col;

    private void Start() {
        
        _rgb = GetComponent<Rigidbody2D>();
        _spr = GetComponent<SpriteRenderer>();
        _col = GetComponent<Collider2D>();
        _startTime = 0;
        _sprColor = 1;
    }
 
    private void Update() {
        
        OnBegin();
        SpeedRaise();
        DownEffect();
        Death();
    }

    private void FixedUpdate() {
        
        Jump();
    }

    private void SpeedRaise(){

        if(GameManager.Instance._score >0){

            _jumpSpeed += Time.deltaTime/10;
            _rgb.gravityScale += Time.deltaTime/10;
        }
    }

    private void Jump(){

        if(GameManager.Instance._score >0){

            if((_isGround || Mathf.Approximately(_rgb.velocity.y, 0)) && Input.touchCount>0){

                _jumpSound.Play();
                _rgb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                _isGround = false;
            }
        }
    }

    private void OnBegin(){

        _startTime += Time.deltaTime;

        if(_startTime < 0.9f){

            transform.Translate(Vector2.down * Time.deltaTime*3);
        }
        
        if(Input.touchCount>0 && _rgb.gravityScale < 1){

            _isFirstTouch = true;
        }

        if(_isFirstTouch) {

            _rgb.gravityScale = 3;
            _jumpSpeed = 9.5f;
            _isFirstTouch = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Rod"){
            _isGround = true;
            _isDown = true;
            _DownSound.Play();
        }

        if(other.gameObject.name == "ScoreCol"){
            GameManager.Instance._score ++;
            Destroy(other.gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Rod"){
            _isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Enemies"){
            _DeathSound.Play();
            GameManager.Instance._isGameover = true;
        }
    }

    private void Death(){

        _spr.color = new Vector4(0,0,0,_sprColor);
        if(GameManager.Instance._isGameover){
            _sprColor -= Time.deltaTime;
            _rgb.bodyType = RigidbodyType2D.Static;
            _col.enabled = false;
            _jumpSound.mute = true;
            transform.Translate(Vector2.up * Time.deltaTime);
            
        }

    }
    
    private void DownEffect(){

        if(_isDown == true){
           
            transform.localScale += new Vector3(Time.deltaTime*2, -Time.deltaTime*2, 1);
            if((transform.localScale.x > 0.8f || transform.localScale.y < 0.3f)){
                _isDown = false;
            }
        }
        else if(_isDown == false){

            if(transform.localScale.x != 0.6f || transform.localScale.y != 0.6f){
                transform.localScale += new Vector3(-Time.deltaTime*2, Time.deltaTime*2, 1);
                if(transform.localScale.x < 0.65f || transform.localScale.y > 0.55f){
                    transform.localScale = new Vector3(0.6f,0.6f,1);
                }
            }
        }
    }

}
