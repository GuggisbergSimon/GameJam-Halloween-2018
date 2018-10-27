using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private CinemachineVirtualCamera vcam;
	[SerializeField] private CinemachineBasicMultiChannelPerlin noise;

	void Start()
	{
		vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
		noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
	}

	public void Noise(float amplitudeGain, float frequencyGain)
	{
		noise.m_AmplitudeGain = amplitudeGain;
		noise.m_FrequencyGain = frequencyGain;
	}
}