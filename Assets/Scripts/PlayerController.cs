using UnityEditor.Callbacks;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _jumpRequested;

    [SerializeField] private GameObject gameOverText;

    // Make sure we're on the ground
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundLayer;
    private bool _onGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       _rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
       _rb.linearVelocityX = 3f;

       if(_jumpRequested)
        {
            _rb.linearVelocityY = 8f;
            _jumpRequested = false;
        }
    }

    void Update()
    {
        if (transform.position.y < -5f)
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0f;
        }
        
        _onGround = Physics2D.OverlapCircle(_groundChecker.position, 
                                            _groundCheckRadius, 
                                            _groundLayer);
        if (_onGround && 
        (Input.GetMouseButton(0) || 
        Input.GetKeyDown(KeyCode.Space)))
        {
            _jumpRequested = true;
        }
    }
}
