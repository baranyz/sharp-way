using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    TextMeshProUGUI _text;
    int _scoreMain;
    bool _isScoreChange;

    private void Start() {

        _text = GetComponent<TextMeshProUGUI>();
        _scoreMain = 0;
    }

    private void Update() {

        ScoreEffect();
        SetScore();
        Save();
    }

    private void ScoreEffect(){

        if(_isScoreChange){

            if(_text.fontSizeMax < 70){
                _text.fontSizeMax += Time.deltaTime*200;
                if(_text.fontSizeMax > 69) _isScoreChange = false;
            }
            
        }
        else if(_isScoreChange == false){

            if(_text.fontSizeMax > 50){
                _text.fontSizeMax -= Time.deltaTime*200;
            }
        }
    }

    private void SetScore(){

        if(_scoreMain < GameManager.Instance._score){

            _scoreMain = GameManager.Instance._score;
            _text.SetText(_scoreMain.ToString());
            _isScoreChange = true;
        }
        else _text.SetText(_scoreMain.ToString());
    }

    private void Save(){

        PlayerPrefs.SetInt("_scoreMain", _scoreMain);
    }
}


