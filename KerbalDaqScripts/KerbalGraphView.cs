using UnityEngine;
using UnityEngine.UI;

namespace KerbalDaqScripts
{
    public class KerbalGraphView : MonoBehaviour
    {
        public Camera KerbalGraphViewCamera;
        public RawImage KerbalGraphRawImage;
        public RenderTexture KerbalGraphRenderTexture;
        public KerbalScienceStation KerbalScienceStation;

        void Update()
        {
            KerbalGraphViewCamera.Render();
        }

        void Start()
        {
            KerbalGraphRenderTexture.width = (int) (((RectTransform) KerbalGraphRawImage.transform).rect.width + 0.5f);
            KerbalGraphRenderTexture.height = (int) (((RectTransform)KerbalGraphRawImage.transform).rect.height + 0.5f);
            KerbalGraphViewCamera.transform.SetParent(Camera.main.transform, false);
        }

        void OnDisable()
        {
            Debug.Log("KPL KerbalGraphView::OnDisable");
        }

        void OnEnable()
        {
            Debug.Log("KPL KerbalGraphView::OnEnable");
        }
    }
}
