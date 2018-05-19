using UnityEngine;
using UnityEngine.UI;

namespace KerbalDaqScripts
{
    public class KerbalDataItem : MonoBehaviour
    {
        public Toggle Toggle;

        public Text VesselName;
        public Text StatusName;

        void Start()
        {
            Debug.Log("KPL KerbalDataItem::Start");
        }

        void OnDisable()
        {
            Debug.Log("KPL KerbalDataItem::OnDisable");
        }

        void OnEnable()
        {
            Debug.Log("KPL KerbalDataItem::OnEnable");
        }
    }
}
