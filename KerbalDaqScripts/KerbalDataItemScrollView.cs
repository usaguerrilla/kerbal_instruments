using UnityEngine;

namespace KerbalDaqScripts
{
    public class KerbalDataItemScrollView : MonoBehaviour
    {
        public KerbalScienceStation KerbalScienceStation;

        void Start()
        {
            Debug.Log("KPL KerbalDataItemScrollView::Start");
        }

        void OnDisable()
        {
            Debug.Log("KPL KerbalDataItemScrollView::OnDisable");
        }

        void OnEnable()
        {
            Debug.Log("KPL KerbalDataItemScrollView::OnEnable");
        }
    }
}
