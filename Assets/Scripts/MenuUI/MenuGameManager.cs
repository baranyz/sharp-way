using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuGameManager : MonoBehaviour
{
    public static MenuGameManager Instance {get;set;}

    public bool _isPlay;
    int _pref2, _pref3, _pref4, _pref5, _pref6;
    List<int> _prefs;
    int _menuScore, _menuGemScore, _ballSelectedColor;
    [SerializeField] GameObject _menuScoreText, _soundOn, _soundOff, _StorePanel;
    [SerializeField] TextMeshProUGUI _InsufficientBalance;
    [SerializeField] Button _1,_2,_3,_4,_5,_6;
    List<Button> _buttons;
    TextMeshProUGUI _menuScoreTextMesh;
    AudioSource _audio;
    int _isSoundOn;
    public int _whichBall;
    float _balanceTextTime;


    private void Awake() {

        if(Instance != null && Instance != this){

            Destroy(this.gameObject);
        }
        else{
            
            Instance = this;
        }
    }

    private void Start() {
        
        _buttons = new(){_1,_2,_3,_4,_5,_6};
        _prefs = new() {_pref2, _pref3, _pref4, _pref5, _pref6};

        _menuScoreTextMesh = _menuScoreText.GetComponent<TextMeshProUGUI>();
        _audio = GetComponent<AudioSource>();

        _whichBall = PlayerPrefs.GetInt("_whichBall");
        _menuGemScore = PlayerPrefs.GetInt("_gemScore");

        _StorePanel.SetActive(false);

        AudioSave();
        StorePanelSaves();
    }
   
    private void Update() {

        MenuScore();
        Saves();
        GemBalance();
    }

    private void MenuScore(){

        _menuScore = PlayerPrefs.GetInt("_menuScore");

        if(_menuScore < PlayerPrefs.GetInt("_score")){
            _menuScore = PlayerPrefs.GetInt("_score");
        }
        _menuScoreTextMesh.SetText("BEST SCORE: " + _menuScore);

        PlayerPrefs.SetInt("_menuScore", _menuScore);
    }

    private void GemBalance(){

        if(_InsufficientBalance == true){
            
            _balanceTextTime += Time.deltaTime;

            if(_balanceTextTime > 2){

                _InsufficientBalance.enabled = false;
                _balanceTextTime = 0;
            }
        }
    }

    private void AudioSave(){

        _isSoundOn = PlayerPrefs.GetInt("_isSoundOn");
        if(_isSoundOn == 1){
            _soundOn.SetActive(false);
            _soundOff.SetActive(true);
            AudioListener.pause = true;
        }
        else if(_isSoundOn == 2){
            _soundOn.SetActive(true);
            _soundOff.SetActive(false);
            AudioListener.pause = false;
        }
        else {
            _soundOn.SetActive(true);
            _soundOff.SetActive(false);
            AudioListener.pause = false;
        }
        
    }

    private void StorePanelSaves(){

        _ballSelectedColor = PlayerPrefs.GetInt("_ballSelectedColor");
        _buttons[_ballSelectedColor].image.color = Color.green;
        
        _pref2 = PlayerPrefs.GetInt("_pref2");
        _pref3 = PlayerPrefs.GetInt("_pref3");
        _pref4 = PlayerPrefs.GetInt("_pref4");
        _pref5 = PlayerPrefs.GetInt("_pref5");
        _pref6 = PlayerPrefs.GetInt("_pref6");


        if(_pref2 == 1){

            _2.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
        }
        if(_pref3 == 1){
     
            _3.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
        }
        if(_pref4 == 1){
           
            _4.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
        }
        if(_pref5 == 1){
            
            _5.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
        }
        if(_pref6 == 1){
            
            _6.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
        }

        _InsufficientBalance.SetText("Gem balance is not enough to buy!");
    }

    private void Saves(){

        PlayerPrefs.SetInt("_isSoundOn", _isSoundOn);
        PlayerPrefs.SetInt("_whichBall", _whichBall);
        PlayerPrefs.SetInt("_gemScore", _menuGemScore);

        PlayerPrefs.SetInt("_pref2", _pref2);
        PlayerPrefs.SetInt("_pref3", _pref3);
        PlayerPrefs.SetInt("_pref4", _pref4);
        PlayerPrefs.SetInt("_pref5", _pref5);
        PlayerPrefs.SetInt("_pref6", _pref6);
    }

    private void ButtonColors(int ballIndx){

        for(int i = 0; i < _buttons.Count; i ++){
            
            if(ballIndx != i){
                _buttons[i].image.color = Color.red;
            }
            else if(ballIndx == i ) {
                _buttons[ballIndx].image.color = Color.green;
            }
       
            
        }
        PlayerPrefs.SetInt("_ballSelectedColor", ballIndx);
    }

    public void OnBall0(){

        ButtonColors(0);

        _whichBall = 0;
        _audio.Play();
    }

    public void OnBall1(){

        if(_menuGemScore >= 300 && _pref2 == 0){
            _menuGemScore -= 300;
            _2.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
            _pref2 = 1;
        }

        if(_pref2 == 1) {
            ButtonColors(1);
            _audio.Play();
            _whichBall = 1;
        }
        else{
            _InsufficientBalance.enabled = true;
        }

    }

    public void OnBall2(){

        if(_menuGemScore >= 1000 && _pref3 == 0){
            _menuGemScore -= 1000;
            _3.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
            _pref3 = 1;
        }

        if(_pref3 == 1) {
            ButtonColors(2);
            _whichBall = 2;
            _audio.Play();
        }
        else{
            _InsufficientBalance.enabled = true;
        }

    }

    public void OnBall3(){

        if(_menuGemScore >= 3000 && _pref4 == 0){
            _menuGemScore -= 3000;
            _4.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
            _pref4 = 1;
        }

        if(_pref4 == 1) {
            ButtonColors(3);
            _whichBall = 3;
            _audio.Play();
        }
        else{
            _InsufficientBalance.enabled = true;
        }
        
    }

    public void OnBall4(){

        if(_menuGemScore >= 5000 && _pref5 == 0){
            _menuGemScore -= 5000;
            _5.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
            _pref5 = 1;
        }

        if(_pref5 == 1) {
            ButtonColors(4);
            _whichBall = 4;
            _audio.Play();
        }
        else{
            _InsufficientBalance.enabled = true;
        }
        
    }

    public void OnBall5(){

        if(_menuGemScore >= 10000 && _pref6 == 0){
            _menuGemScore -= 10000;
            _6.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
            _pref6 = 1;
        }

        if(_pref6 == 1) {
            ButtonColors(5);
            _whichBall = 5;
            _audio.Play();
        }
        else{
            _InsufficientBalance.enabled = true;
        }

    }

    public void OnStoreButton(){

        _StorePanel.SetActive(true);
        _audio.Play();
    }

    public void OnStoreExitButton(){

        _StorePanel.SetActive(false);
        _audio.Play();
    }

    public void OnPlayButton(){

        _isPlay = true;
    }

    public void OnSoundOnButton(){

        _soundOn.SetActive(false);
        _soundOff.SetActive(true);
        _isSoundOn = 1;
        _audio.Play();
        AudioListener.pause = true;
    }
    
    public void OnSoundOffButton(){

        _soundOn.SetActive(true);
        _soundOff.SetActive(false);
        _isSoundOn = 2;
        _audio.Play();
        AudioListener.pause = false;
    }
}
