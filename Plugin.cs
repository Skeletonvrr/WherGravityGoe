using System;
using BepInEx;
using GorillaTagModTemplateProject;
using UnityEngine;
using Utilla;
using WherGravityGoe;

namespace ModTemp
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(WherGravityGoe.PluginInfo.GUID, WherGravityGoe.PluginInfo.Name, WherGravityGoe.PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;

        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (1.0f / Time.deltaTime)), ForceMode.Acceleration);
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
        }
        
        void Update()
        {
            bool flag = this.inRoom;
            if (flag)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
            }
        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            this.inRoom = true;
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            this.inRoom = false;
        }
    }
}
