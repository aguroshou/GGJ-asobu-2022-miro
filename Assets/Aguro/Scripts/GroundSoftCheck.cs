using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSoftCheck : MonoBehaviour
{
    // GroundCheckのプログラムをSoft(グミ判定)に変更したものです。
    
    private string _softTag = "Soft";
    // 高くジャンプできるブロック
    private bool _isGroundSoft = false;
    private bool _isGroundSoftEnter, _isGroundSoftStay, _isGroundSoftExit;

//接地判定を返すメソッド
//物理判定の更新毎に呼ぶ必要がある
    public bool IsGroundSoft()
    {
        if (_isGroundSoftEnter || _isGroundSoftStay)
        {
            _isGroundSoft = true;
        }
        else if (_isGroundSoftExit)
        {
            _isGroundSoft = false;
        }

        _isGroundSoftEnter = false;
        _isGroundSoftStay = false;
        _isGroundSoftExit = false;
        return _isGroundSoft;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_softTag))
        {
            _isGroundSoftEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(_softTag))
        {
            _isGroundSoftStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_softTag))
        {
            _isGroundSoftExit = true;
        }
    }
}