﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBlock : Block, ISelectable
{
    public SpriteRenderer sprite;
    public GameObject answerText;
    
    public string GetEquation()
    {
        return equation;
    }
    public string GetAnswer()
    {
        return answer;
    }
    public void SetEquation(int indexOfEquationArray)
    {
        equation = EquationModel.instance.GetEquationArray()[indexOfEquationArray];
    }
    public void SetAnswer(int indexOfAnswerArray)
    {
        answer = AnswerModel.instance.GetAnswerArray()[indexOfAnswerArray];
    }
    public void SetTextOfBlock()
    {
        answerText.GetComponent<TextMesh>().text = GetAnswer().ToString();
    }
    public IEnumerator Destroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        BlockManager.Instance.blocksRemaining--;
    }

    public void Deselect()
    {
        sprite.color = Color.white;
        gameObject.transform.localScale += new Vector3(-0.5f, -0.5f, 0);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Select()
    {
        sprite.color = Color.green;
        gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0);
    }
}
