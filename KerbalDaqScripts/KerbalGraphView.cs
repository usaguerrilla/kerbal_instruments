using UnityEngine;

namespace KerbalDaqScripts
{
    public class KerbalGraphView : MonoBehaviour
    {
        public KerbalScienceStation KerbalScienceStation;

        void Start()
        {
            Debug.Log("KPL KerbalGraphView::Start");
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
