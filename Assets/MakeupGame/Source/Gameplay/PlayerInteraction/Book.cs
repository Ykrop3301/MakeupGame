using System.Collections.Generic;
using UnityEngine;

namespace MakeupGame.Gameplay.PlayerInteraction
{
    public class Book : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _pages;
        private GameObject _activePage;
        private int _activePageId;

        private void Awake()
        {
            if (_pages.Count == 0) throw new System.Exception("Страницы не добавлены.");

            _activePageId = 0;
            _activePage = _pages[0];
            foreach (var page in _pages)
                page.SetActive(false);
            _pages[0].SetActive(true);
        }

        public void NextPage()
        {
            _activePage.SetActive(false);

            _activePageId = _activePageId + 1 == _pages.Count ? 0 : _activePageId + 1;
            _activePage = _pages[_activePageId];
            _activePage.SetActive(true);
        }

        public void PreviousPage()
        {
            _activePage.SetActive(false);

            _activePageId = _activePageId - 1 < 0 ? _pages.Count - 1 : _activePageId - 1;
            _activePage = _pages[_activePageId];
            _activePage.SetActive(true);
        }
    }
}
