using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    float _sprColor;
    SpriteRenderer _spr;

    private void Start() {

        _spr = GetComponent<SpriteRenderer>();
        _sprColor = 1;
    }

    private void Update() {

        RiseEffect();
    }

    private void RiseEffect(){

        _spr.color = new Vector4(_spr.color.r, _spr.color.g, _spr.color.b, _sprColor);

        if(GameManager.Instance._isGameover){

            _sprColor -= Time.deltaTime*2;
        }
        else if(GameManager.Instance._isGameover == false){
            
            _sprColor = 1;
        }
    }
}
