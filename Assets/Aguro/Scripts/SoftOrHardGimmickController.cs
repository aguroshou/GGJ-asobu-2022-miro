using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftOrHardGimmickController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private GroundSoftCheck groundSoftCheck;
    [SerializeField] private float softOrHardGimmickHighJumpPower;

    private bool _isGroundSoft;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        //イベントの購読(subscribe)
        SoftOrHardSwitchController.SoftOrHardSwitchChanged += SwitchChanged;

        if (this.gameObject.CompareTag("Soft"))
        {
            SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.green;
        }
        else if (this.gameObject.CompareTag("Ground"))
        {
            SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.magenta;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(0.0f, _rigidbody2D.velocity.y);

        //床が高くジャンプできるブロックであるかを判別します。
        _isGroundSoft = groundSoftCheck.IsGroundSoft();
        if (_isGroundSoft)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, softOrHardGimmickHighJumpPower);
            groundSoftCheck.PlayerJumped();
        }
    }

    private void SwitchChanged()
    {
        Debug.Log("SwitchChangedのイベントを受け取りました。");
        if (this.gameObject.CompareTag("Soft"))
        {
            this.gameObject.tag = "Ground";
            SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.magenta;
        }
        else if (this.gameObject.CompareTag("Ground"))
        {
            this.gameObject.tag = "Soft";
            SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.green;
        }
    }
}