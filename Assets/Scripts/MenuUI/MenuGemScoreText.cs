using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuGemScoreText : MonoBehaviour
{
    TextMeshProUGUI _textMesh;

    private void Start() {

        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {

        _textMesh.SetText("X" + PlayerPrefs.GetInt("_gemScore"));
    }
}
