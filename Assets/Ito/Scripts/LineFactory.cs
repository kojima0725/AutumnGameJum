using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class LineFactory : MonoBehaviour
{
	[SerializeField] GameObject _linePrefab;
	[HideInInspector] Line _currentLine;
	[SerializeField] Transform _lineParent;
	[SerializeField] RigidbodyType2D _lineRigidBodyType = RigidbodyType2D.Kinematic;
	[SerializeField] LineEnableMode _lineEnableMode = LineEnableMode.ON_CREATE;
	[SerializeField] static LineFactory _instance;
	[SerializeField] Image _lineLife;
	[SerializeField] bool _enableLineLife;
	[SerializeField] bool _isRunning;
	[SerializeField] int _lineLimit;
	private int _lineCount;

	void Awake()
	{
		_lineParent = new GameObject("LineContiner").transform;
		if (_instance == null)
		{
			_instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		if (_lineLife != null)
		{
			if (_enableLineLife)
			{
				_lineLife.gameObject.SetActive(true);
			}
			else
			{
				_lineLife.gameObject.SetActive(false);
			}
		}

	}

	void Update()
	{
		if (!_isRunning)
		{
			return;
		}

		if (Input.GetMouseButtonDown(0))
		{
			CreateNewLine();
			if (_lineCount > _lineLimit)
			{
				DestroyLine();
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			RelaseCurrentLine();
		}

		if (_currentLine != null)
		{
			var pos = Input.mousePosition;
			pos.z = 10;
			pos = Camera.main.ScreenToWorldPoint(pos);

			_currentLine.AddPoint(pos);
			UpdateLineLife();
			if (_currentLine.ReachedPointsLimit())
			{
				RelaseCurrentLine();
			}
		}
	}

	private void CreateNewLine()
	{
		_lineCount++;
		_currentLine = (Instantiate(_linePrefab, Vector3.zero, Quaternion.identity) as GameObject).GetComponent<Line>();
		_currentLine.name = "Line";
		_currentLine.transform.SetParent(_lineParent);
		_currentLine.SetRigidBodyType(_lineRigidBodyType);

		if (_lineEnableMode == LineEnableMode.ON_CREATE)
		{
			EnableLine();
		}
	}

	private void EnableLine()
	{
		_currentLine.EnableCollider();
		_currentLine.SimulateRigidBody();
	}

	private void RelaseCurrentLine()
	{
		if (_lineEnableMode == LineEnableMode.ON_RELASE)
		{
			EnableLine();
		}

		_currentLine = null;
	}

	private void UpdateLineLife()
	{
		if (!_enableLineLife)
		{
			return;
		}

		if (_lineLife == null)
		{
			return;
		}

		_lineLife.fillAmount = 1 - (_currentLine.points.Count / _currentLine.maxPoints);
	}

	private void DestroyLine()
	{
		_lineCount = 0;
		Line[] lines = GameObject.FindObjectsOfType<Line>();
		foreach (var l in lines)
		{
			Destroy(l.gameObject);
		}
		CreateNewLine();
	}

	public enum LineEnableMode
	{
		ON_CREATE,
		ON_RELASE
	}
}
