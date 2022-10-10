using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCharacters : MonoBehaviour
{
    [SerializeField] GameObject _ball1 ,_ball2, _ball3, _ball4, _ball5, _ball6;
    List<GameObject> _balls;

    private void Start() {
        
        _balls = new() {_ball1 ,_ball2, _ball3, _ball4, _ball5, _ball6};

        Invoke("SpawnBall", 0);
    }


    private void SpawnBall(){

        Instantiate(_balls[MenuGameManager.Instance._whichBall], transform.position, Quaternion.identity);
    }
}
