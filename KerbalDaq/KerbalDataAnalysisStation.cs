using UnityEngine;

using KSP.UI.Screens;
using System;

namespace KerbalInstruments.KerbalDaq
{
    [KSPScenario(ScenarioCreationOptions.AddToAllGames, new GameScenes[] { GameScenes.SPACECENTER })]
    public class KerbalDataAnalysisStation : ScenarioModule
    {
        public override void OnAwake()
        {
            RegisterEvents();
        }

        public override void OnLoad(ConfigNode node)
        {
            // TODO
            Debug.Log(">>>> KerbalDataAnalysisStation::OnLoad: " + GetHashCode());
        }

        public override void OnSave(ConfigNode node)
        {
            // TODO
            Debug.Log(">>>> KerbalDataAnalysisStation::OnSave: " + GetHashCode());
        }

        public void OnDisable()
        {
            UnregisterEvents();
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
            // TODO
            Debug.Log(">>>> KerbalDataAnalysisStation::OnOpenDataScienceStation: " + GetHashCode());
        }

        private void OnCloseDataScienceStation()
        {
            // TODO
            Debug.Log(">>>> KerbalDataAnalysisStation::OnCloseDataScienceStation: " + GetHashCode());
        }

        private void OnDummyCallback()
        {
        }

        private ApplicationLauncherButton applicationLauncherButton;

        private const string TOOLBAR_BUTTON_TEXTURE = "KerbalInstruments/Textures/ToolbarButtons/data-science-station";
    }
}
