using UnityEngine;
using System.Collections;

public static class Settings
{
	public static float defCharSpeed = 40f;
	public static float defJumpF = 7600f;
	public static float sideSlip = 400f;
	public static float maxSideSlip = 45f;
	public static float maxYV = 73.21f;
	public static float pushF = 10000f;
	public static float ladderSpeed = 50f;
	public static Vector2 activationArea = new Vector2 (24f, 24f);
	public static readonly int up = 0, down = 1, left = 2, right = 3, power = 4, use = 5, push = 6, ui = 2, pause = 0, menu = 1;
	public static KeyCode[,] keys = {
		{ KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Q, KeyCode.E, KeyCode.C },
		{ KeyCode.I, KeyCode.K, KeyCode.J, KeyCode.L, KeyCode.U, KeyCode.O, KeyCode.Period },
		{ KeyCode.Escape, KeyCode.M }
	};
}
