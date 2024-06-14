using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening.Core;

public class BoostUpgrade : MonoBehaviour
{
    TweenerCore<Quaternion, Vector3, DG.Tweening.Plugins.Options.QuaternionOptions> tween;
    private void Start()
    {
        Destroy(gameObject, 3f);

        tween = transform.DORotate(Vector3.forward * 180, .5f).SetLoops(-1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Player player))
            return;

        player.Boost();
        tween.Kill();
        Destroy(gameObject);
    }
}
