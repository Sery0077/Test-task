using UnityEngine;

namespace Components
{
    public class TileGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject sprite;
        [SerializeField] private Transform player;

        private float _tileLenght;

        private GameObject _currentTile;
        private GameObject _previousTile;
        private bool _previousTileExist;

        private Renderer _currentTileRenderer;
        private Renderer _previousTileRenderer;

        private void Start()
        {
            _tileLenght = sprite.GetComponent<Renderer>().bounds.size.x;

            _currentTile = Instantiate(sprite, Vector3.zero, transform.rotation);
            _currentTileRenderer = _currentTile.GetComponent<Renderer>();

            SpawnTile();
        }

        void Update()
        {
            if (_currentTileRenderer.bounds.max.x - player.position.x < 50)
            {
                SpawnTile();
            }
            else if (_previousTileExist && player.position.x - _previousTileRenderer.bounds.max.x > 50)
            {
                DeleteTile();
            }
        }

        private void SpawnTile()
        {
            _previousTile = _currentTile;
            _previousTileExist = true;
            _currentTile = Instantiate(sprite, transform.right * (_currentTileRenderer.bounds.center.x + _tileLenght),
                transform.rotation);
            
            _previousTileRenderer = _previousTile.GetComponent<Renderer>();
            _currentTileRenderer = _currentTile.GetComponent<Renderer>();
        }

        private void DeleteTile()
        {
            Destroy(_previousTile);
            _previousTileExist = false;
        }
    }
}