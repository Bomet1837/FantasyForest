using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float _startingPosition;
    public float _spriteLength;
    public float AmountOfParallax;
    public Camera MainCamera;


    void Start()
    {
        _startingPosition = transform.position.x;
        _spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    private void Update()
    {
        Vector3 Position = MainCamera.transform.position;
        float Temp = Position.x * (1 - AmountOfParallax);
        float Distance = Position.x * AmountOfParallax;

        Vector3 NewPosition = new Vector3(_startingPosition + Distance, transform.position.y, transform.position.z);
        transform.position = NewPosition;
    }
}
