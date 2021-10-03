using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour
{
    [SerializeField] private Image _tip;
    [SerializeField] private Text _text;
    [SerializeField] private float _delay;
    [SerializeField] private float _disappearenceDuration;

    private string _defaultText;
    private float _t;

    private void Start()
    {
        _defaultText = _text.text;
        _tip.gameObject.SetActive(false);
    }

    public void Show(string bonusText)
    {
        _tip.gameObject.SetActive(true);
        _tip.color = new Color(1,1,1,1);
        _text.color = new Color(0, 0, 0, 1);
        _text.text = _defaultText + bonusText;
        _t = 0;
    }

    private void Update()
    {
        if (_tip.gameObject.activeInHierarchy)
        {
            _t += Time.deltaTime;
            if (_t >= _delay)
            {
                _tip.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), (_t- _delay) / _disappearenceDuration);
                _text.color = _tip.color - new Color(1,1,1,0);
                if (_t == _disappearenceDuration)
                {
                    _tip.gameObject.SetActive(false);
                }
            }
        }
    }
}
