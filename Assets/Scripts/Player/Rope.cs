using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    Vector3 _startPos;
    bool _touch;

    private void Start() {

        _startPos = transform.position;
    }
    private void Update() {

        RopeUp();
    }

    private void RopeUp(){

        if(Input.touchCount>0){

            _touch = true;
        }
        if(_touch == true){

            transform.Translate(Vector2.up * Time.deltaTime *20);

            if(_startPos == transform.position) Destroy(this.gameObject);
        }
    }
}
