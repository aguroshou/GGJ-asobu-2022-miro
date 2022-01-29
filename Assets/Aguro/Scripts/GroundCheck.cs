using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string _groundTag = "Ground";
    private string _softTag = "Soft";
    private bool _isGround = false;
    private bool _isGroundEnter, _isGroundStay, _isGroundExit;

    // 高くジャンプできるブロック
    private bool _isGroundSoft = false;

//接地判定を返すメソッド
//物理判定の更新毎に呼ぶ必要がある
    public bool IsGround()
    {
        if (_isGroundEnter || _isGroundStay)
        {
            _isGround = true;
        }
        else if (_isGroundExit)
        {
            _isGround = false;
        }

        _isGroundEnter = false;
        _isGroundStay = false;
        _isGroundExit = false;
        return _isGround;
    }

    public bool IsGroundSoft()
    {
        if (_isGroundSoft)
        {
            _isGroundSoft = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_groundTag))
        {
            _isGroundEnter = true;
        }

        if (collision.CompareTag(_softTag))
        {
            _isGroundEnter = true;
            _isGroundSoft = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(_groundTag))
        {
            _isGroundStay = true;
        }

        if (collision.CompareTag(_softTag))
        {
            _isGroundStay = true;
            _isGroundSoft = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_groundTag))
        {
            _isGroundExit = true;
        }

        if (collision.CompareTag(_softTag))
        {
            _isGroundExit = true;
            _isGroundSoft = true;
        }
    }
}