using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;
    [SerializeField] private Transform _SlotParent, _pieceParent;


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }


    void Spawn()
    {
        var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(4).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            var spawmedSlot = Instantiate(randomSet[i], _SlotParent.GetChild(i).position, Quaternion.identity);
            var spawmedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
            spawmedPiece.Init(spawmedSlot);

        }
    }

    
   
}
