using System;
using UnityEngine;
using TMPro;

namespace Murgn
{
    public class TextEffects : MonoBehaviour
    {
        private TMP_Text textComponent;
        [SerializeField] private float strength = 20;
        [SerializeField] private float speed = 2;

        private void Awake()
        {
            textComponent = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            textComponent.ForceMeshUpdate();
            var textInfo = textComponent.textInfo;

            for (int i = 0; i < textInfo.characterCount; ++i)
            {
                var charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible)
                    continue;

                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                for (int j = 0; j < 4; ++j)
                {
                    var orig = verts[charInfo.vertexIndex + j];
                    verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * speed + i) * strength, 0);

                }
            }

            for (int i = 0; i < textInfo.meshInfo.Length; ++i)
            {
                var meshInfo = textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                textComponent.UpdateGeometry(meshInfo.mesh, i);
            }
        }
    }   
}