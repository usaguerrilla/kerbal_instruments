using UnityEngine;

using KSP.UI;
using KSP.UI.Screens;

using KSPAssets;
using KSPAssets.Loaders;

using KerbalDaqScripts;

namespace KerbalInstruments.KerbalDaq
{
    [KSPScenario(ScenarioCreationOptions.AddToAllGames, new GameScenes[] { GameScenes.SPACECENTER })]
    public class KerbalScienceStationScenarioModule : ScenarioModule
    {
        public override void OnAwake()
        {
            RegisterEvents();
            Debug.Log("KPL KerbalScienceStationScenarioModule::OnAwake: " + GetHashCode());
        }

        public override void OnLoad(ConfigNode node)
        {
            // TODO
            Debug.Log("KPL KerbalScienceStationScenarioModule::OnLoad: " + GetHashCode());
        }

        public override void OnSave(ConfigNode node)
        {
            // TODO
            Debug.Log("KPL KerbalScienceStationScenarioModule::OnSave: " + GetHashCode());
        }

        void Start()
        {
            Debug.Log("KPL KerbalScienceStationScenarioModule::Start");
        }

        void OnDisable()
        {
            Debug.Log("KPL KerbalScienceStationScenarioModule::OnDisable");
            OnCloseDataScienceStation();
            UnregisterEvents();
        }

        void OnEnable()
        {
            Debug.Log("KPL KerbalScienceStationScenarioModule::OnEnable");
        }

        private void RegisterEvents()
        {
            GameEvents.onGUIApplicationLauncherReady.Add(OnGUIApplicationLauncherReady);
            GameEvents.onGUIApplicationLauncherUnreadifying.Add(OnGUIApplicationLauncherUnreadifying);
        }

        private void UnregisterEvents()
        {
            GameEvents.onGUIApplicationLauncherReady.Remove(OnGUIApplicationLauncherReady);
            GameEvents.onGUIApplicationLauncherUnreadifying.Remove(OnGUIApplicationLauncherUnreadifying);
        }

        private void OnGUIApplicationLauncherReady()
        {
            if (this.applicationLauncherButton == null)
            {
                Texture2D texture = GameDatabase.Instance.GetTexture(TOOLBAR_BUTTON_TEXTURE, false);

                if (texture != null)
                {
                    this.applicationLauncherButton = A﻿pplicationLaunch﻿er.I﻿nsta﻿nce﻿﻿.AddModApplication(OnOpenDataScienceStation,
                                                                                                    OnCloseDataScienceStation,
                                                                                                    OnDummyCallback,
                                                                                                    OnDummyCallback,
                                                                                                    OnDummyCallback,
                                                                                                    OnDummyCallback,
                                                                                                    ApplicationLauncher.AppScenes.SPACECENTER,
                                                                                                    texture);
                }
                else
                {
                    Debug.LogError("Failed to load '" + TOOLBAR_BUTTON_TEXTURE + "' texture");
                }
            }
        }

        private void OnGUIApplicationLauncherUnreadifying(GameScenes data)
        {
            if (this.applicationLauncherButton != null && ApplicationLauncher.Ready)
            {
                A﻿pplicationLaunch﻿er.I﻿nsta﻿nce﻿﻿.RemoveModApplication(this.applicationLauncherButton);
                this.applicationLauncherButton = null;
            }
        }

        private void OnOpenDataScienceStation()
        {
            Debug.Log("KPL KerbalScienceStationScenarioModule::OnOpenDataScienceStation");

            if (this.kerbalScienceStationGameObject == null)
            {
                AssetLoader.LoadAssets(AssetLoaded, new AssetDefinition[]
                {
                    AssetLoader.GetAssetDefinitionWithName(BUNDLE_NAME, OBJ_KERBAL_DATA_SCIENCE_STATION),
                });
            }
            else
            {
                OpenDataScienceStation();
            }
        }

        private void OpenDataScienceStation()
        {
            KerbalScienceStation kerbalScienceStation = this.kerbalScienceStationGameObject.GetComponent<KerbalScienceStation>();
            if (kerbalScienceStation != null)
            {
                kerbalScienceStation.OnClosedEvent += OnDataScienceStationClosed;
                kerbalScienceStation.Show(UIMasterController.Instance.uiScale);
            }
        }

        private void OnDataScienceStationClosed()
        {
            this.applicationLauncherButton.SetFalse();
        }

        private void AssetLoaded(AssetLoader.Loader obj)
        {
            for (int i = 0; i < obj.definitions.Length; ++i)
            {
                if (obj.definitions[i].name == OBJ_KERBAL_DATA_SCIENCE_STATION)
                {
                    this.kerbalScienceStationGameObject = Instantiate(obj.objects[i]) as GameObject;
                    OpenDataScienceStation();
                }
            }
        }

        private void OnCloseDataScienceStation()
        {
            if (this.kerbalScienceStationGameObject != null)
            {
                Debug.Log("KPL KerbalScienceStationScenarioModule::OnCloseDataScienceStation");

                KerbalScienceStation kerbalScienceStation = this.kerbalScienceStationGameObject.GetComponent<KerbalScienceStation>();
                if (kerbalScienceStation != null)
                {
                    kerbalScienceStation.Hide();
                }
            }
        }

        private void OnDummyCallback()
        {
        }

        private GameObject kerbalScienceStationGameObject;
        private ApplicationLauncherButton applicationLauncherButton;

        private const string OBJ_KERBAL_DATA_SCIENCE_STATION = "ui_KerbalDataScienceStation";

        private const string BUNDLE_NAME = "KerbalInstruments/UI/kerbalinstruments";

        private const string TOOLBAR_BUTTON_TEXTURE = "KerbalInstruments/Textures/ToolbarButtons/data-science-station";
    }
}
