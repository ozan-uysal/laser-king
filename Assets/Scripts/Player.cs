using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    Vector2 RawInput;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 minBounds;
    Vector2 maxBounds;

    public bool isBoosted;
    public bool isFire;

    public Renderer renderer;

    private void Start()
    {
      
        InitBounds();
    }
    void Update()
    {
        Move();
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void Move()
    {
        float speed = isBoosted ? moveSpeed * 2 : moveSpeed;
        Vector3 delta = RawInput * speed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        RawInput = value.Get<Vector2>();
    }

    public void Boost()
    {
        if (isBoosted)
            return;

        isBoosted = true;
        Invoke(nameof(UnBoost), 3.5f);

        transform.DOScale(1.5f, .3f).SetLoops(-1);
        renderer.sharedMaterial.color = Color.blue;
    }

    public void UnBoost()
    {
        if (!isBoosted)
            return;

        isBoosted = false;
        DOTween.KillAll();
        renderer.sharedMaterial.color = Color.white;
    }

    public void UpgradeFire()
    {
        if (isFire)
            return;

        isFire = true;
        Invoke(nameof(FinishFire), 5f);

        transform.DOScale(1.5f, .3f).SetLoops(-1);
        renderer.sharedMaterial.color = Color.red;
    }

    public void FinishFire()
    {
        if (!isFire)
            return;

        isFire = false;
        DOTween.KillAll();
        renderer.sharedMaterial.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Enemy enemy))
            return;

        SceneManager.LoadScene("DeadScene", LoadSceneMode.Single);
    }
}
