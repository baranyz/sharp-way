using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour
{
    TextMeshProUGUI _textMesh;
    float _colorA;
    bool _touched, _isColor;

    private void Start() {

        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {

        TextEffect();
    }

    private void TextEffect(){

        _textMesh.color = new Vector4(0,0,0, _colorA);

        if(_colorA>0.99){

            _isColor = true;
        }
        else if(_colorA < 0.1f){

            _isColor = false;
        }

        if(_isColor) _colorA -= Time.deltaTime;
        else _colorA += Time.deltaTime;
    }
}
