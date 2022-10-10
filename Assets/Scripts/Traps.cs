using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{   
    [SerializeField] GameObject _trapsTail;
    private void Update() {

        Move();
    }

    private void Move(){

        transform.Translate(Vector2.left * Time.deltaTime * GameManager.Instance._speed);
    }
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.name == "SpawnTraps"){

            Spawn();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {

        if(other.gameObject.name == "SpawnTraps"){

            Destroy(this.gameObject);
        }
    }

    private void Spawn(){

        Instantiate(this.gameObject, new Vector2(_trapsTail.transform.position.x, -1.9f), Quaternion.identity);
    }
}
