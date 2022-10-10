using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBallEffect : MonoBehaviour
{   
    [SerializeField] Sprite _ball1 ,_ball2, _ball3, _ball4, _ball5, _ball6;
    List<Sprite> _balls;
    SpriteRenderer _spr;
    float _time;

    private void Start() {
        
        _spr = GetComponent<SpriteRenderer>();

        _balls = new(){_ball1 ,_ball2, _ball3, _ball4, _ball5, _ball6};
    }

    private void Update() {
        
        BallUp();
    }

    private void BallUp(){

        if(MenuGameManager.Instance._isPlay){

            transform.Translate(Vector2.up * Time.deltaTime*5);
            _time += Time.deltaTime;
            
            if(_time>0.6f) SceneManager.LoadScene(1);
        }

        _spr.sprite = _balls[MenuGameManager.Instance._whichBall];
    }
}
