using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftOrHardSwitchController : MonoBehaviour
{
    [SerializeField] private GameObject hitCheck;

    // 箱の下の方にある当たり判定です。
    private BoxCollider2D _hitCheckBoxCollider2D;

    private CapsuleCollider2D _playerCapsuleCollider2D;
    
    public delegate void SoftOrHardSwitchEventHandler();
    public static event SoftOrHardSwitchEventHandler SoftOrHardSwitchChanged;

    protected virtual void Execute()
    {
        //イベント発行
        if (SoftOrHardSwitchChanged != null)
            SoftOrHardSwitchChanged();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _hitCheckBoxCollider2D = hitCheck.GetComponent<BoxCollider2D>();
        _playerCapsuleCollider2D = GameObject.Find("Player").GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_hitCheckBoxCollider2D.IsTouching(_playerCapsuleCollider2D)
        && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("イベント発行しました。");
            //イベント発行
            if (SoftOrHardSwitchChanged != null)
                SoftOrHardSwitchChanged();
        }
    }
}
