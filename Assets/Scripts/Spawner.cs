using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _rod, _gem;
    List<Vector2> _posRod, _posGem;
    int _vector2Index;
    float _randomCount;
    bool _isExit;

    private void Start() {
        
        _posRod = new List<Vector2>(){new Vector2(9,3), new Vector2(9,2), new Vector2(9,1), new Vector2(9,0), new Vector2(9,-1), new Vector2(9,-2), new Vector2(9,-3)};
        _posGem = new List<Vector2>(){new Vector2(9,4), new Vector2(9,3), new Vector2(9,2), new Vector2(9,1), new Vector2(9,0), new Vector2(9,-1), new Vector2(9,-2)};
       
        _vector2Index = Random.Range(0,7);
       
        _isExit = true;
    }

    private void Update() {

        SpawnPos();
    }

    private void SpawnPos(){

        _randomCount = Random.Range(1,100);

        if(_vector2Index > 0 && _vector2Index < 6 && _isExit == true){

            if(_randomCount <= 50) _vector2Index --;
            else if(_randomCount >50) _vector2Index ++;
            SpawnRod();
            if(_randomCount > 90) SpawnGem();
            _isExit = false;
        }
        if(_vector2Index == 0 && _isExit == true){
            _vector2Index = 1;
            SpawnRod();
            if(_randomCount > 90) SpawnGem();
            _isExit = false;
        }
        if(_vector2Index == 6 && _isExit == true){
            _vector2Index =5;
            SpawnRod();
            if(_randomCount > 90) SpawnGem();
            _isExit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Rod"){

            _isExit = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {

        if(other.gameObject.tag == "Rod"){

            _isExit = true;
        }
    }
    private void SpawnRod(){

        Instantiate(_rod, _posRod[_vector2Index], Quaternion.identity);
    }

    private void SpawnGem(){

        Instantiate(_gem, _posGem[_vector2Index], Quaternion.identity);
    }
  
}
