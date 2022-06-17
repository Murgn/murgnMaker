using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

namespace Murgn
{
    public class CameraController : MonoBehaviour
    {
        private PixelPerfectCamera ppc;
        private Camera mainCamera;

        private int scrollMultiplier = 8;

        private void Start()
        {
            ppc = GetComponent<PixelPerfectCamera>();
            mainCamera = GetComponent<Camera>();
        }

        private void OnEnable()
        {
            EventManager.DoScreenShake += ScreenShake;
        }

        private void Update()
        {
            if (Mouse.current.scroll.ReadValue().y > 0)
                scrollMultiplier--;
            
            if (Mouse.current.scroll.ReadValue().y < 0)
                scrollMultiplier++;

            scrollMultiplier = Mathf.Clamp(scrollMultiplier, 8, 32);
            mainCamera.orthographicSize = scrollMultiplier;
            
            // ppc.refResolutionX = 16 * scrollMultiplier;
            // ppc.refResolutionY = 9 * scrollMultiplier;
            // Mathf.Clamp(scrollMultiplier, 15, 30);

        }

        private void ScreenShake(float magnitude, float rotation, float duration)
        {
            StartCoroutine(Shake(magnitude, rotation, duration));
        }
        
        private IEnumerator Shake(float magnitude, float rotation, float duration)
        {
            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;
                float w = Random.Range(-rotation, rotation);

                transform.localPosition = new Vector3(x, y, -10);
                transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, w));

                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = new Vector3(0.0f, -0.2f, -10);
            transform.localRotation = Quaternion.identity;
        }
    }   
}