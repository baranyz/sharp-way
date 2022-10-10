using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; set;}
    [SerializeField] GameObject _gameoverText, _scoreText;
    RectTransform _gameoverTransform;
    public float _speed;
    public int _score, _gemScore;
    public bool _isGameover;

    private void Awake() {

        if(Instance != null && Instance != this){
            
            Destroy(this.gameObject);
        }
        else{

            Instance = this;
        }
    }

    private void Start() {
        
        _gameoverTransform = _gameoverText.GetComponent<RectTransform>();
        _gameoverText.SetActive(false);
        _score = 0;
        _gemScore = PlayerPrefs.GetInt("_gemScore");
    }

    private void Update() {
        
        Speed();
        Saves();
        
        if(_isGameover) Gameover();
    }

    private void Gameover(){
        
        _gameoverText.SetActive(true);
        _scoreText.SetActive(false);

        if(_gameoverTransform.localScale.x<1){

            _gameoverTransform.localScale += new Vector3(Time.deltaTime/1.2f, Time.deltaTime/1.2f, 0);

            if(_gameoverTransform.localScale.x>1){

                _isAdShow = true;
                _gameoverText.SetActive(false);
                SceneManager.LoadScene(0);
                _isGameover = false;
            }
        }
    }

    private void Saves(){

        PlayerPrefs.SetInt("_gemScore", _gemScore);
        PlayerPrefs.SetInt("_score", _score);
    }

    private void Speed(){
        
        if(_score == 0) _speed = 3f;
        else if(_score >0){

            _speed += Time.deltaTime/30;
        }
    }
  
}
