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
        [SerializeField] private Vector2[] cameraResolutions;
        private int currentResolution;

        private void Start()
        {
            ppc = GetComponent<PixelPerfectCamera>();
        }

        private void OnEnable()
        {
            EventManager.DoScreenShake += ScreenShake;
        }
        
        private void OnDisable()
        {
            EventManager.DoScreenShake -= ScreenShake;
        }

        private void Update()
        {
            ResolutionScroll();
        }

        private void ResolutionScroll()
        {
            if (Mouse.current.scroll.ReadValue().y > 0)
                currentResolution--;
            
            if (Mouse.current.scroll.ReadValue().y < 0)
                currentResolution++;

            if (currentResolution < 0)
                currentResolution = 0;

            if (currentResolution > cameraResolutions.Length - 1)
                currentResolution = cameraResolutions.Length - 1;

            ppc.refResolutionX = (int)cameraResolutions[currentResolution].x;
            ppc.refResolutionY = (int)cameraResolutions[currentResolution].y;
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