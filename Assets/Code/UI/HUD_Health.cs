using System.Globalization;
using Battle;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HUDHealth : MonoBehaviour
    {
        public Health health;
        public TextMeshProUGUI textMesh;


        
        private void OnEnable() => health.OnDamage += UpdateView;
        private void OnDisable() => health.OnDamage += UpdateView;

        private void Start() => UpdateView(default);

        private void UpdateView(float _)
        {
            textMesh.text = health.value.ToString(CultureInfo.InvariantCulture);
        }
    }
}