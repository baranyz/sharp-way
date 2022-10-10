using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    Animator _ani;
    AudioSource _audio;
    SpriteRenderer _spr;
    Collider2D _col;

    private void Start() {
        
        _ani = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _spr = GetComponent<SpriteRenderer>();
        _col = GetComponent<Collider2D>();
        StartCoroutine(LastDestroy());
    }

    private void Update() {

        MovementVertical();
        MovementHorizontal();
        CatchDestroy();
    }

    private void CatchDestroy(){

        if(_ani.GetBool("isGem") && _ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){

            _spr.enabled = false;
            Destroy(this.gameObject, _audio.clip.length);
        }
    }

    private void MovementVertical(){

        float _t = Mathf.PingPong(Time.time*3, 1);
        transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y - Time.deltaTime/3), new Vector2(transform.position.x, transform.position.y + Time.deltaTime/3), _t);
    }

    private void MovementHorizontal(){

        transform.Translate(Vector2.left * Time.deltaTime * GameManager.Instance._speed);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        GameManager.Instance._gemScore ++;
        _ani.SetBool("isGem", true);
        _audio.Play();
        _col.enabled = false;
    }

    private IEnumerator LastDestroy(){

        yield return new WaitForSeconds(6);
        if(this.gameObject != null) Destroy(this.gameObject);

    }
}
