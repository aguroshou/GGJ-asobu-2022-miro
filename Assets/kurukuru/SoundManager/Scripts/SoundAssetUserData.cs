using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoundAssetUserData : ScriptableObject
{
	public AudioClip Clip;
	public float VolumeRate = 1.0f;
}