using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEffect : MonoBehaviour
{
    bool _isEyeOpen;
    float _eyetime;

    private void Start() {
        
        _eyetime = 0;
    }
    private void Update() {

        CloseEye();
    }

    private void CloseEye(){

        _eyetime += Time.deltaTime;

        if(_eyetime > 10){

            if(transform.localScale.y > 0.099){

                _isEyeOpen = true;
            }
            else if(transform.localScale.y < 0.01){

                _isEyeOpen = false;
            }


            if(_isEyeOpen){

                transform.localScale -= new Vector3(0, Time.deltaTime, 0);
            }
            else if(_isEyeOpen == false){

                transform.localScale += new Vector3(0, Time.deltaTime, 0);
                if(transform.localScale.y > 0.097f) {
                    _eyetime = 0;
                }
            }
        }
    }
}
