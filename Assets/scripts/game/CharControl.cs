using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour
{
	public GameObject head, feet, baseSpawn, itemIcon;
	public int player;
	public bool canJump = false, canWalk = false, onLadder = false;
	float speed = Settings.defCharSpeed, jumpF = Settings.defJumpF, jumpTime = 0f, pushTime = 0f;
	public static readonly float jumpCD = 0.05f, pushCD = 1f, pixelPerSound = 8f;
	public Consumable item = null;
	public Rigidbody2D pysc;
	public GameObject curSpawn;
	public Sprite walk0, walk1, fallDown, fallUp;
	SpriteRenderer sr;
	bool variate = false;
	Vector2 lastJuicePos;
	// Use this for initialization
	void Start ()
	{
		pysc = GetComponent<Rigidbody2D> ();
		sr = head.GetComponent<SpriteRenderer> ();
		curSpawn = baseSpawn;
		lastJuicePos = pysc.position;
	}

	public void kill ()
	{
		pysc.velocity = Vector2.zero;
		transform.position = new Vector3 (curSpawn.transform.position.x, curSpawn.transform.position.y + 4f, 0f);
		SoundManager.script.playOnListener (SoundManager.script.death0, 0.4f);
	}

	public bool eat (Consumable c)
	{
		if (item == null) {
			item = c;
			itemIcon.GetComponent<UnityEngine.UI.Image> ().sprite = c.icon;
			itemIcon.SetActive (true);
			return true;
		}
		return false;
	}
	//float maxY = 0f;
	void Update ()
	{
		//Debug.Log (maxY = Mathf.Max (maxY, pysc.velocity.y));
		if (PauseMenu.paused)
			return;
		if (transform.position.y < -200f)
			kill ();
		jumpTime -= Time.deltaTime;
		pushTime -= Time.deltaTime;
		bool left = Input.GetKey (Settings.keys [player, Settings.left]);
		bool right = Input.GetKey (Settings.keys [player, Settings.right]);
		bool up = Input.GetKey (Settings.keys [player, Settings.up]) && jumpTime <= 0;
		bool use = Input.GetKeyDown (Settings.keys [player, Settings.use]);
		bool push = Input.GetKeyDown (Settings.keys [player, Settings.push]) && pushTime < 0;
		if (item != null && Input.GetKeyDown (Settings.keys [player, Settings.power])) {
			item.use (this);
			itemIcon.SetActive (false);
			item = null;
		}
		if (push || use) {
			RaycastHit2D[] hits = Physics2D.BoxCastAll (pysc.position, Settings.activationArea, 0f, Vector2.down, 0f);
			if (use) {
				Activatable a;
				foreach (RaycastHit2D rh in hits)
					if ((a = rh.collider.gameObject.GetComponent<Activatable> ()) != null)
						a.activate (this);
			}
			if (push) {
				CharControl c;
				foreach (RaycastHit2D rh in hits)
					if (rh.collider.attachedRigidbody != null && (c = rh.collider.attachedRigidbody.gameObject.GetComponent<CharControl> ()) != null)
					if (c != this) {
						c.pysc.AddForce (new Vector2 (c.pysc.position.x - feet.transform.position.x, c.pysc.position.y - feet.transform.position.y).normalized * Settings.pushF);
						pushTime = pushCD;
						SoundManager.script.playOnListener (SoundManager.script.punch0);
						break;
					}
			}
		}
		canJump = false;
		canWalk = false;
		if (pysc.velocity.y > Settings.maxYV)
			pysc.velocity = new Vector2 (pysc.velocity.x, Settings.maxYV);
		//if (!(left || right || up))
		//	return;
		Vector2 norm = new Vector2 (0, 0);
		foreach (RaycastHit2D rh in Physics2D.CircleCastAll(feet.transform.position, 3f, Vector2.down, 0.2f))
			if (!rh.collider.isTrigger && rh.normal.y > 0.3) {
				norm += rh.normal;
				canJump = true;
				if (rh.collider.sharedMaterial.friction != 0)
					canWalk = true;
			}
		if (left ^ right) {
			sr.flipX = left;
			if (canWalk) {
				norm = norm.normalized;
				pysc.AddForce (((left ? -speed : speed) * (new Vector2 (norm.y, -norm.x)) - pysc.velocity) * pysc.mass, ForceMode2D.Impulse);
			} else if (pysc.velocity.x > -Settings.maxSideSlip && left)
				pysc.AddForce (new Vector2 (-Settings.sideSlip, 0));
			else if (pysc.velocity.x < Settings.maxSideSlip)
				pysc.AddForce (new Vector2 (Settings.sideSlip, 0));
		}
		if (up)
		if (onLadder)
			pysc.velocity = new Vector2 (pysc.velocity.x, Settings.ladderSpeed);
		else if (canJump) {
			SoundManager.script.playOnListener (Random.value < 0.5 ? SoundManager.script.jump0 : SoundManager.script.jump1);
			pysc.AddForce (new Vector2 (0, jumpF));
			pysc.velocity = new Vector2 (pysc.velocity.x * 0.2f, pysc.velocity.y);
			jumpTime = jumpCD;
		}
		if (onLadder && Mathf.Abs (lastJuicePos.y - pysc.position.y) > pixelPerSound) {
			SoundManager.script.playOnListener (variate ? SoundManager.script.climb0 : SoundManager.script.climb1);
			lastJuicePos = pysc.position;
			variate = !variate;
		} else if (canWalk && (lastJuicePos - pysc.position).sqrMagnitude > pixelPerSound * pixelPerSound) {
			sr.sprite = variate ? walk0 : walk1;
			SoundManager.script.playOnListener (variate ? SoundManager.script.walk0 : SoundManager.script.walk1, 0.25f);
			lastJuicePos = pysc.position;
			variate = !variate;
		} else if (!onLadder)
			sr.sprite = variate ? walk0 : walk1;
		if (!canWalk && !onLadder)
			sr.sprite = pysc.velocity.y > 0 ? fallUp : fallDown;
		onLadder = false;
	}
}
