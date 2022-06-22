using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

namespace Murgn
{
    public class MenuController : MonoBehaviour
    {
        [Header("Level Make")]
        [SerializeField] private TMP_InputField xInput;
        [SerializeField] private TMP_InputField yInput;
        [SerializeField] private Button makeGoButton;
        
        [Header("Level Play")]
        [SerializeField] private TMP_InputField levelCodeInput;
        [SerializeField] private Button playGoButton;

        [Header("Fps Counter")] 
        [SerializeField] private TextMeshProUGUI fpsText;
        private float pollingTime = 0.25f;
        private float time;
        private int frameCount;

        private void Start()
        {
            Cursor.visible = false;
        }

        private void Update()
        { 
            ButtonCheckers();
            FpsCounter();            
        }

        private void ButtonCheckers()
        {
            if(!string.IsNullOrEmpty(xInput.text) && !string.IsNullOrEmpty(yInput.text))
                makeGoButton.gameObject.SetActive(true);
            else
                makeGoButton.gameObject.SetActive(false);
            
            if(!string.IsNullOrEmpty(levelCodeInput.text))
                playGoButton.gameObject.SetActive(true);
            else
                playGoButton.gameObject.SetActive(false);
        }

        private void FpsCounter()
        {
            time += Time.unscaledDeltaTime;
            frameCount++;
            if (time >= pollingTime)
            {
                int frameRate = Mathf.RoundToInt(frameCount / time);
                fpsText.text = frameRate.ToString() + " fps";

                time -= pollingTime;
                frameCount = 0;
            }
        }
        
        public void GenerateMap()
        {
            EventManager.OnGoButtonPress?.Invoke();
            EventManager.DoMapGenerate?.Invoke(int.Parse(xInput.text), int.Parse(yInput.text));
        }
        
        public void LoadMap()
        {
            EventManager.OnGoButtonPress?.Invoke();
            EventManager.DoMapClipboardRead?.Invoke(levelCodeInput.text);
        }
    }   
}