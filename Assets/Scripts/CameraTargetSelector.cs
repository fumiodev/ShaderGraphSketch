using System;
using UnityEngine;
using Cinemachine;

public class CameraTargetSelector : MonoBehaviour
{
	[Serializable]
	private struct TargetInfo
	{
		public Transform follow;
		public Transform lookAt;
	}

	[SerializeField] private CinemachineVirtualCamera VirtualCamera;

	[SerializeField] private TargetInfo[] TargetList;

	private int m_CurrentTarget = 0;

	private void Update()
	{
		if (TargetList == null || TargetList.Length <= 0)
		{
			return;
		}

		// On Mouse click
		if (Input.GetMouseButtonDown(0))
		{
			if (++m_CurrentTarget >= TargetList.Length)
			{
				m_CurrentTarget = 0;
			}

			var info = TargetList[m_CurrentTarget];
			VirtualCamera.Follow = info.follow;
			VirtualCamera.LookAt = info.lookAt;
		}
	}
}