using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{   
    float _posx;
    private void Start() {

        float _scaleX = Random.Range(1.5f,3.1f);
        transform.localScale = new Vector3(_scaleX, 0.1f, 1f);
        
        StartCoroutine(RodDisable());
    }

    private void Update() {

        Move();
    }

    private void Move(){

        transform.Translate(Vector2.left * Time.deltaTime * GameManager.Instance._speed);
    }

    private IEnumerator RodDisable(){

        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);

    }

}
