using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GPC;

public class AutoTransformMove : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveVector = Vector3.left;
    private Transform _TR;
    // Start is called before the first frame update
    void Start()
    {
        _TR = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = RunMan_GameManager.instance.runSpeed;
        _TR.Translate((moveVector * moveSpeed) * Time.deltaTime);
    }

    public void SetMoveSpeed(float aSpeed)
    {
        moveSpeed = aSpeed;
    }
}
