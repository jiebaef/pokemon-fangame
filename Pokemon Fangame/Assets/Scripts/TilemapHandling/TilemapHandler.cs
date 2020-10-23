using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.TilemapHandling
{
    public class TilemapHandler
    {
        public IEnumerable<Tilemap> TraversableByFoot { get; private set; }

        public IEnumerable<Tilemap> TraversableBySurfing { get; private set; }

        public IEnumerable<Tilemap> NotTraversable { get; private set; }

        public Tilemap GroundTilemap { get; private set; }

        public Tilemap Environment { get; private set; }

        public TilemapHandler(Tilemap groundTilemap, Tilemap environment)
        {
            GroundTilemap = groundTilemap;
            Environment = environment;
        }

        public TilemapHandler(IEnumerable<Tilemap> traversableByFoot, IEnumerable<Tilemap> traversableBySurfing = null, IEnumerable<Tilemap> notTraversable = null)
        {
            TraversableByFoot = traversableByFoot;

            if (traversableBySurfing != null)
                TraversableBySurfing = traversableBySurfing;

            if (notTraversable != null)
                NotTraversable = notTraversable;
        }

        public bool CanMove(Vector3 futurePosition)
        {
            var gridPosition = GroundTilemap.WorldToCell(futurePosition);

            if (!GroundTilemap.HasTile(gridPosition) || Environment.HasTile(gridPosition))
                return false;

            return true;
        }
    }
}
