using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

namespace Murgn
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField xInput;
        [SerializeField] private TMP_InputField yInput;
        [SerializeField] private Button goButton;
        [SerializeField] private Image logo;
        [SerializeField] private float speed;
        [SerializeField] private float strength;
        
        private void Update()
        {
            if(!string.IsNullOrEmpty(xInput.text) && !string.IsNullOrEmpty(yInput.text))
                goButton.gameObject.SetActive(true);
            else
                goButton.gameObject.SetActive(false);

            logo.transform.position = new Vector3(logo.transform.position.x, logo.transform.position.y + Mathf.Sin(Time.time * speed) * strength);
        }

        public void GenerateMap()
        {
            EventManager.DoMapGenerate?.Invoke(int.Parse(xInput.text), int.Parse(yInput.text));
        }
    }   
}