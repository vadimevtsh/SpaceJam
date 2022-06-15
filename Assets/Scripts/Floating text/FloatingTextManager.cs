using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a class that is responsible for managing floating text on the screen.
/// </summary>
public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> _floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach (FloatingText txt in _floatingTexts)
            txt.UpdateFloatingText();
    }

    /// <summary>
    /// Mwthod that prepares floating text and shows it to the user.
    /// </summary>
    /// <param name="msg">Message to be shown</param>
    /// <param name="fontSize">Font Size</param>
    /// <param name="color">Color of the message</param>
    /// <param name="position">Position on the screen.</param>
    /// <param name="motion">Motion</param>
    /// <param name="duration">Duration</param>
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;

        floatingText.txt.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    /// <summary>
    /// Method that creates floating text if needed or finds the one to be shown.
    /// </summary>
    /// <returns>Floating text to be shown.</returns>
    private FloatingText GetFloatingText()
    {
        FloatingText txt = _floatingTexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            _floatingTexts.Add(txt);
        }

        return txt;

    }
}
