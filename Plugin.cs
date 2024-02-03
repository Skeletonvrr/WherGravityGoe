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
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
        }

        void Update()
        {
        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
            }

            inRoom = true;
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (1.0f / Time.deltaTime)), ForceMode.Acceleration);
            }

            inRoom = false;
        }
    }
}