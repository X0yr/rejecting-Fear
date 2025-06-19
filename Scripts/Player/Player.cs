using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    private Rigidbody2D rb;
    private KnockBack _knockBack;



    private float _minMovingSpeed = 0.1f;
    private bool _isRunning = false;


    [SerializeField] private float _movingSpeed = 5f;
    [SerializeField] private int _maxHealth = 10;

    private int _currentHealth;

    private Vector2 inputVector;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        _knockBack = GetComponent<KnockBack>();
       
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        GameInput.Instance.onPlayerAttack += Player_onPlayerAttack;
    }

    private void Player_onPlayerAttack(object sender, System.EventArgs e)
    {
        ActivWeapon.Instance.GetActivWeapon().Attack();
    }

    private void Update()
    {
        inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;
    }


    private void FixedUpdate()
    {
        if (_knockBack.IsGettingKnockedBack)
            return;

        HandelMovment();
    }

    public void TakeDamage(Transform damageSourse, int damage)
    {
        _currentHealth = Mathf.Max(0, _currentHealth -= damage);
        Debug.Log(_currentHealth);
        _knockBack.GetKnockdBack(damageSourse);
    }

    public bool IsRunning()
    {
        return _isRunning;
    }

    public Vector3 GetPlayerPosition()
    {
        Vector3 playrsScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playrsScreenPosition;
    }

    private void HandelMovment()
    {
        rb.MovePosition(rb.position + inputVector * (_movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > _minMovingSpeed || Mathf.Abs(inputVector.y) > _minMovingSpeed)
        {
            _isRunning = true;
        } else
        {
            _isRunning= false;
        }
    }


}
