﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UITweenPositionZ : MonoBehaviour {

	public float toPosition;
	public float duration;
	public bool snapping;
	public bool playOnAwake = false;
	public bool isUI = true;
	public Ease ease;
	public bool loop;
	private Tweener tweener;

	void Awake(){
		if (playOnAwake) {
			startAnimation ();
		}
	}

	public void startAnimation(){
		if (tweener != null) {
			tweener.Rewind ();
		}
		if (isUI) {
			tweener = transform.DOLocalMoveZ (toPosition, duration, snapping).SetUpdate (false);
		} else {
			tweener = transform.DOMoveZ (toPosition, duration, snapping).SetUpdate (false);
		}
		tweener.SetEase (ease);
		if (loop) {
			tweener.OnComplete (startAnimation);
		}
	}

	
}
