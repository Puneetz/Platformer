using System;

namespace Scripts
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class ScoreScript: MonoBehaviour
	{

		private int scoreValue = 0;
		private Text score;
		public Text subScore;
		public Transform target;
		public float smoothTime = 0.3F;
		private Vector3 velocity = Vector3.zero;
		private Transform subScoreTransformation;
		private bool IsMoving = false;
		private Transform scoreTransform;


		void MoveSubScore()
		{
			Debug.Log("helsosd");
			subScoreTransformation.position = Vector3.SmoothDamp(subScoreTransformation.position, scoreTransform.position, ref velocity, smoothTime);
		}
		
		private IEnumerator DisappearSubScore()
		{
			yield return new WaitForSeconds(1.0f);

			subScore.text = string.Empty;
			IsMoving = false;
			subScoreTransformation.position = new Vector3(subScoreTransformation.position.x, 93.2f, 0f);
		}

		public void ScoreIncrease(int increase)
		{
			IsMoving = true;
			subScore.text = "+" + increase.ToString();
			StartCoroutine(DisappearSubScore());
			scoreValue += increase;
			score.text = scoreValue.ToString();
		}

		void Awake()
		{
			score = GetComponent<Text>();
			scoreTransform = GetComponent<Transform>();
			subScoreTransformation = subScore.GetComponent<Transform>();
		}

		private void Update()
		{
			if (IsMoving)
			{
				MoveSubScore();
			}
		}
	}
} 