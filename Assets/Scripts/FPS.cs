using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{
    private float current;
    [SerializeField] TextMeshProUGUI fps;
    void Update()
    {
        current = (int)(1f / Time.unscaledDeltaTime);
        fps.text = current.ToString();
    }
}
