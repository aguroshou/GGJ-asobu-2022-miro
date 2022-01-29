using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string _groundTag = "Ground";
    private bool _isGround = false;
    private bool _isGroundEnter, _isGroundStay, _isGroundExit;

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
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_groundTag))
        {
            _isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(_groundTag))
        {
            _isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_groundTag))
        {
            _isGroundExit = true;
        }
    }
}