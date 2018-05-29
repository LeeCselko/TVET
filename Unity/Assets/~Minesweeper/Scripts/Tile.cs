using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MineSweeper
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {

        public int x, y;
        public bool isMine = false;
        public bool isRevealed = false;
        public bool isFlagged = false;
        [Header("References")]
        public Sprite flagSprite;
        public Sprite[] emptySprites;
        public Sprite[] mineSprites;
        private SpriteRenderer rend;

        private Sprite originalSprite;

        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
            originalSprite = rend.sprite;
        }

        void Start()
        {
            isMine = Random.value < .05f;
        }

        public void Flag(bool isFlagged)
        {
            this.isFlagged = isFlagged;
            if (isFlagged)
            {
                rend.sprite = flagSprite;
            }
            else
            {
                rend.sprite = originalSprite;
            }
        }

        public void Reveal(int adjacentMines, int mineState = 0)
        {
            if (isFlagged)
                return;

            isRevealed = true;

            if (isMine)
            {
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                rend.sprite = emptySprites[adjacentMines];
            }
        }

    }
}
