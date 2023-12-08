// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UltimateClean
{
    /// <summary>
    /// This component goes together with a button object and contains
    /// the audio clips to play when the player rolls over and presses it.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class ButtonBgmSounds : MonoBehaviour
    {
        public AudioClip Title;
        public AudioClip Roby;
        public AudioClip Minigame;
        public AudioClip Gacha;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayTitleSound()
        {
            audioSource.clip = Title;
            audioSource.Play();
        }

        public void PlayRobySound()
        {
            audioSource.clip = Roby;
            audioSource.Play();
        }

        public void PlayMinigameSound()
        {
            audioSource.clip = Minigame;
            audioSource.Play();
        }
        public void PlayGachaSound()
        {
            audioSource.clip = Gacha;
            audioSource.Play();
        }
    }
}