using UnityEngine;
using UnityEngine.UI;

namespace KerbalDaqScripts
{
    public class KerbalScienceStation : MonoBehaviour
    {
        public delegate void OnClosed();
        public event OnClosed OnClosedEvent;

        public Button ToolbarCloseButton;

        public GameObject DataItemPrefab;
        public Transform DataItemsScrollViewContentTransform;

        public Camera GraphViewCamera;
        public RawImage GraphViewRawImage;
        public RenderTexture GraphViewRenderTexture;
        public GameObject GraphViewLinesRootObjectPrefab;

        void Update()
        {
            GraphViewCamera.Render();
        }

        void Start()
        {
            GraphViewRenderTexture.width = (int)(((RectTransform) GraphViewRawImage.transform).rect.width + 0.5f);
            GraphViewRenderTexture.height = (int)(((RectTransform) GraphViewRawImage.transform).rect.height + 0.5f);
            ToolbarCloseButton.onClick.AddListener(OnHide);
        }

        public void Show(float scale)
        {
            CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
            canvasScaler.scaleFactor = scale;

            ((RectTransform) transform).pivot = new Vector2(1.0f, 1.0f);
            ((RectTransform) transform).SetAsLastSibling();

            this.gameObject.SetActive(true);

            /*
             * Add lines so they are visible in the camera
             *
            this.linesRootObject = Instantiate<GameObject>(GraphViewLinesRootObjectPrefab);
            this.linesRootObject.SetActive(true);
            */
        }

        private void OnHide()
        {
            if (this.gameObject.activeSelf)
            {
                OnClosedEvent?.Invoke();
            }
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        private GameObject linesRootObject;
    }
}
