using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour
{
	public int player;
	public bool canJump = false, canWalk = false;
	float speed = Settings.defCharSpeed, jumpF = Settings.defJumpF, jumpTime = 0f, pushTime = 0f, curCamHeight = 0f;
	public static readonly float jumpCD = 0.05f, pushCD = 1f;
	public Consumable item = null;
	public GameObject camera, head, feet;
	public Rigidbody2D pysc;
	// Use this for initialization
	void Start ()
	{
		pysc = GetComponent<Rigidbody2D> ();
		curCamHeight = camera.transform.position.y;
	}

	public void eat (Consumable c)
	{
		if (item == null) {
			item = c;
			c.gameObject.SetActive (false);
		}
	}
	//float maxY = 0f;
	void Update ()
	{
		//Debug.Log (maxY = Mathf.Max (maxY, pysc.velocity.y));
		//Debug.Log (item == null);
		jumpTime -= Time.deltaTime;
		pushTime -= Time.deltaTime;
		camera.transform.position = new Vector3 (4, curCamHeight += (head.transform.position.y - curCamHeight) * 0.1f, -1);
		bool left = Input.GetKey (Settings.keys [player, Settings.left]);
		bool right = Input.GetKey (Settings.keys [player, Settings.right]);
		bool up = Input.GetKey (Settings.keys [player, Settings.up]) && jumpTime <= 0;
		bool use = Input.GetKeyDown (Settings.keys [player, Settings.use]);
		bool push = Input.GetKeyDown (Settings.keys [player, Settings.push]) && pushTime < 0;
		if (item != null && Input.GetKeyDown (Settings.keys [player, Settings.power])) {
			item.onConsumption (gameObject);
			Destroy (item.gameObject);
		}
		if (push || use) {
			RaycastHit2D[] hits = Physics2D.BoxCastAll (pysc.position, Settings.activationArea, 0f, Vector2.down, 0f);
			if (use) {
				Activatable a;
				foreach (RaycastHit2D rh in hits)
					if ((a = rh.collider.gameObject.GetComponent<Activatable> ()) != null)
						a.activate ();
			}
			if (push) {
				CharControl c;
				foreach (RaycastHit2D rh in hits)
					if (rh.collider.attachedRigidbody != null && (c = rh.collider.attachedRigidbody.gameObject.GetComponent<CharControl> ()) != null)
					if (c != this) {
						c.pysc.AddForce (new Vector2 (c.pysc.position.x - feet.transform.position.x, c.pysc.position.y - feet.transform.position.y).normalized * Settings.pushF);
						pushTime = pushCD;
						break;
					}
			}
		}
		canJump = false;
		canWalk = false;
		if (pysc.velocity.y > Settings.maxYV)
			pysc.velocity = new Vector2 (pysc.velocity.x, Settings.maxYV);
		if (!(left || right || up))
			return;
		Vector2 norm = new Vector2 (0, 0);
		foreach (RaycastHit2D rh in Physics2D.CircleCastAll(feet.transform.position, 3f, Vector2.down, 0.2f))
			if (!rh.collider.isTrigger && rh.normal.y > 0.3) {
				norm += rh.normal;
				canJump = true;
				if (rh.collider.sharedMaterial.friction != 0)
					canWalk = true;
			}
		if (left ^ right)
		if (canWalk) {
			norm = norm.normalized;
			pysc.AddForce (((left ? -speed : speed) * (new Vector2 (norm.y, -norm.x)) - pysc.velocity) * pysc.mass, ForceMode2D.Impulse);
		} else if (pysc.velocity.x > -Settings.maxSideSlip && left)
			pysc.AddForce (new Vector2 (-Settings.sideSlip, 0));
		else if (pysc.velocity.x < Settings.maxSideSlip)
			pysc.AddForce (new Vector2 (Settings.sideSlip, 0));
		if (up && canJump) {
			pysc.AddForce (new Vector2 (0, jumpF));
			jumpTime = jumpCD;
		}
	}
}
